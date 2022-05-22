using Microsoft.Win32;
using SquaresGameWpf.Model;
using SquaresGameWpf.Persistence;
using SquaresGameWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SquaresGameWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow _mainWindow;
        private SquaresViewModel _viewModel;
        private SquaresModel _model;
        public App()
        {
            Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            _mainWindow = new MainWindow();
            _model = new SquaresModel(new DataAccess());
            _model.GameOver += OnGameOver;
            _viewModel = new SquaresViewModel(_model);
            _viewModel.LoadGame += new EventHandler(ViewModel_LoadGame);
            _viewModel.SaveGame += new EventHandler(ViewModel_SaveGame);
            _mainWindow.DataContext = _viewModel;
            _mainWindow.Show();
        }

        private void OnGameOver(object? sender, EventArguments.GameOverEventArgs e)
        {
            if(e.BluePoint > e.RedPoint)
            {
                MessageBox.Show("The winner is the Blue Player! Congratulations!", "Squares Game");
            }
            else if(e.BluePoint < e.RedPoint)
            {
                MessageBox.Show("The winner is the Red Player! Congratulations!", "Squares Game");
            }
            else
            {
                MessageBox.Show("The result is draw. Start a new Game!", "Squares Game");
            }
            _model.StartNewGame(5);
            
        }

        private void ViewModel_LoadGame(object sender, System.EventArgs e)
        {

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog(); // dialógusablak
                openFileDialog.Title = "Squares Game tábla betöltése";
                if (openFileDialog.ShowDialog() == true)
                {
                    // játék betöltése
                    _model.loadGame(openFileDialog.FileName);

                }
            }
            catch (DataAccessException)
            {
                MessageBox.Show("A fájl betöltése sikertelen!", "Squares Game", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void ViewModel_SaveGame(object sender, EventArgs e)
        {
            

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog(); // dialógablak
                saveFileDialog.Title = "Squares game tábla betöltése";
                if (saveFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        // játéktábla mentése
                        _model.saveGame(saveFileDialog.FileName);
                    }
                    catch (DataAccessException)
                    {
                        MessageBox.Show("Játék mentése sikertelen!" + Environment.NewLine + "Hibás az elérési út, vagy a könyvtár nem írható.", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("A fájl mentése sikertelen!", "Squares Game", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
