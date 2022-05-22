using SquaresGameWpf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresGameWpf.ViewModel
{
    public class SquaresViewModel:ViewModelBase
    {
        private SquaresModel _model;
        private int _size;
        private int _bluePoints;
        private int _redPoints;
        private string _onPlayer;


        public int Size { get => _size; set { _size = value; OnPropertyChanged(); } }
        public int BluePoints { get => _bluePoints; set { _bluePoints = value; OnPropertyChanged(); } }
        public int RedPoints { get => _redPoints; set { _redPoints = value; OnPropertyChanged(); } }
        public string OnPlayer { get => _onPlayer; set { _onPlayer = value; OnPropertyChanged(); } }


        public ObservableCollection<StatesViewModel> States { get; set; }
        public DelegateCommand StartNewGameCommand { get; set; } 
        public DelegateCommand LoadGameCommand { get; private set; }
        public DelegateCommand SaveGameCommand { get; private set; }

        public event EventHandler LoadGame;
        public event EventHandler SaveGame;

        public SquaresViewModel(SquaresModel model)
        {
            _model = model;
            _model.GameStarted += OnGameStarted;
            _model.FieldChanged += OnFieldChanged;
            _model.StatusStripChanged += OnStatusBarChanged;
            States = new ObservableCollection<StatesViewModel>();
            StartNewGameCommand = new DelegateCommand(n => _model.StartNewGame(Convert.ToInt32(n)));
            LoadGameCommand = new DelegateCommand(param => OnLoadGame());
            SaveGameCommand = new DelegateCommand(param => OnSaveGame());
            _model.StartNewGame(5);
        }

        private void OnStatusBarChanged(object? sender, EventArguments.StatusStripChangedEventArgs e)
        {
            var ptm = e.PlayerMoveNext;
            var rp = e.RedPoints;
            var bp = e.BluePoints;
            BluePoints = bp;
            RedPoints = rp;
            if(ptm == 0) { OnPlayer = "Next move: BLUE"; }
            else { OnPlayer = "Next move: RED"; }
        }

        private void OnFieldChanged(object? sender, EventArguments.FieldChangedEventArgs e)
        {
            var field = States.FirstOrDefault(field => field.RowIndex == e.Row && field.ColumnIndex == e.Column);
            if (field is not null)
            {
                field.Color = CalculateStateColor(e.NewState);
                

            }
        }

        private void OnGameStarted(object? sender, EventArguments.GameStartedEventArgs e)
        {
            Size = e.BoardSize;
            BluePoints = _model.getPlayerBluePoints();
            RedPoints = _model.getPlayerRedPoints();
            if(_model.getPlayerToMove() == 0) { OnPlayer = "Next move: BLUE"; }
            else { OnPlayer = "Next move: RED"; }
            States.Clear();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    var state = new StatesViewModel(CalculateStateColor(e.Board[i, j]),  i, j);
                    if((i + j) % 2 == 1)
                    {
                        state.FieldPressed += OnFieldPressed;
                    }
                    States.Add(state);
                }
            }
        }

        private void OnFieldPressed(object? sender, EventArgs e)
        {
            var state = sender as StatesViewModel;
            if(state is not null)
            {
                _model.fieldClicked(state.RowIndex, state.ColumnIndex);
                state.FieldPressed -= OnFieldPressed;
            }
        }

        private string CalculateStateColor(FieldState state)
        {
            switch (state)
            {
                case FieldState.Grey:
                    return "C:\\Users\\Andris\\source\\repos\\SquaresGameWpf\\SquaresGameWpf\\Resources\\grey.png";
                case FieldState.Empty:
                    return "C:\\Users\\Andris\\source\\repos\\SquaresGameWpf\\SquaresGameWpf\\Resources\\empty.png";
                case FieldState.Point:
                    return "C:\\Users\\Andris\\source\\repos\\SquaresGameWpf\\SquaresGameWpf\\Resources\\point.png";
                case FieldState.FullBlue:
                    return "C:\\Users\\Andris\\source\\repos\\SquaresGameWpf\\SquaresGameWpf\\Resources\\fullBlue.png";
                case FieldState.FullRed:
                    return "C:\\Users\\Andris\\source\\repos\\SquaresGameWpf\\SquaresGameWpf\\Resources\\fullRed.png";
                case FieldState.UpDownBlue:
                    return "C:\\Users\\Andris\\source\\repos\\SquaresGameWpf\\SquaresGameWpf\\Resources\\upDownBlue.png";
                case FieldState.UpDownRed:
                    return "C:\\Users\\Andris\\source\\repos\\SquaresGameWpf\\SquaresGameWpf\\Resources\\upDownRed.png";
                case FieldState.LeftRightBlue:
                    return "C:\\Users\\Andris\\source\\repos\\SquaresGameWpf\\SquaresGameWpf\\Resources\\leftRightBlue.png";
                case FieldState.LeftRightRed:
                    return "C:\\Users\\Andris\\source\\repos\\SquaresGameWpf\\SquaresGameWpf\\Resources\\leftRightRed.png";
                default:
                    return "C:\\Users\\Andris\\source\\repos\\SquaresGameWpf\\SquaresGameWpf\\Resources\\empty.png";
            }
        }


        private void OnLoadGame()
        {
            if (LoadGame != null)
                LoadGame(this, EventArgs.Empty);
        }

        private void OnSaveGame()
        {
            if (SaveGame != null)
                SaveGame(this, EventArgs.Empty);
        }

    }
}
