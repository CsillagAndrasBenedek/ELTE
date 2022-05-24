using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;
using TowerDefense.GameObjects;
using TowerDefense.Model;
using TowerDefense.Persistence;

namespace TowerDefense.View
{
    public partial class GameView : Form
    {
        #region Private fields

        private GameModel _model;
        private GameButton[,] _buttonGrid;
        private Timer _gameTimer;
        private int _currentSteps;
        private readonly int _size = 40; // size for UI elements

        #endregion

        #region Constructor

        public GameView()
        {
            InitializeComponent();

            _model = new GameModel(new DataAccess());
            _model.GameOver += OnGameOver;
            _model.FieldChanged += OnFieldChanged;
            _model.DetailsExtended += OnDetailsExtended;
            

            //Initializing the buttons and the table
            int[] prices = _model.InitializePrices();
            troopButton.Text = "Buy troop (-" + prices[0].ToString() + "g)";
            cavalryButton.Text = "Buy cavalry (-" + prices[1].ToString() + "g)";
            buyTowerButton.Text = "Buy tower (-" + prices[2].ToString() + "g)";
            upgradeButton.Text = "Upgrade tower" + Environment.NewLine + "(- next level * 25 g)";
            removeButton.Text = "Remove tower";

            //funds1Label.Text = $"Funds: {Player.DefaultFunds}g";
            //funds2Label.Text = $"Funds: {Player.DefaultFunds}g";
            funds1Label.Text = "Funds: -";
            funds2Label.Text = "Funds: -";
            castle1Label.Text = "Health: -";
            castle2Label.Text = "Health: -";
            statusLabel.Text = "Start a new game!";

            player1Label.BackColor = Color.Blue;
            player1Label.ForeColor = Color.White;
            player2Label.BackColor = Color.Red;

            string[] row = { "-", "-", "-" };
            fieldDataTable.Rows.Add(row);

            saveGameMenuItem.Enabled = false;
            ToggleUI(false);
        }

        #endregion

        #region Methods

        public void LoadMap(MapModel mapModel)
        {
            _model.StartWithMap(mapModel);
            GenerateBoard();
            UpdateBoard();
        }

        // Generates the buttongrid with the corresponding sizes.
        public void GenerateBoard()
        {
            // Set the exact sizes of columns, rows, and the tablelayoutpanel
            BoardLayout.Controls.Clear();
            BoardLayout.ColumnCount = _model.Board.MapWidth;
            BoardLayout.RowCount = _model.Board.MapHeight;

            BoardLayout.Width = _size * _model.Board.MapWidth;
            BoardLayout.Height = _size * _model.Board.MapHeight;

            foreach(ColumnStyle column in BoardLayout.ColumnStyles)
            {
                column.Width = _size;
            }

            foreach (RowStyle row in BoardLayout.RowStyles)
            {
                row.Height = _size;
            }

            // Init buttongrid
            _buttonGrid = new GameButton[_model.Board.MapHeight, _model.Board.MapWidth];

            for (int i = 0; i < _model.Board.MapHeight; ++i)
            {
                for (int j = 0; j < _model.Board.MapWidth; ++j)
                {
                    _buttonGrid[i, j] = new GameButton(i, j)
                    {
                        Size = new Size(_size, _size),
                        FlatStyle = FlatStyle.Flat,
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0),
                        ForeColor = Color.White,
                        BackColor = Color.FromArgb(143, 143, 143),
                        Enabled = true,
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    if (_model.Board.GetObjects(i, j) == null)
                    {
                        _model.Board.SetObjects(i, j, new List<GameObject>());
                    }

                    _buttonGrid[i, j].MouseClick += new MouseEventHandler(Field_Click);

                    // Add the buttons to the panel
                    BoardLayout.Controls.Add(_buttonGrid[i, j]);
                }
            }

            ToggleButtons(true);
        }

        public void UpdateBoard()
        {
            for (int i = 0; i < _model.Board.MapHeight; ++i)
            {
                for (int j = 0; j < _model.Board.MapWidth; ++j)
                {
                    List<GameObject> objects = _model.Board.GetObjects(i, j);

                    if (objects != null && objects.Count != 0)
                    {
                        _buttonGrid[i, j].BackgroundImage = Image.FromFile(objects[0].ImgPath);

                        // Count player units
                        int p1units = objects.Where(obj => obj.PlayerID == 0).Count();
                        int p2units = objects.Where(obj => obj.PlayerID == 1).Count();

                        if (objects[0].Type == FieldType.CASTLE || objects[0].Type == FieldType.TROOP || objects[0].Type == FieldType.CAVALRY)
                        {
                            float maxh = 100f;

                            if (objects[0].Type == FieldType.TROOP)
                                maxh = (objects[0] as Troop).MaxHP;

                            if (objects[0].Type == FieldType.CAVALRY)
                                maxh = (objects[0] as Cavalry).MaxHP;

                            int h = objects[0].Health;

                            float hfl = h / maxh;
                            _buttonGrid[i, j].BackgroundImage = ImageTransparency.ChangeOpacity(Image.FromFile(objects[0].ImgPath), hfl);
                        }
                        
                        if (objects[0].Type == FieldType.TOWER)
                        {
                            int lvl = (objects[0] as Tower).Level;
                            _buttonGrid[i, j].Text = lvl == 1 ? "I" : lvl == 2 ? "II" : "III";
                        }
                        
                        if (objects.Count > 1)
                        {
                            if(objects[0].Type == FieldType.HUT)
                            {
                                _buttonGrid[i, j].Text = (objects.Count - 1).ToString();
                            }
                            else
                            {
                                if (p1units == 0)
                                {
                                    _buttonGrid[i, j].Text = p2units.ToString();
                                }
                                else if (p2units == 0)
                                {
                                    _buttonGrid[i, j].Text = p1units.ToString();
                                }
                                else
                                {
                                    _buttonGrid[i, j].BackgroundImage = Image.FromFile("../../../images/soldier_half.png");
                                    _buttonGrid[i, j].Font = new Font("Arial", 9, FontStyle.Bold);
                                    _buttonGrid[i, j].Text = p1units.ToString() + " | " + p2units.ToString();
                                    _buttonGrid[i, j].TextAlign = ContentAlignment.MiddleCenter;
                                }
                            }
                        }
                        else if (objects[0].Type != FieldType.TOWER)
                        {
                            _buttonGrid[i, j].Text = null;
                        }
                    }
                    else
                    {
                        _buttonGrid[i, j].BackgroundImage = null;
                        _buttonGrid[i, j].Text = null;
                    }
                }
            }
        }

        public void Reset()
        {
            BoardLayout.Controls.Clear();
            funds1Label.Text = "Funds: -";
            funds2Label.Text = "Funds: -";
            castle1Label.Text = "Health: -";
            castle2Label.Text = "Health: -";
            statusLabel.Text = "Start a new game!";
            statusLabel.BackColor = Color.White;
            statusLabel.ForeColor = Color.Black;
            saveGameMenuItem.Enabled = false;
            ToggleUI(false);
        }

        public void ColorStatusLabel()
        {
            if (_model.CurrentPlayer == 0)
            {
                statusLabel.BackColor = Color.Blue;
                statusLabel.ForeColor = Color.White;
            }
            else
            {
                statusLabel.BackColor = Color.Red;
                statusLabel.ForeColor = Color.Black;
            }
        }

        public void EnableSave()
        {
            saveGameMenuItem.Enabled = true;
        }

        //Method to enable buttons after the start of the game / end of the simulation phase
        private void ToggleButtons(bool param)
        {
            cavalryButton.Enabled = param;
            troopButton.Enabled = param;
            buyTowerButton.Enabled = param;
            upgradeButton.Enabled = param;
            removeButton.Enabled = param;
            endTurnButton.Enabled = param;
        }

        public void ToggleUI(bool param)
        {
            fieldInfoLabel.Visible = param;
            fieldDataTable.Visible = param;
            splitContainer.Panel1.Enabled = param;
            statusStrip.Visible = param;

            cavalryButton.Visible = param;
            troopButton.Visible = param;
            buyTowerButton.Visible = param;
            upgradeButton.Visible = param;
            removeButton.Visible = param;
            endTurnButton.Visible = param;

            player1Label.Visible = param;
            player2Label.Visible = param;
            funds1Label.Visible = param;
            funds2Label.Visible = param;
            castle1Label.Visible = param;
            castle2Label.Visible = param;
            statusLabel.Visible = param;

            introLabel.Visible = !param;
        }

        #endregion

        #region Events

        //Event handler, if the game state changed
        private void OnFieldChanged(object sender, EventArguments.FieldChangedEventArgs e)
        {
            if (_model.State == GameState.OVER)
            {
                funds1Label.Text = "Funds: -";
                funds2Label.Text = "Funds: -";
                castle1Label.Text = "Castle: -";
                castle2Label.Text = "Castle: -";
                statusLabel.Text = e.StatusLabel;
                return;
            }

            funds1Label.Text = "Funds: " + e.Player1Gold.ToString() + "g";
            funds2Label.Text = "Funds: " + e.Player2Gold.ToString() + "g";
            castle1Label.Text = "Castle: " + e.Player1Castle.ToString() + "%";
            castle2Label.Text = "Castle: " + e.Player2Castle.ToString() + "%";
            statusLabel.Text = e.StatusLabel;
            int[] gold = { e.Player1Gold, e.Player2Gold };
            int[] prices = _model.InitializePrices();
            
            troopButton.Enabled = gold[e.CurrentPlayer] >= prices[0];
            cavalryButton.Enabled = gold[e.CurrentPlayer] >= prices[1];
            buyTowerButton.Enabled = gold[e.CurrentPlayer] >= prices[2];
            saveGameMenuItem.Enabled = e.StatusLabel != _model.AttackText;
        }

        //Event handler, if the game is over (ending with new game call)
        private void OnGameOver(object sender, EventArguments.GameOverEventArgs e)
        {
            var castle1 = e.Player1CastleIsOk;
            var castle2 = e.Player2CastleIsOk;
            if (castle1 && !castle2)
            {
                _gameTimer.Stop();
                _gameTimer.Tick -= GameTimer_Tick;
                var msgbox =
                MessageBox.Show
                (
                "The winner is Player Nr1! Congratulations!",
                "The game is over",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
                if (msgbox == DialogResult.OK)
                    Reset();
            }
            else if (!castle1 && castle2)
            {
                _gameTimer.Stop();
                _gameTimer.Tick -= GameTimer_Tick;
                var msgbox =
                MessageBox.Show
                (
                "The winner is Player Nr2! Congratulations!",
                "The game is over",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
                if (msgbox == DialogResult.OK)
                    Reset();
            }
            else
            {
                _gameTimer.Stop();
                _gameTimer.Tick -= GameTimer_Tick;
                var msgbox = 
                MessageBox.Show
                (
                "The result is draw. Start a new Game!",
                "The game is over",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
                if (msgbox == DialogResult.OK)
                    Reset();
            }          
        }

        private void OnDetailsExtended(object sender, EventArguments.DetailsExtendedEventArgs e)
        {
            fieldDataTable.Rows.Clear();

            statusLabel.Text = $"Field info shown - Player{e.CurrentPlayer + 1}'s turn";
            List<GameObject> field = e.ChosenField;

            if (field != null)
            {
                foreach (GameObject go in field)
                {
                    fieldDataTable.Rows.Add(go.ObjectInfo());
                    HealthCol.HeaderText = go.Type != FieldType.TOWER ? "Health" : "Level";
                }
            }
            else
            {
                string[] row = { "-", "-", "-" };
                fieldDataTable.Rows.Add(row);
            }
        }

        #endregion  

        #region Menu event handlers

        private void NewGame_Click(object sender, EventArgs e)
        {
            GameSelectWindow levelSelect = new GameSelectWindow(this, _model);
            levelSelect.Show();
        }

        private void SaveGame_Click(object sender, EventArgs e)
        {
            SaveGameWindow saveWindow = new SaveGameWindow(this, _model);
            saveWindow.Show();
        }

        private void LoadGame_Click(object sender, EventArgs e)
        {
            LoadGameWindow loadWindow = new LoadGameWindow(this, ref _model);
            loadWindow.Show();
        }

        private void MapEditorMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            MapEditorWindow editorWindow = new MapEditorWindow(this);
            editorWindow.Show();    
        }

        private void QuitGame_Click(object sender, EventArgs e)
        {
            var msgbox = MessageBox.Show("Are you sure you want to quit?" + Environment.NewLine + "(Unsaved progress will be lost!)", "Quit game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msgbox == DialogResult.Yes)
            {
                Close();
            }
        }

        #endregion

        #region Game event handlers

        private void TroopButton_Click(object sender, EventArgs e)
        {
            _model.Build(Pressed.TROOP);
            UpdateBoard();
        }

        private void CavalryButton_Click(object sender, EventArgs e)
        {
            _model.Build(Pressed.CAVALRY);
            UpdateBoard();
        }

        private void BuyTowerButton_Click(object sender, EventArgs e)
        {
            _model.Build(Pressed.NEWTOWER);
        }

        private void UpgradeButton_Click(object sender, EventArgs e)
        {
            _model.Build(Pressed.UPGRADE);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            _model.Build(Pressed.REMOVE);
        }

        private void EndTurnButton_Click(object sender, EventArgs e)
        {
            _model.Build(Pressed.END);
            ColorStatusLabel();

            if (_model.State == GameState.WAR)
            {
                ToggleButtons(false);
                _gameTimer = new Timer
                {
                    Interval = 1000
                };
                _gameTimer.Tick += GameTimer_Tick;
                _gameTimer.Start();
                _currentSteps = 0;
            }
        }

        private void Field_Click(object sender, MouseEventArgs e)
        {
            int x = (sender as GameButton).X;
            int y = (sender as GameButton).Y;

            _model.HandleBuyPhase(x, y);
            UpdateBoard();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (_currentSteps == _model.UnitStepsize)
            {
                _currentSteps = 0;
                _gameTimer.Stop();
                _gameTimer.Tick -= GameTimer_Tick;
                _model.CheckGameOver();
                _model.State = GameState.BUY;
                statusLabel.Text = "Building phase: Player1's turn!";
                saveGameMenuItem.Enabled = true;
                ToggleButtons(true);
            }
            else if (_model.State != GameState.OVER)
            {
                _model.Simulation();
                UpdateBoard();
                ToggleButtons(false);
                _currentSteps++;
            }
        }

        #endregion
    }

    // WinForms Button with X, Y Coordinate properties
    public class GameButton : Button
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GameButton(int x, int y) : base()
        {
            X = x;
            Y = y;
        }
    }

    // Class to change Image Transparency
    public class ImageTransparency
    {
        public static Bitmap ChangeOpacity(Image img, float opacityvalue)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();   // Releasing all resource used by graphics 
            return bmp;
        }

        // string filename = "path"; float opacityvalue = 1f;
        // ImageUtils.ImageTransparency.ChangeOpacity(Image.FromFile(filename), opacityvalue);  //calling ChangeOpacity Function 
    }
}
