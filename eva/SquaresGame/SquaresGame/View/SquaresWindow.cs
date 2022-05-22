using SquaresGame.EventArguments;
using SquaresGame.Model;
using SquaresGame.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SquaresGame.View
{
    public partial class SquaresWindow : Form
    {
        
        private SquaresModel model;

        //Constructor
        public SquaresWindow()
        {
            InitializeComponent();

            model = new SquaresModel(new DataAccess());

            threeByThreeToolStripMenuItem.Click += (sender, args) => model.StartNewGame(5);
            fiveByFiveToolStripMenuItem.Click += (sender, args) => model.StartNewGame(9);
            nineByNineToolStripMenuItem.Click += (sender, args) => model.StartNewGame(17);

            // event += event handler

            model.GameStarted += onGameStarted;
            model.FieldChanged += onFieldChanged;
            model.GameOver += onGameOver;
            model.StatusStripChanged += onStatusStripChanged;

            model.StartNewGame(5);
            
        }

        //Event handler, if the points and/or player to move need to be changed
        private void onStatusStripChanged(object sender, StatusStripChangedEventArgs e)
        {
            var bluePoints = e.BluePoints;
            var redPoints = e.RedPoints;
            var playerToMove = e.PlayerMoveNext;
            playerBluePointsLabel.Text = "Blue points: " + bluePoints  ;
            playerRedPointsLabel.Text = "Red points: " + redPoints;
            if (playerToMove == 0) 
            {
                playerToMoveLabel.Text = "Next move: BLUE";
            }
            else
            {
                playerToMoveLabel.Text = "Next move: RED";
            }
        }

        //Event handler, if the game is over
        private void onGameOver(object sender, EventArguments.GameOverEventArgs e)
        {
            var bluePoint = e.BluePoint;
            var redPoint = e.RedPoint;
            if(bluePoint > redPoint)
            {
                MessageBox.Show
                (
                "The winner is the Blue Player! Congratulations!",
                "The game is over",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
            }
            else if(redPoint > bluePoint)
            {
                MessageBox.Show
                (
                "The winner is the Red Player! Congratulations!",
                "The game is over",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show
                (
                "The result is draw. Start a new Game!",
                "The game is over",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
            }
            

            model.StartNewGame(5);
        }

        //Event handler, if a field changed (change the color by calling the appropriate method)
        private void onFieldChanged(object sender, EventArguments.FieldChangedEventArgs e)
        {
            var button = buttonTableLayoutPanel.GetControlFromPosition(e.Column, e.Row) as Button;
            setButtonColor(button, e.NewState);
        }

        ////Event handler, in case new game started
        private void onGameStarted(object sender, EventArguments.GameStartedEventArgs e)
        {
            var size = e.BoardSize;
            var board = e.Board;


            buttonTableLayoutPanel.RowCount = size +1;
            buttonTableLayoutPanel.ColumnCount = size +1;
            buttonTableLayoutPanel.Controls.Clear();

            buttonTableLayoutPanel.RowStyles.Clear();
            buttonTableLayoutPanel.ColumnStyles.Clear();

            for (int i = 0; i < size; i++)
            {
                buttonTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 1/ Convert.ToSingle(size)));
                buttonTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1 / Convert.ToSingle(size)));
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var button = new Button();
                    button.AutoSize = true;
                    button.Dock = DockStyle.Fill;
                    if ((i+j) % 2 == 1 ) { button.Click += onGridButtonClicked; }
                    setButtonColor(button, board[i, j]);
                    buttonTableLayoutPanel.Controls.Add(button, j, i);
                }
            }
        }

        ////Event handler, if one of the fieldbuttons have been clicked (start the overview process )
        private void onGridButtonClicked(Object sender, EventArgs e)
        {
            var button = sender as Button;
            var position = buttonTableLayoutPanel.GetPositionFromControl(button);
            model.fieldClicked(position.Row, position.Column);
            button.Click -= onGridButtonClicked;
        }

        //Method to change the color of the field
        private void setButtonColor(Button b, FieldState state)
        {
            switch (state)
            {
                case FieldState.Grey:
                    b.BackColor = Color.Gray;
                    break;
                case FieldState.Empty:
                    b.BackColor= Color.White;
                    break;
                case FieldState.Point:
                    b.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.PointImg));
                    b.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case FieldState.FullBlue:
                    b.BackColor = Color.Blue;
                    break;
                case FieldState.FullRed:
                    b.BackColor = Color.Red;
                    break;
                case FieldState.UpDownBlue:
                    b.BackColor = default;
                    b.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.upDownBlueImg));
                    b.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case FieldState.UpDownRed:
                    b.BackColor = default;
                    b.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.upDownRedImg));
                    b.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case FieldState.LeftRightBlue:
                    b.BackColor = default;
                    b.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.leftRightBlueImg));
                    b.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case FieldState.LeftRightRed:
                    b.BackColor = default;
                    b.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.leftRightRedImg));
                    b.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                default:
                    break;
            }
        }

        //Event handler if <File> -> <Save> menupoint is clicked
        private void onSaveGameMenuItemClicked(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                model.saveGame(path);
            } 
        }

        //Event handler if <File> -> <Load> menupoint is clicked
        private void onLoadGameMenuItemClicked(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                model.loadGame(path);
            }
        }
    }
}
