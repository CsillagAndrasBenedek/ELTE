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
    public partial class SaveGameWindow : Form
    {
        private GameView _gameView;
        private GameModel _model;

        private readonly string _saveLocation = "../../../savedgames";

        public SaveGameWindow(GameView gameView, GameModel model)
        {
            _gameView = gameView;
            _model = model;
            InitializeComponent();
            saveBtn.Enabled = false;
        }

        private async void Save_Click(object sender, EventArgs e)
        {
            string name = saveNameInput.Text;
            bool overwrite = false;

            string[] savedNames = await _model.GetSaveNames(_saveLocation);

            if (Array.Exists(savedNames, e => e == name))
            {
                var msgbox = MessageBox.Show("Save with this name already exists." + Environment.NewLine + "Overwrite?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (DialogResult.No == msgbox)
                {
                    return;
                }

                overwrite = true;
            }

            await _model.Save(name, _saveLocation, overwrite);
            Close();
        }

        private void SaveName_TextChanged(object sender, EventArgs e)
        {
            if (saveNameInput.Text == "")
            {
                saveBtn.Enabled = false;
            }
            else
            {
                saveBtn.Enabled = true;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        } 
    }
}
