using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.EventArguments;
using TowerDefense.GameObjects;
using TowerDefense.Persistence;

namespace TowerDefense.Model
{
    public enum MapPressed { CASTLE1, CASTLE2, HUT1, HUT2, OBSTACLE, DELETE, NONE }

    public class MapModel
    {
        #region Private fields

        private readonly IDataAccess _dataAccess;
        private GameBoard _board;  
        private Castle[] _castles;
        private Hut[] _huts;
        private List<Obstacle> _obstacles;
        private int _currentPlayer;
        private int _obstaclesPlaced;
        private bool[] _castlesExist;
        private int[] _hutsLeft;    

        #endregion

        #region Constants

        private const int PLAYER_NUM = 2;
        private const int HUT_NUM = 2;
        private const int MIN_OBSTACLES = 2;
        private const int MIN_DISTANCE = 1;

        #endregion

        #region Properties

        public GameBoard Board { get => _board; set => _board = value; }
        public Castle[] Castles { get => _castles; set => _castles = value; }
        public Hut[] Huts { get => _huts; set => _huts = value; }
        public List<Obstacle> Obstacles { get => _obstacles; set => _obstacles = value; }
        public int ObstaclesPlaced { get => _obstaclesPlaced; set => _obstaclesPlaced = value; }
        public MapPressed CurrentPressed { get; set; }
        public bool[] CastlesExist { get => _castlesExist; }
        public int[] HutsLeft { get => _hutsLeft; }
        public int PlayerNum { get => PLAYER_NUM; }
        public int HutNum { get => HUT_NUM; }
        public int MinObstacles { get => MIN_OBSTACLES; }

        #endregion

        #region Events

        public event EventHandler<MapFieldChangedEventArgs> MapFieldChanged;
        public event EventHandler<EventArgs> MapCorrect;

        #endregion

        #region Constructor

        public MapModel(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        #endregion

        #region Initialization methods

        //Creates an empty map with the given size and initializes the necessary arrays
        public void StartNewMap(int row, int column)
        {
            _board = new GameBoard(row, column);

            // Initializing the castles
            _castles = new Castle[PLAYER_NUM];
            _castlesExist = new bool[PLAYER_NUM];
            for (int j = 0; j < PLAYER_NUM; j++)
            {
                _castlesExist[j] = false;
            }

            // Initializing the huts
            _huts = new Hut[PLAYER_NUM * HUT_NUM];
            _hutsLeft = new int[PLAYER_NUM];

            for (int k = 0; k < PLAYER_NUM; k++)
            {
                _hutsLeft[k] = HUT_NUM;
            }

            // Initializing the obstacles
            _obstaclesPlaced = 0;
            _obstacles = new List<Obstacle>();
            CurrentPressed = MapPressed.NONE;

            MapFieldChanged?.Invoke(this, new MapFieldChangedEventArgs(Board, "Map created! Place the buildings!", _castlesExist, _hutsLeft, _obstaclesPlaced));
        }

        //Checks whether a path exists between each hut and the opponent's castle
        public void CheckPath()
        {
            bool pathCorrect = true;

            int l = 0;
            while (pathCorrect && l < _huts.Length)
            {
                Hut hut = _huts[l];
                PathFinder pf = new PathFinder(_board, hut.XCor, hut.YCor, _castles[(hut.PlayerID + 1) % PLAYER_NUM].XCor, _castles[(hut.PlayerID + 1) % PLAYER_NUM].YCor);
                if (pf.GetShortestPath().Count == 0) pathCorrect = false;
                l++;
            }

            if (!pathCorrect) MapFieldChanged?.Invoke(this, new MapFieldChangedEventArgs(Board, "You can't block the path between the huts and the opponent's castle!", _castlesExist, _hutsLeft, _obstaclesPlaced));
            else MapCorrect?.Invoke(this, new EventArgs());
        }

        #endregion

        #region Persistence methods

        public async Task Save(string name, string location, bool overwrite)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access provided.");

            List<GameObject>[,] board = new List<GameObject>[_board.MapHeight, _board.MapWidth];

            for (int i = 0; i < _board.MapHeight; ++i)
            {
                for (int j = 0; j < _board.MapWidth; ++j)
                {
                    board[i, j] = _board.GetObjects(i, j);
                }
            }

            Hut[] huts = new Hut[_huts.Length];
            for (int i = 0; i < huts.Length; ++i)
            {
                huts[i] = _huts[i];
            }

            Obstacle[] obstacles = new Obstacle[_obstaclesPlaced];
            for (int i = 0; i < _obstaclesPlaced; ++i)
            {
                obstacles[i] = _obstacles[i];
            }

            SaveData data = new SaveData()
            {
                Board = board,
                Huts = huts,
                Castles = _castles,
                MapHeight = _board.MapHeight,
                MapWidth = _board.MapWidth,
                CurrentPlayer = _currentPlayer,
                SaveName = name,
                Obstacles = obstacles,
                ObstaclesPlaced = _obstaclesPlaced
            };

            await _dataAccess.Save(data, location, overwrite);
        }

        public async Task Load(string name, string location)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access provided.");

            SaveData data = await _dataAccess.Load(name, location);

            _board = new GameBoard(data.MapHeight, data.MapWidth);

            for (int i = 0; i < data.MapHeight; ++i)
            {
                for (int j = 0; j < data.MapWidth; ++j)
                {
                    _board.SetObjects(i, j, data.Board[i, j]);
                }
            }

            _obstaclesPlaced = data.ObstaclesPlaced;
            _obstacles = new List<Obstacle>();

            for (int i = 0; i < _obstaclesPlaced; ++i)
            {
                _obstacles.Add(data.Obstacles[i]);
            }

            _huts = new Hut[HUT_NUM * PLAYER_NUM];

            for (int i = 0; i < _huts.Length; ++i)
            {
                _huts[i] = data.Huts[i];
            }

            _hutsLeft = new int[PLAYER_NUM];

            for (int i = 0; i < PLAYER_NUM; ++i)
            {
                _hutsLeft[i] = 0;
            }

            _castles = data.Castles;
            _castlesExist = new bool[PLAYER_NUM];

            for (int j = 0; j < PLAYER_NUM; ++j)
            {
                _castlesExist[j] = true;
            }

            _currentPlayer = data.CurrentPlayer;
            CurrentPressed = MapPressed.NONE;

            MapFieldChanged?.Invoke(this, new MapFieldChangedEventArgs(Board, $"Map loaded successfully!", _castlesExist, _hutsLeft, _obstaclesPlaced));
        }

        public async Task Delete(string name, string location)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access provided.");

            await _dataAccess.Delete(name, location);
        }

        public async Task<string[]> GetSaveNames(string location)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access provided.");

            return await _dataAccess.GetSaveNames(location);
        }

        #endregion

        #region Editor methods

        //Assigns the correct values to the CurrentPressed and _currentPlayer fields based on the pressed button, then updates the statusbar
        public void Build(MapPressed pressed)
        {
            string status = "";

            if (pressed == MapPressed.CASTLE1)
            {
                if (CurrentPressed != MapPressed.CASTLE1)
                {
                    status = $"Choose a field on the map for Player1's castle or press the 'Castle (P1)' button again to cancel the placement.";
                    CurrentPressed = MapPressed.CASTLE1;
                    _currentPlayer = 0;
                }
                else
                {
                    status = $"Placement cancelled";
                    CurrentPressed = MapPressed.NONE;
                }

            }
            else if (pressed == MapPressed.CASTLE2)
            {
                if (CurrentPressed != MapPressed.CASTLE2)
                {
                    status = $"Choose a field on the map for Player2's castle or press the 'Castle (P2)' button again to cancel the placement.";
                    CurrentPressed = MapPressed.CASTLE2;
                    _currentPlayer = 1;
                }
                else
                {
                    status = $"Placement cancelled";
                    CurrentPressed = MapPressed.NONE;
                }
            }
            else if (pressed == MapPressed.HUT1)
            {
                if (CurrentPressed != MapPressed.HUT1)
                {
                    status = $"Choose a field on the map for Player1's hut or press the 'Hut (P1)' button again to cancel the placement.";
                    CurrentPressed = MapPressed.HUT1;
                    _currentPlayer = 0;
                }
                else
                {
                    status = $"Placement cancelled";
                    CurrentPressed = MapPressed.NONE;
                }
            }
            else if (pressed == MapPressed.HUT2)
            {
                if (CurrentPressed != MapPressed.HUT2)
                {
                    status = $"Choose a field on the map for Player2's hut or press the 'Hut (P2)' button again to cancel the placement.";
                    CurrentPressed = MapPressed.HUT2;
                    _currentPlayer = 1;
                }
                else
                {
                    status = $"Placement cancelled";
                    CurrentPressed = MapPressed.NONE;
                }
            }
            else if (pressed == MapPressed.OBSTACLE)
            {
                if (CurrentPressed != MapPressed.OBSTACLE)
                {
                    status = $"Choose a field on the map for a mountain or press the 'Mountain' button again to cancel the placement.";
                    CurrentPressed = MapPressed.OBSTACLE;
                }
                else
                {
                    status = $"Placement cancelled";
                    CurrentPressed = MapPressed.NONE;
                }
            }
            else if (pressed == MapPressed.DELETE)
            {
                if (CurrentPressed != MapPressed.DELETE)
                {
                    status = $"Choose a building on the map you would like to remove, or press the 'Delete field' button again to cancel the deletion.";
                    CurrentPressed = MapPressed.DELETE;
                }
                else
                {
                    status = $"Deletion cancelled";
                    CurrentPressed = MapPressed.NONE;
                }
            }

            MapFieldChanged?.Invoke(this, new MapFieldChangedEventArgs(Board, status, _castlesExist, _hutsLeft, _obstaclesPlaced));
        }


        //Creates or deletes an object on the pressed field if it is allowed
        public void HandleBuyPhase(int x, int y)
        {
            List<GameObject> field = _board.GetObjects(x, y);
            GameObject obj;

            string message = "";
            if (CurrentPressed == MapPressed.NONE)
            {
                if (field.Count != 0)
                { 
                    obj = field[0];
                    message = $"{obj.Type}";
                }
            }
            else if (CurrentPressed == MapPressed.CASTLE1 || CurrentPressed == MapPressed.CASTLE2)
            {
                message = Create(x, y, "castle");
            }
            else if (CurrentPressed == MapPressed.HUT1 || CurrentPressed == MapPressed.HUT2)
            {
                message = Create(x, y, "hut");
            }
            else if (CurrentPressed == MapPressed.DELETE)
            {
                if (field.Count == 0) message = "There is no removeable element on this field, choose another one!";
                else
                {
                    obj = field[0];
                    if (obj.Type == FieldType.HUT)
                    {
                        _hutsLeft[obj.PlayerID] += 1;
                    }
                    else if (obj.Type == FieldType.CASTLE)
                    {
                        _castlesExist[obj.PlayerID] = false;
                    }
                    else if (obj.Type == FieldType.MOUNTAIN)
                    {
                        _obstaclesPlaced -= 1;
                        _obstacles.Remove((Obstacle)obj);
                    }

                    field.Clear();

                    _board.SetObjects(x, y, field);

                    message = $"Element removed";
                    CurrentPressed = MapPressed.NONE;
                }
            }
            else if (CurrentPressed == MapPressed.OBSTACLE)
            {
                message = Create(x, y, "mountain");
            }

            MapFieldChanged?.Invoke(this, new MapFieldChangedEventArgs(_board, message, _castlesExist, _hutsLeft, _obstaclesPlaced));
        }

        //Creates a new object of the given type at the given position
        public string Create(int x, int y, string type)
        {
            FieldType ftype = FieldType.CASTLE;
            switch (type)
            {
                case "hut":
                    ftype = FieldType.HUT;
                    break;
                case "castle":
                    ftype= FieldType.CASTLE;
                    break;
                case "mountain":
                    ftype = FieldType.MOUNTAIN;
                    break;
            }
            
            List<GameObject> field = _board.GetObjects(x, y);
            GameObject obj;
            string message;

            if (field.Count != 0) return "You can't place a building on an occupied field, choose an empty one!";
            if (!CheckDistance(x, y, ftype)) return "You can't place anything next to a castle!";

            if (type != "mountain")
            {
                //Creating a castle or a hut using the factory
                AbstractGameObjectFactory factory = FactoryProducer.GetFactory(true);
                string playerText = "Player" + (_currentPlayer + 1).ToString();
                obj = factory.GetGameObject($"{type}", _currentPlayer, x, y);
                message = $"{playerText}'s {type} built!";

                //Initializing the correct array elements 
                if(type == "castle")
                {
                    _castles[_currentPlayer] = (obj as Castle);
                    _castlesExist[_currentPlayer] = true;
                }
                else
                {
                    _huts[HUT_NUM - _hutsLeft[_currentPlayer] + _currentPlayer * HUT_NUM] = (obj as Hut);
                    _hutsLeft[_currentPlayer] -= 1;
                }
            }
            else
            {
                obj = new Obstacle(x, y);
                message = "Mountain placed!";
                _obstaclesPlaced += 1;
                _obstacles.Add((Obstacle)obj);
            }
            
            //Adding the new object to the board
            field.Add(obj);
            _board.SetObjects(x, y, field);
            CurrentPressed = MapPressed.NONE;

            return message;
        }

        //Checks whether placing the object on the given field violates the distance guidelines
        public bool CheckDistance(int x, int y, FieldType type)
        {   
            bool correct = true;
            int i = x > MIN_DISTANCE ? x - MIN_DISTANCE : 0;

            //Looping through the chosen field's MIN_DISTANCE radious
            while (correct && i < _board.MapHeight && i <= x + MIN_DISTANCE)
            {
                int j = y > MIN_DISTANCE ? y - MIN_DISTANCE : 0;
                while (correct && j < _board.MapWidth && j <= y + MIN_DISTANCE)
                {
                    List<GameObject> field = _board.GetObjects(i, j);
                    if (type != FieldType.CASTLE)
                    {
                        //If we want to place a tower or obstacle, we only have to watch out for nearby castles
                        if (field.Count != 0 && field[0].Type == FieldType.CASTLE) { correct = false; }
                    }
                    else
                    {
                        //If we want to place a castle, nothing can be around it
                        if (field.Count != 0) { correct = false; }
                    }
                    
                    j++;
                }
                i++;
            }
            return correct;
        }

        #endregion
    }
}
