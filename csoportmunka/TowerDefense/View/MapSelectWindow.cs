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
    public partial class MapSelectWindow : Form
    {
        private MapModel _model;
        private MapEditorWindow _gameView;

        public MapSelectWindow(MapEditorWindow gameView, MapModel model)
        {
            _gameView = gameView;
            _model = model;
            InitializeComponent();
        }


        // Clicking on the Start button will call the model's StartNewGame method
        // with the map size. GenerateBoard will generate the buttongrid in the main form
        private void StartBtn_Click(object sender, EventArgs e)
        {
            _model.StartNewMap(Decimal.ToInt32(rowUpDown.Value), Decimal.ToInt32(columnUpDown.Value));
            _gameView.GenerateBoard();
            _gameView.UpdateBoard();
            _gameView.EnableButtons();
            _gameView.ToggleStart(false);
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
