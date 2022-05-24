using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TowerDefense.Model;

namespace TowerDefense.View
{
    // Separate form for level selection
    public partial class GameSelectWindow : Form
    {
        private GameModel _model;
        private GameView _gameView;
        private MapSize _mapSize = MapSize.SMALL;

        public GameSelectWindow(GameView gameView, GameModel model)
        {
            _gameView = gameView;
            _model = model;
            InitializeComponent();
        }

        // Set the map size when clicking on radio buttons
        private void SmallLevelBtn_Changed(object sender, EventArgs e)
        {
            if (SmallLevelBtn.Checked)
                _mapSize = MapSize.SMALL;
        }

        private void MediumLevelBtn_Changed(object sender, EventArgs e)
        {
            if (MediumLevelBtn.Checked)
                _mapSize = MapSize.MEDIUM;
        }

        private void LargeLevelBtn_Changed(object sender, EventArgs e)
        {
            if (LargeLevelBtn.Checked)
                _mapSize = MapSize.LARGE;
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            _model.StartNewGame(_mapSize);
            _gameView.GenerateBoard();
            _gameView.UpdateBoard();
            _gameView.ColorStatusLabel();
            _gameView.EnableSave();
            _gameView.ToggleUI(true);
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
