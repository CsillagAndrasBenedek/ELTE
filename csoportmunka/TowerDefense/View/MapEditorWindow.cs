using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TowerDefense.EventArguments;
using TowerDefense.GameObjects;
using TowerDefense.Model;
using TowerDefense.Persistence;

namespace TowerDefense.View
{
    public partial class MapEditorWindow : Form
    {
        private readonly GameView _gameView;
        private MapModel _model;
        private GameButton[,] _buttonGrid;
        private readonly int _size = 40;

        public MapEditorWindow(GameView gameView)
        {
            _gameView = gameView; 
            _model = new MapModel(new DataAccess());
            _model.MapFieldChanged += OnFieldChanged;
            _model.MapCorrect += OnMapCorrect;
            InitializeComponent();
            startGameMenuItem.Enabled = false;
        }

        private void OnMapCorrect(object sender, EventArgs e)
        {
            SaveMapWindow saveWindow = new SaveMapWindow(this, _model);
            saveWindow.Show();
        }

        private void OnFieldChanged(object sender, MapFieldChangedEventArgs e)
        {
            statusLabel.Text = e.StatusLabel;
            castle1Button.Enabled = !e.CastlesExist[0];
            castle2Button.Enabled = !e.CastlesExist[1];
            hut1Button.Enabled = e.HutsLeft[0] != 0;
            hut2Button.Enabled = e.HutsLeft[1] != 0;
            saveMapMenuItem.Enabled = e.CastlesExist[0] && e.CastlesExist[1] && e.HutsLeft[0] == 0 && e.HutsLeft[1] == 0 && e.ObstaclesPlaced >= Obstacle.MinObstacles;
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            Close();
            _gameView.ToggleUI(true);
            _gameView.Show();
            _gameView.EnableSave();
            _gameView.LoadMap(_model);
            _gameView.ColorStatusLabel();
        }

        private void NewMap_Click(object sender, EventArgs e)
        {
            MapSelectWindow levelSelect = new MapSelectWindow(this, _model);
            levelSelect.Show();
        }

        private void ObstacleButton_Click(object sender, EventArgs e)
        {
            _model.Build(MapPressed.OBSTACLE);
            UpdateBoard();
        }

        private void DeleteFieldButton_Click(object sender, EventArgs e)
        {
            _model.Build(MapPressed.DELETE);
            UpdateBoard();
        }

        private void Hut1Button_Click(object sender, EventArgs e)
        {
            _model.Build(MapPressed.HUT1);
            UpdateBoard();
        }

        private void Hut2Button_Click(object sender, EventArgs e)
        {
            _model.Build(MapPressed.HUT2);
            UpdateBoard();
        }

        private void Castle1Button_Click(object sender, EventArgs e)
        {
            _model.Build(MapPressed.CASTLE1);
            UpdateBoard();
        }

        private void Castle2Button_Click(object sender, EventArgs e)
        {
            _model.Build(MapPressed.CASTLE2);
            UpdateBoard();
        }

        private void QuitEditor_Click(object sender, EventArgs e)
        {
            var msgbox = MessageBox.Show("Are you sure you want to quit?" + Environment.NewLine + "(Unsaved progress will be lost!)", "Quit game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msgbox == DialogResult.Yes)
            {
                Close();
                _gameView.Show();
            }
        }

        private void SaveMap_Click(object sender, EventArgs e)
        {
            _model.CheckPath();
        }

        private void LoadMap_Click(object sender, EventArgs e)
        {
            LoadMapWindow loadWindow = new LoadMapWindow(this, ref _model);
            loadWindow.Show();
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
                        int p1units = 0, p2units = 0;
                        foreach (GameObject obj in objects)
                        {
                            if (obj.Type == FieldType.TROOP || obj.Type == FieldType.CAVALRY)
                            {
                                _ = obj.PlayerID == 0 ? p1units++ : p2units++;
                            }
                        }

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
                            _buttonGrid[i, j].Text = (objects[0] as Tower).Level.ToString();
                        }

                        if (objects.Count > 1)
                        {
                            if (objects[0].Type == FieldType.HUT)
                            {
                                _buttonGrid[i, j].Text = (objects.Count - 1).ToString();
                            }
                            else
                            {
                                _buttonGrid[i, j].Text = p1units.ToString() + Environment.NewLine + p2units.ToString();
                            }
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

        // Generates the buttongrid with the corresponding sizes.
        public void GenerateBoard()
        {
            // Set the exact sizes of columns, rows, and the tablelayoutpanel
            BoardLayout.Controls.Clear();
            BoardLayout.ColumnCount = _model.Board.MapWidth;
            BoardLayout.RowCount = _model.Board.MapHeight;

            BoardLayout.Width = _size * _model.Board.MapWidth;
            BoardLayout.Height = _size * _model.Board.MapHeight;

            foreach (ColumnStyle column in BoardLayout.ColumnStyles)
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
                        Font = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point)
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
        }

        //Method to enable buttons after the start of the game / end of the simulation phase
        public void EnableButtons()
        {
            hut1Button.Enabled = true;
            castle1Button.Enabled = true;
            castle2Button.Enabled = true;
            hut2Button.Enabled = true;
            obstacleButton.Enabled = true;
            deleteFieldButton.Enabled = true;
        }

        public void ToggleStart(bool param)
        {
            startGameMenuItem.Enabled = param;
        }

        public void EnableSave()
        {
            saveMapMenuItem.Enabled = true;
        }

        private void Field_Click(object sender, MouseEventArgs e)
        {
            int x = (sender as GameButton).X;
            int y = (sender as GameButton).Y;

            _model.HandleBuyPhase(x, y);
            UpdateBoard();
        }

        private void Editor_Closing(object sender, FormClosingEventArgs e)
        {
            _gameView.Show();
        }
    }
}
