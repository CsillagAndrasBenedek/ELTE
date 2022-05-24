using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TowerDefense.Model;

namespace TowerDefense.View
{
    public partial class LoadMapWindow : Form
    {
        private MapEditorWindow _gameView;
        private MapModel _model;
        private List<Button> _nameButtons;
        private Button _clickedButton;

        private string _saveSelected = null;
        private readonly string _saveLocation = "../../../savedmaps";

        public LoadMapWindow(MapEditorWindow gameView, ref MapModel model)
        {
            _gameView = gameView;
            _model = model;
            
            InitializeComponent();
            ListSavedGames();

            int vertScrollWidth = SystemInformation.VerticalScrollBarWidth;
            savedGamesList.Padding = new Padding(0, 0, vertScrollWidth, 0);

            loadBtn.Enabled = false;
            deleteBtn.Enabled = false;
        }

        private async void ListSavedGames()
        {
            string[] saveNames = await _model.GetSaveNames(_saveLocation);

            if (saveNames == null)
            {
                savedGamesList.Visible = false;
                return;
            }

            savedGamesList.Controls.Clear();
            savedGamesList.RowStyles.Clear();
            _nameButtons = new List<Button>();

            foreach (string name in saveNames)
            {
                Button nameButton = new Button();
                nameButton.Width = 190;
                nameButton.Text = name;
                nameButton.BackColor = Color.White;
                nameButton.ForeColor = Color.Black;
                nameButton.MouseClick += new MouseEventHandler(NameButton_Click);
                _nameButtons.Add(nameButton);
                savedGamesList.RowStyles.Add(new RowStyle());
                savedGamesList.Controls.Add(nameButton);
            }
        }

        private async void Load_Click(object sender, EventArgs e)
        {
            await _model.Load(_saveSelected, _saveLocation);
            _gameView.GenerateBoard();
            _gameView.UpdateBoard();
            _gameView.EnableSave();
            _gameView.ToggleStart(true);

            loadBtn.Enabled = false;
            deleteBtn.Enabled = false;
            _saveSelected = null;

            Close();
        }

        private async void Delete_Click(object sender, EventArgs e)
        {
            var msgbox = MessageBox.Show("Are you sure you want to delete this save?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            
            if (DialogResult.No == msgbox)
            {
                loadBtn.Enabled = false;
                deleteBtn.Enabled = false;
                _saveSelected = null;

                foreach (Button btn in _nameButtons)
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.Black;
                }

                return;
            }

            await _model.Delete(_saveSelected, _saveLocation);
            savedGamesList.Controls.Remove(_clickedButton);
            ListSavedGames();

            loadBtn.Enabled = false;
            deleteBtn.Enabled = false;
            _saveSelected = null;
        }

        private void NameButton_Click(object sender, MouseEventArgs e)
        {
            foreach (Button btn in _nameButtons)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
            }

            _saveSelected = (sender as Button).Text;
            (sender as Button).BackColor = Color.Blue;
            (sender as Button).ForeColor = Color.White;

            _clickedButton = sender as Button;

            loadBtn.Enabled = true;
            deleteBtn.Enabled = true;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }   
    }
}
