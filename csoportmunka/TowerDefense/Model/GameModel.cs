using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowerDefense.EventArguments;
using TowerDefense.GameObjects;
using TowerDefense.Persistence;

namespace TowerDefense.Model
{
    #region Enumeration types
    public enum MapSize { SMALL, MEDIUM, LARGE }
    public enum Pressed { NEWTOWER, TROOP, CAVALRY, UPGRADE, REMOVE, END, NONE }
    public enum GameState { BUY, WAR, OVER }

    #endregion

    //Data type for storing a pair of integers--> (x,y) 
    public class Position
    {
        private int _xCor, _yCor;
        public Position(int x, int y)
        {
            _xCor = x;
            _yCor = y;
        }

        public int X
        {
            get => _xCor;
            set => _xCor = value;
        }
        public int Y
        {
            get => _yCor;
            set => _yCor = value;
        }
    }
    public class GameModel
    {
        #region Private fields

        private readonly IDataAccess _dataAccess;
        private GameBoard _board;
        private Player[] _players;
        private Castle[] _castles;
        private Hut[] _huts;
        private List<Tower>[] _towers;
        private List<Unit> _units;
        private Obstacle[] _obstacles;

        private int _currentPlayer;
        private string _status;
        private int _obstaclesPlaced;
        private readonly int _unitStepsize = 3;

        #endregion

        #region Constants

        private const int PLAYER_NUM = 2;
        private const int HUT_NUM = 2;
        private const int KILL_REWARD = 20;  //Gold gained after killing an enemy unit

        #endregion

        #region Properties

        public GameBoard Board { get => _board; set => _board = value; }
        public Player[] Players { get => _players; set => _players = value; }
        public Castle[] Castles { get => _castles; set => _castles = value; }
        public Hut[] Huts { get => _huts; set => _huts = value; }
        public List<Tower>[] Towers { get => _towers; set => _towers = value; }
        public List<Unit> Units { get => _units; set => _units = value; }
        public Obstacle[] Obstacles { get => _obstacles; set => _obstacles = value; }

        public GameState State { get; set; }
        public Pressed CurrentPressed { get; set; }
        public int CurrentPlayer { get => _currentPlayer; set => _currentPlayer = value; }
        public string Status { get => _status; set => _status = value; }

        public int ObstaclesPlaced { get => _obstaclesPlaced; set => _obstaclesPlaced = value; }
        public int UnitStepsize { get => _unitStepsize; }
        public string AttackText { get => "Units are attacking..."; }

        #endregion

        #region Events

        public event EventHandler<GameOverEventArgs> GameOver;
        public event EventHandler<FieldChangedEventArgs> FieldChanged;
        public event EventHandler<DetailsExtendedEventArgs> DetailsExtended;

        #endregion

        #region Constructors

        public GameModel(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _board = new GameBoard(10, 11); // default
        }

        #endregion

        #region Initialization methods

        public void InitModel(SaveData data)
        {
            Board.MapHeight = data.MapHeight;
            Board.MapWidth = data.MapWidth;

            Board = new GameBoard(data.MapHeight, data.MapWidth);
            for (int i = 0; i < data.MapHeight; ++i)
                for (int j = 0; j < data.MapWidth; ++j)
                    Board.SetObjects(i, j, data.Board[i, j]);

            Castles = new Castle[data.Castles.Length];
            for (int i = 0; i < data.Castles.Length; ++i)
            {
                Castles[i] = (Castle)data.Castles[i];
                Board.SetObjects(Castles[i].XCor, Castles[i].YCor, new List<GameObject>() { Castles[i] });
            }

            Players = new Player[data.Players.Length];
            for (int i = 0; i < data.Players.Length; ++i)
                Players[i] = data.Players[i];

            Huts = new Hut[data.Huts.Length];
            for (int i = 0; i < data.Huts.Length; ++i)
            {
                Huts[i] = data.Huts[i];

                List<GameObject> objects = new List<GameObject>();
                objects.Add(data.Huts[i]);

                foreach (var unit in data.Units)
                {
                    if (unit.XCor == data.Huts[i].XCor && unit.YCor == data.Huts[i].YCor)
                    {
                        objects.Add(unit);
                    }
                }

                Board.SetObjects(Huts[i].XCor, Huts[i].YCor, objects);
            }

            Towers = new List<Tower>[data.Towers.Length];
            for (int i = 0; i < data.Towers.Length; ++i)
                Towers[i] = data.Towers[i];

            foreach (Tower tower in Towers[0])
                Board.SetObjects(tower.XCor, tower.YCor, new List<GameObject>() { tower });

            foreach (Tower tower in Towers[1])
                Board.SetObjects(tower.XCor, tower.YCor, new List<GameObject>() { tower });

            Units = new List<Unit>();
            foreach (var unit in data.Units)
                Units.Add(unit);

            ObstaclesPlaced = data.ObstaclesPlaced;
            Obstacles = new Obstacle[data.Obstacles.Length];
            for (int i = 0; i < data.Obstacles.Length; ++i)
            {
                Obstacles[i] = data.Obstacles[i];
                Board.SetObjects(Obstacles[i].XCor, Obstacles[i].YCor, new List<GameObject>() { Obstacles[i] });
            }

            CurrentPlayer = data.CurrentPlayer;
            CurrentPressed = Pressed.NONE;
            Status = data.Status;
            State = data.State;
        }

        public int[] InitializePrices()
        {
            int[] prices = { Troop.TroopCost, Cavalry.CavalryCost, Tower.DefaultCost, Tower.DefaultRefund };
            return prices;
        }

        public void SetStatus(string status, Pressed pressed)
        {
            Status = status;
            CurrentPressed = pressed;
        }

        public void StartWithMap(MapModel mapModel)
        {
            Board.MapHeight = mapModel.Board.MapHeight;
            Board.MapWidth = mapModel.Board.MapWidth;
            _board = new GameBoard(mapModel.Board.MapHeight, mapModel.Board.MapWidth);

            for (int i = 0; i < _board.MapHeight; ++i)
            {
                for (int j = 0; j < _board.MapWidth; ++j)
                {
                    _board.SetObjects(i, j, mapModel.Board.GetObjects(i, j));
                }
            }

            _currentPlayer = 0;
            State = GameState.BUY;

            _players = new Player[PLAYER_NUM];
            for (int i = 0; i < PLAYER_NUM; i++)
            {
                _players[i] = new Player(i)
                {
                    CastlePosition = new Position(mapModel.Castles[i].XCor, mapModel.Castles[i].YCor)
                };
            }

            _units = new List<Unit>();

            _castles = new Castle[PLAYER_NUM];
            for (int i = 0; i < PLAYER_NUM; i++)
            {
                _castles[i] = new Castle(i, mapModel.Castles[i].XCor, mapModel.Castles[i].YCor);
                _board.SetObjects(mapModel.Castles[i].XCor, mapModel.Castles[i].YCor, new List<GameObject>() { _castles[i] });
            }

            _towers = new List<Tower>[PLAYER_NUM];
            for (int i = 0; i < PLAYER_NUM; i++)
            {
                _towers[i] = new List<Tower>();
            }

            _huts = new Hut[PLAYER_NUM * HUT_NUM];
            for (int i = 0; i < _huts.Length; i++)
            {
                _huts[i] = new Hut(i / PLAYER_NUM, mapModel.Huts[i].XCor, mapModel.Huts[i].YCor);
                _board.SetObjects(mapModel.Huts[i].XCor, mapModel.Huts[i].YCor, new List<GameObject>() { _huts[i] });
            }

            _obstacles = new Obstacle[mapModel.ObstaclesPlaced];
            for (int i = 0; i < mapModel.ObstaclesPlaced; i++)
            {
                _obstacles[i] = mapModel.Obstacles[i];
                _board.SetObjects(mapModel.Obstacles[i].XCor, mapModel.Obstacles[i].YCor, new List<GameObject>() { mapModel.Obstacles[i] });
            }

            CurrentPressed = Pressed.NONE;
            Status = $"Building phase: Player{_currentPlayer + 1}'s turn!";

            FieldChanged?.Invoke(this, new FieldChangedEventArgs(_players[0].Funds, _players[1].Funds, _castles[0].Health, _castles[1].Health, Board, _currentPlayer, Status));
        }

        //Method to start a new game
        public void StartNewGame(MapSize mapSize)
        {
            _board = mapSize switch
            {
                MapSize.SMALL => new GameBoard(10, 11),
                MapSize.MEDIUM => new GameBoard(12, 13),
                MapSize.LARGE => new GameBoard(14, 15),
                _ => new GameBoard(10, 11),
            };

            _currentPlayer = 0;

            State = GameState.BUY;

            // Initializing the players
            _players = new Player[PLAYER_NUM];
            for (int i = 0; i < PLAYER_NUM; i++)
            {
                _players[i] = new Player(i);
            }

            // Creating random positions for the buildings
            List<Position> castlePos = GenerateCastlePositions(_board.MapHeight, _board.MapWidth);

            _units = new List<Unit>();

            // Initializing the castles and towers
            _castles = new Castle[PLAYER_NUM];
            _towers = new List<Tower>[PLAYER_NUM];

            for (int i = 0; i < PLAYER_NUM; i++)
            {
                _castles[i] = new Castle(i, castlePos[i].X, castlePos[i].Y);
                _board.SetObjects(castlePos[i].X, castlePos[i].Y, new List<GameObject>() { _castles[i] });
                _towers[i] = new List<Tower>();
            }

            // Creating random positions for the huts
            List<Position> hutPos = GenerateHutPositions(_board.MapHeight, _board.MapWidth);

            // Initializing the huts
            _huts = new Hut[PLAYER_NUM * HUT_NUM];
            for (int i = 0; i < _huts.Length; i++)
            {
                _huts[i] = new Hut(i / PLAYER_NUM, hutPos[i].X, hutPos[i].Y);
                _board.SetObjects(hutPos[i].X, hutPos[i].Y, new List<GameObject>() { _huts[i] });
            }

            // Creating random positions for the obstacles
            List<Position> obstaclePos = GenerateObstaclePositions(_board.MapHeight, _board.MapWidth);

            // Initializing the obstacles
            _obstacles = new Obstacle[obstaclePos.Count];
            for (int i = 0; i < obstaclePos.Count; i++)
            {
                _obstacles[i] = new Obstacle(obstaclePos[i].X, obstaclePos[i].Y);
                _board.SetObjects(obstaclePos[i].X, obstaclePos[i].Y, new List<GameObject>() { _obstacles[i] });
            }

            CurrentPressed = Pressed.NONE;
            Status = $"Building phase: Player{_currentPlayer + 1}'s turn!";

            FieldChanged?.Invoke(this, new FieldChangedEventArgs(_players[0].Funds, _players[1].Funds, _castles[0].Health, _castles[1].Health, Board, _currentPlayer, Status));
        }

        #endregion

        #region Persistence methods

        public async Task Save(string name, string location, bool overwrite)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access provided.");

            SaveData data = new SaveData(this, name);
            await _dataAccess.Save(data, location, overwrite);
        }

        public async Task Load(string name, string location)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access provided.");

            SaveData data = await _dataAccess.Load(name, location);
            InitModel(data);
            FieldChanged?.Invoke(this, new FieldChangedEventArgs(_players[0].Funds, _players[1].Funds, _castles[0].Health, _castles[1].Health, Board, _currentPlayer, Status));
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

        #region Game methods

        // Method provides chance to players to build/unbuild/uprade tower or train units until they have money for it
        public void Build(Pressed pressed)
        {
            string playerText = _currentPlayer == 0 ? "Player1" : "Player2";

            if (pressed == Pressed.TROOP || pressed == Pressed.CAVALRY)
            {
                AbstractGameObjectFactory factory = FactoryProducer.GetFactory(false);
                int randHut = RandomGeneratorZeroOrOne();
                int x = _huts[randHut + _currentPlayer * 2].XCor;
                int y = _huts[randHut + _currentPlayer * 2].YCor;
                GameObject unit = pressed == Pressed.TROOP ? factory.GetGameObject("troop", _currentPlayer, x, y) : factory.GetGameObject("cavalry", _currentPlayer, x, y);

                List<GameObject> field = _board.GetObjects(x, y);
                field.Add(unit);

                _board.SetObjects(x, y, field);
                int cost = pressed == Pressed.TROOP ? Troop.TroopCost : Cavalry.CavalryCost;

                _players[_currentPlayer].Funds -= cost;
                _players[_currentPlayer].UnitCount += 1;

                _units.Add((Unit)unit);

                SetStatus($"New unit bought! Player{_currentPlayer + 1}'s turn!", Pressed.NONE);
            }
            else if (pressed == Pressed.NEWTOWER)
            {
                if (CurrentPressed != Pressed.NEWTOWER) SetStatus($"{playerText}, Choose an empty field on the board for the new tower or press the 'Buy tower' button again to cancel the purchase.", Pressed.NEWTOWER);
                else SetStatus($"Purchase cancelled - {playerText}'s turn", Pressed.NONE);
            }
            else if (pressed == Pressed.UPGRADE)
            {
                if (CurrentPressed != Pressed.UPGRADE) SetStatus($"{playerText}, Choose one of your existing towers on the board to upgrade it or press the 'Upgrade tower' button again to cancel the purchase.", Pressed.UPGRADE);
                else SetStatus($"Purchase cancelled - {playerText}'s turn", Pressed.NONE);
            }
            else if (pressed == Pressed.REMOVE)
            {
                if (CurrentPressed != Pressed.REMOVE) SetStatus($"{playerText}, Choose one of your existing towers on the board to remove it or press the 'Remove tower' button again to cancel the removal.", Pressed.REMOVE);
                else SetStatus($"Removal cancelled - {playerText}'s turn", Pressed.NONE);
            }
            else if (pressed == Pressed.END)
            {
                _currentPlayer = (_currentPlayer + 1) % 2;
                if (_currentPlayer == 0)
                {
                    SetStatus(AttackText, Pressed.NONE);
                    State = GameState.WAR;
                }
                else
                {
                    SetStatus($"Building phase: Player{_currentPlayer + 1}'s turn!", Pressed.NONE);
                }
            }

            FieldChanged?.Invoke(this, new FieldChangedEventArgs(_players[0].Funds, _players[1].Funds, _castles[0].Health, _castles[1].Health, Board, _currentPlayer, Status));
        }

        //Method to buy / upgrade / remove a tower or get field details
        public void HandleBuyPhase(int x, int y)
        {
            AbstractGameObjectFactory factory = FactoryProducer.GetFactory(true);

            List<GameObject> field = _board.GetObjects(x, y);
            GameObject obj;

            if (CurrentPressed == Pressed.NONE)
            {
                DetailsExtended?.Invoke(this, new DetailsExtendedEventArgs(field, _currentPlayer));

                CurrentPressed = Pressed.NONE;
            }
            else
            {
                string message = "";
                int cost = 0;

                #region Building a new tower
                //Building a new tower
                if (CurrentPressed == Pressed.NEWTOWER)
                {
                    //Checking whether the chosen position is in one-square distance of a tower or hut
                    int castle1_x = _castles[0].XCor;
                    int castle1_y = _castles[0].YCor;
                    int castle2_x = _castles[1].XCor;
                    int castle2_y = _castles[1].YCor;
                    int player1hut1_x = _huts[0].XCor;
                    int player1hut1_y = _huts[0].YCor;
                    int player2hut1_x = _huts[1].XCor;
                    int player2hut1_y = _huts[1].YCor;
                    int player1hut2_x = _huts[2].XCor;
                    int player1hut2_y = _huts[2].YCor;
                    int player2hut2_x = _huts[3].XCor;
                    int player2hut2_y = _huts[3].YCor;

                    int distance = 1;

                    bool correct = (Math.Abs(castle1_x - x) > distance || Math.Abs(castle1_y - y) > distance)
                           && (Math.Abs(castle2_x - x) > distance || Math.Abs(castle2_y - y) > distance)
                           && (Math.Abs(player1hut1_x - x) > distance || Math.Abs(player1hut1_y - y) > distance)
                           && (Math.Abs(player2hut1_x - x) > distance || Math.Abs(player2hut1_y - y) > distance)
                           && (Math.Abs(player1hut2_x - x) > distance || Math.Abs(player1hut2_y - y) > distance)
                           && (Math.Abs(player2hut2_x - x) > distance || Math.Abs(player2hut2_y - y) > distance)
                           ;

                    if (field.Count != 0) message = "You can't build a tower on an occupied field, choose an empty one!";

                    else
                    {
                        if (correct)
                        {
                            obj = factory.GetGameObject("tower", _currentPlayer, x, y);

                            field.Add(obj);

                            _board.SetObjects(x, y, field);

                            //Checking whether the new tower blocks any of the paths between the huts and the castles
                            bool pathCorrect = true;

                            int l = 0;
                            while (pathCorrect && l < _huts.Length)
                            {
                                Hut hut = _huts[l];
                                PathFinder pf = new PathFinder(_board, hut.XCor, hut.YCor, _castles[(hut.PlayerID + 1) % 2].XCor, _castles[(hut.PlayerID + 1) % 2].YCor);
                                if (pf.GetShortestPath().Count == 0) pathCorrect = false;
                                l++;
                            }

                            if (pathCorrect)
                            {
                                cost = (obj as Tower).Cost * -1;
                                message = "New tower built";

                                if (_towers[_currentPlayer] == null)
                                {
                                    _towers[_currentPlayer] = new List<Tower>();
                                }
                                _towers[_currentPlayer].Add(obj as Tower);

                                CurrentPressed = Pressed.NONE;
                            }
                            else
                            {
                                field.Clear();
                                _board.SetObjects(x, y, field);
                                message = "You can't block the path between the huts and the opponent's castle!";
                            }
                        }
                        else
                        {
                            message = "You can't build a tower in one-square distance of a tower or hut, choose another one!";
                        }
                    }
                }
                #endregion
                #region Upgrading a tower
                //Upgrading a tower
                else if (CurrentPressed == Pressed.UPGRADE)
                {
                    if (field.Count == 0) message = "There is no upgradeable tower on this field, choose another one!";
                    else
                    {
                        obj = field[0] as Tower;

                        if (obj == null || obj.Type != FieldType.TOWER) message = "There is no upgradeable tower on this field, choose another one!";
                        else if (obj.PlayerID != CurrentPlayer) message = "This tower belongs to the other player, choose one of your own!";
                        else if (_players[_currentPlayer].Funds < (obj as Tower).Cost + Tower.DefaultCost) message = "You don't have enough gold to upgrade this tower!";
                        else
                        {
                            bool upgraded = (obj as Tower).Upgrade();

                            if (!upgraded) message = "This tower is already fully upgraded, choose another one!";
                            else
                            {
                                cost = (obj as Tower).Cost * -1;
                                int level = -1 * cost / Tower.DefaultCost;
                                message = $"Tower upgraded to level{level}, cost: {cost * -1}";

                                CurrentPressed = Pressed.NONE;
                            }
                        }
                    }
                }
                #endregion

                #region Removing a tower
                //Removing a tower
                else if (CurrentPressed == Pressed.REMOVE)
                {
                    if (field.Count == 0) message = "There is no removeable tower on this field, choose another one!";
                    else
                    {
                        obj = field[0];

                        if (obj == null || obj.Type != FieldType.TOWER) message = "There is no removeable tower on this field, choose another one!";
                        else if (obj.PlayerID != _currentPlayer) message = "This tower belongs to the other player, choose one of your own!";
                        else
                        {
                            cost = (obj as Tower).Level * Tower.DefaultRefund;
                            (obj as Tower).IsRemoved = true;

                            field.Clear();

                            message = $"Tower removed, {cost} gold gained";

                            CurrentPressed = Pressed.NONE;
                        }
                    }
                }
                #endregion

                _players[_currentPlayer].Funds += cost;

                FieldChanged?.Invoke(this, new FieldChangedEventArgs(_players[0].Funds, _players[1].Funds, _castles[0].Health, _castles[1].Health, _board, _currentPlayer, $"{message} - Player{_currentPlayer + 1}'s turn"));
            }
        }

        // Method, after the building period, the game logic simulates the attacks
        public void Simulation()
        {
            List<Unit> deletable_units = new List<Unit>();
            foreach (Unit unit in Units)
            {
                //Calculating the shortest path to the opponent's castle
                int opponent_id = Math.Abs(1 - unit.PlayerID); // 1-1 == 0, 1-0 == 1 ==> mindig a masik ID-t kapjuk vissza

                int opponent_castle_x = _players[opponent_id].CastlePosition.X;
                int opponent_castle_y = _players[opponent_id].CastlePosition.Y;

                PathFinder pf = new PathFinder(_board, unit.XCor, unit.YCor, opponent_castle_x, opponent_castle_y);

                (unit as Unit).PathToShortest = pf.GetShortestPath();

                if (unit.PathToShortest.Count == 1)
                {
                    unit.Attack(_castles[opponent_id]);
                }

                //Stepping the units on the board towards the opponent's castle
                Position prev = new Position((unit as Unit).XCor, (unit as Unit).YCor);
                (unit as Unit).Move();

                string prevID = unit.UniqueID;
                List<GameObject> prevTempList = _board.GetObjects(prev.X, prev.Y);
                //prevTempList.Remove(unit);

                var item = prevTempList.SingleOrDefault(x => x.UniqueID == prevID);
                if (item != null)
                    prevTempList.Remove(item);

                _board.SetObjects(prev.X, prev.Y, prevTempList);

                List<GameObject> nextTempList = _board.GetObjects((unit as Unit).XCor, (unit as Unit).YCor);
                nextTempList.Add(unit);

                _board.SetObjects(unit.XCor, unit.YCor, nextTempList);

                //Attacking the unit with the nearby towers
                TowerScan(unit, opponent_id);

                //Checking whether the unit survived the attacks or arrived to the opponent's castle
                if (unit.PathToShortest.Count == 0 || unit.Health <= 0)
                {
                    List<GameObject> removeable = _board.GetObjects(unit.XCor, unit.YCor);

                    removeable.Remove(unit);
                    _board.SetObjects(unit.XCor, unit.YCor, removeable);


                    if (unit.Health <= 0 && !(unit as Unit).IsDead)
                    {
                        (unit as Unit).IsDead = unit.Health <= 0;
                        _players[opponent_id].Funds += KILL_REWARD;
                    }
                    deletable_units.Add(unit);
                }
            }
            //Removing the dead or arrived units
            foreach (Unit unit in deletable_units)
                _units.Remove(unit);
            //CheckGameOver();

            FieldChanged?.Invoke(this, new FieldChangedEventArgs(_players[0].Funds, _players[1].Funds, _castles[0].Health, _castles[1].Health, Board, _currentPlayer, Status));
        }

        //Method to attack the unit with the nearby towers
        public void TowerScan(Unit unit, int opponentid)
        {
            if (_towers == null || _towers[opponentid] == null)
                return;

            foreach (Tower tower in _towers[opponentid])
            {
                if (!tower.IsRemoved && PathFinder.InRange(unit.XCor, unit.YCor, tower.XCor, tower.YCor))
                {
                    tower.Attack(unit);
                }
            }
        }

        // Method to check if the game is over
        public void CheckGameOver()
        {
            bool areCastlesOk;
            bool castle1 = _castles[0].Health > 0;
            bool castle2 = _castles[1].Health > 0;

            areCastlesOk = castle1 && castle2;

            if (!areCastlesOk && GameOver != null)
            {
                GameOver(this, new GameOverEventArgs(castle1, castle2));
                State = GameState.OVER;
                Status = "Start a new game!";
                FieldChanged?.Invoke(this, new FieldChangedEventArgs(_players[0].Funds, _players[1].Funds, _castles[0].Health, _castles[1].Health, Board, _currentPlayer, Status));
            }
        }

        #endregion

        #region Random generator methods

        //Randomgenerator method (return with 0 or 1)
        public int RandomGeneratorZeroOrOne()
        {
            Random q = new Random();
            int generated = q.Next(0, 2);
            return generated;
        }

        //Randomgenerator method provide 2 balanced positions to the castles (0 to n-1, 0 to m-1)
        public List<Position> GenerateCastlePositions(int n, int m)
        {
            Random r = new Random();
            int x, y;
            x = r.Next(2, n); //2, 3, 4, ... n-2, n-1
            y = r.Next(2, m); //2, 3, 4, ... m-2, m-1

            //paros x paratlan
            if (n % 2 == 0 && m % 2 == 1)
            {

                if (x == n / 2 - 1 || x == n / 2 + 2)
                {

                    while (y == (m + 1) / 2 - 1 || y == (m + 1) / 2 || y == (m + 1) / 2 + 1)
                    {
                        y = r.Next(2, m);
                    }
                }

                else if (x == n / 2 || x == n / 2 + 1)
                {
                    while (y == (m + 1) / 2 - 2 || y == (m + 1) / 2 - 1 || y == (m + 1) / 2 || y == (m + 1) / 2 + 1 || y == (m + 1) / 2 + 2)
                    {
                        y = r.Next(2, m);
                    }
                }

            }

            //paratlan x paros
            if (n % 2 == 1 && m % 2 == 0)
            {

                if (x == (n + 1) / 2 - 2 || x == (n + 1) / 2 + 2)
                {
                    while (y == m / 2 || y == m / 2 + 1)
                    {
                        y = r.Next(2, m);
                    }
                }

                else if (x == (n + 1) / 2 - 1 || x == (n + 1) / 2 || x == (n + 1) / 2 + 1)
                {
                    while (y == m / 2 - 1 || y == m / 2 || y == m / 2 + 1 || y == m / 2 + 2)
                    {
                        y = r.Next(2, m);
                    }
                }

            }

            //paratlan x paratlan
            else if (n % 2 == 1 && m % 2 == 1)
            {
                if (x == (n + 1) / 2 - 1 || x == (n + 1) / 2 || x == (n + 1) / 2 + 1)
                {
                    while (y == (m + 1) / 2 - 1 || y == (m + 1) / 2 || y == (m + 1) / 2 + 1)
                    {
                        y = r.Next(2, m);
                    }
                }
            }

            //paros x paros
            else
            {
                if (x == n / 2 - 1 || x == n / 2 || x == n / 2 + 1 || x == n / 2 + 2)
                {
                    while (y == m / 2 - 1 || y == m / 2 || y == m / 2 + 1 || y == m / 2 + 2)
                    {
                        y = r.Next(2, m);
                    }
                }

            }

            double p1 = (double)x - 0.5;
            double p2 = (double)y - 0.5;
            double o1 = (double)n / 2;
            double o2 = (double)m / 2;
            double q1 = 2 * (double)o1 - (double)p1;
            double q2 = 2 * (double)o2 - (double)p2;


            x = Convert.ToInt32((p1 - 0.5));
            y = Convert.ToInt32((p2 - 0.5));
            int x2 = Convert.ToInt32((q1 - 0.5));
            int y2 = Convert.ToInt32((q2 - 0.5));

            Position castle1 = new Position(x, y);
            _players[0].CastlePosition = new Position(x, y);
            Position castle2 = new Position(x2, y2);
            _players[1].CastlePosition = new Position(x2, y2);
            List<Position> list = new List<Position>
            {
                castle1,
                castle2
            };

            return list;
        }

        //Randomgenerator method provide 4 balanced positions to the huts (player1h1, player2h1, player1h2, player2h2)
        public List<Position> GenerateHutPositions(int n, int m)
        {
            //Already existing castle coordinates stored
            int x1 = _castles[0].XCor;
            int y1 = _castles[0].YCor;
            int x2 = _castles[1].XCor;
            int y2 = _castles[1].YCor;

            double d1, d2;

            Random o = new Random();

            int p, q;

            p = o.Next(0, n); //0, 1, 2, 3, 4, ... n-1
            q = o.Next(0, m); //0, 1, 2, 3, 4, ... m-1

            bool correct = (Math.Abs(x1 - p) > 1 || Math.Abs(y1 - q) > 1) && (Math.Abs(x2 - p) > 1 || Math.Abs(y2 - q) > 1);

            //1st round
            while (!correct)
            {
                p = o.Next(0, n); //0, 1, 2, 3, 4, ... n-1
                q = o.Next(0, m); //0, 1, 2, 3, 4, ... m-1
                correct = (Math.Abs(x1 - p) > 1 || Math.Abs(y1 - q) > 1)
                    && (Math.Abs(x2 - p) > 1 || Math.Abs(y2 - q) > 1);
            }

            d1 = Math.Sqrt(Math.Pow((x1 - p), 2) + Math.Pow((y1 - q), 2));
            d2 = Math.Sqrt(Math.Pow((x2 - p), 2) + Math.Pow((y2 - q), 2));


            double e1 = (double)p + 0.5;
            double e2 = (double)q + 0.5;
            double o1 = (double)n / 2;
            double o2 = (double)m / 2;
            double f1 = 2 * (double)o1 - (double)e1;
            double f2 = 2 * (double)o2 - (double)e2;

            p = Convert.ToInt32((e1 - 0.5));
            q = Convert.ToInt32((e2 - 0.5));
            int p2 = Convert.ToInt32((f1 - 0.5));
            int q2 = Convert.ToInt32((f2 - 0.5));


            if (d1 >= d2)
            {
                (p2, p) = (p, p2);
                (q2, q) = (q, q2);
            }

            Position player1hut1 = new Position(p, q);
            Position player2hut1 = new Position(p2, q2);



            //2th round
            int i = o.Next(0, n); //0, 1, 2, 3, 4, ... n-1
            int j = o.Next(0, m); //0, 1, 2, 3, 4, ... m-1

            bool correct2 = (Math.Abs(x1 - i) > 1 || Math.Abs(y1 - j) > 1)
                         && (Math.Abs(x2 - i) > 1 || Math.Abs(y2 - j) > 1)
                         && (i != p || j != q) && (i != p2 || j != q2);

            while (!correct2)
            {
                i = o.Next(0, n); //0, 1, 2, 3, 4, ... n-1
                j = o.Next(0, m); //0, 1, 2, 3, 4, ... m-1
                correct2 = (Math.Abs(x1 - i) > 1 || Math.Abs(y1 - j) > 1)
                         && (Math.Abs(x2 - i) > 1 || Math.Abs(y2 - j) > 1)
                         && (i != p || j != q) && (i != p2 || j != q2);
            }

            double d3 = Math.Sqrt(Math.Pow((x1 - i), 2) + Math.Pow((y1 - j), 2));
            double d4 = Math.Sqrt(Math.Pow((x2 - i), 2) + Math.Pow((y2 - j), 2));

            double e3 = (double)i + 0.5;
            double e4 = (double)j + 0.5;
            double o3 = (double)n / 2;
            double o4 = (double)m / 2;
            double f3 = 2 * (double)o3 - (double)e3;
            double f4 = 2 * (double)o4 - (double)e4;

            i = Convert.ToInt32((e3 - 0.5));
            j = Convert.ToInt32((e4 - 0.5));
            int i2 = Convert.ToInt32((f3 - 0.5));
            int j2 = Convert.ToInt32((f4 - 0.5));


            if (d3 >= d4)
            {
                (i2, i) = (i, i2);
                (j2, j) = (j, j2);
            }

            Position player1hut2 = new Position(i, j);
            Position player2hut2 = new Position(i2, j2);


            List<Position> list = new List<Position>
            {
                player1hut1,
                player1hut2,
                player2hut1,
                player2hut2
            };
            return list;

        }

        //Randomgenerator method provide positions to the obstacles 
        public List<Position> GenerateObstaclePositions(int n, int m)
        {
            int castle1_x = _castles[0].XCor;
            int castle1_y = _castles[0].YCor;
            Castle c1 = new Castle(0, castle1_x, castle1_y);

            int castle2_x = _castles[1].XCor;
            int castle2_y = _castles[1].YCor;
            Castle c2 = new Castle(1, castle2_x, castle2_y);


            int player1hut1_x = _huts[0].XCor;
            int player1hut1_y = _huts[0].YCor;
            Hut p1h1 = new Hut(0, player1hut1_x, player1hut1_y);

            int player2hut1_x = _huts[1].XCor;
            int player2hut1_y = _huts[1].YCor;
            Hut p2h1 = new Hut(1, player2hut1_x, player2hut1_y);


            int player1hut2_x = _huts[2].XCor;
            int player1hut2_y = _huts[2].YCor;
            Hut p1h2 = new Hut(0, player1hut2_x, player1hut2_y);


            int player2hut2_x = _huts[3].XCor;
            int player2hut2_y = _huts[3].YCor;
            Hut p2h2 = new Hut(1, player2hut2_x, player2hut2_y);


            List<Position> listToReturn = new List<Position>();
            GameBoard betaVersion = new GameBoard(_board.MapHeight, _board.MapWidth);

            for (int i = 0; i < _board.MapHeight; ++i)
            {
                for (int j = 0; j < _board.MapWidth; ++j)
                {
                    betaVersion.SetObjects(i, j, new List<GameObject>());
                }
            }

            betaVersion.SetObjects(castle1_x, castle1_y, new List<GameObject>() { c1 });
            betaVersion.SetObjects(castle2_x, castle2_y, new List<GameObject>() { c2 });
            betaVersion.SetObjects(player1hut1_x, player1hut1_y, new List<GameObject>() { p1h1 });
            betaVersion.SetObjects(player2hut1_x, player2hut1_y, new List<GameObject>() { p2h1 });
            betaVersion.SetObjects(player1hut2_x, player1hut2_y, new List<GameObject>() { p1h2 });
            betaVersion.SetObjects(player2hut2_x, player2hut2_y, new List<GameObject>() { p2h2 });


            int tenPercent = (int)(_board.MapHeight * _board.MapWidth / 10);
            Obstacle[] generatedObstacles = new Obstacle[tenPercent];

            for (int i = 0; i < tenPercent; i++)
            {
                Random rand = new Random();
                int random_XCor = rand.Next(0, n);
                int random_YCor = rand.Next(0, m);

                bool correct = (Math.Abs(castle1_x - random_XCor) > 1 || Math.Abs(castle1_y - random_YCor) > 1)
                            && (Math.Abs(castle2_x - random_XCor) > 1 || Math.Abs(castle2_y - random_YCor) > 1)
                            && (Math.Abs(player1hut1_x - random_XCor) > 1 || Math.Abs(player1hut1_y - random_YCor) > 1)
                            && (Math.Abs(player2hut1_x - random_XCor) > 1 || Math.Abs(player2hut1_y - random_YCor) > 1)
                            && (Math.Abs(player1hut2_x - random_XCor) > 1 || Math.Abs(player1hut2_y - random_YCor) > 1)
                            && (Math.Abs(player2hut2_x - random_XCor) > 1 || Math.Abs(player2hut2_y - random_YCor) > 1)
                            && betaVersion.GetObjects(random_XCor, random_YCor).Count == 0
                            ;

                Obstacle obI;

                if (correct)
                {
                    obI = new Obstacle(random_XCor, random_YCor);
                    generatedObstacles[i] = obI;
                    betaVersion.SetObjects(random_XCor, random_YCor, new List<GameObject>() { generatedObstacles[i] });
                }


                PathFinder pf1 = new PathFinder(betaVersion, player1hut1_x, player1hut1_y, castle2_x, castle2_y);
                PathFinder pf2 = new PathFinder(betaVersion, player2hut1_x, player2hut1_y, castle1_x, castle1_y);
                PathFinder pf3 = new PathFinder(betaVersion, player1hut2_x, player1hut2_y, castle2_x, castle2_y);
                PathFinder pf4 = new PathFinder(betaVersion, player2hut2_x, player2hut2_y, castle1_x, castle1_y);

                bool shortestPathsStillExist =
                       pf1.GetShortestPath().Count != 0
                    && pf2.GetShortestPath().Count != 0
                    && pf3.GetShortestPath().Count != 0
                    && pf4.GetShortestPath().Count != 0;

                bool acceptable = correct && shortestPathsStillExist;

                while (!acceptable)
                {
                    if (correct)
                    {
                        betaVersion.SetObjects(random_XCor, random_YCor, new List<GameObject>());

                    }

                    random_XCor = rand.Next(0, n);
                    random_YCor = rand.Next(0, m);

                    correct = (Math.Abs(castle1_x - random_XCor) > 1 || Math.Abs(castle1_y - random_YCor) > 1)
                            && (Math.Abs(castle2_x - random_XCor) > 1 || Math.Abs(castle2_y - random_YCor) > 1)
                            && (Math.Abs(player1hut1_x - random_XCor) > 1 || Math.Abs(player1hut1_y - random_YCor) > 1)
                            && (Math.Abs(player2hut1_x - random_XCor) > 1 || Math.Abs(player2hut1_y - random_YCor) > 1)
                            && (Math.Abs(player1hut2_x - random_XCor) > 1 || Math.Abs(player1hut2_y - random_YCor) > 1)
                            && (Math.Abs(player2hut2_x - random_XCor) > 1 || Math.Abs(player2hut2_y - random_YCor) > 1)
                            && betaVersion.GetObjects(random_XCor, random_YCor).Count == 0
                            ;
                    if (correct)
                    {
                        obI = new Obstacle(random_XCor, random_YCor);
                        generatedObstacles[i] = obI;
                        betaVersion.SetObjects(random_XCor, random_YCor, new List<GameObject>() { generatedObstacles[i] });
                    }

                    shortestPathsStillExist =
                       pf1.GetShortestPath().Count != 0
                    && pf2.GetShortestPath().Count != 0
                    && pf3.GetShortestPath().Count != 0
                    && pf4.GetShortestPath().Count != 0;

                    acceptable = correct && shortestPathsStillExist;

                }

                Position obstacleNrI = new Position(random_XCor, random_YCor);
                listToReturn.Add(obstacleNrI);
            }

            return listToReturn;
        }

        #endregion
    }
}
