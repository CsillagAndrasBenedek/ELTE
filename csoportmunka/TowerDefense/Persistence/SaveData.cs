using System;
using System.Collections.Generic;
using System.Text;
using TowerDefense.GameObjects;
using TowerDefense.Model;

namespace TowerDefense.Persistence
{
    public class SaveData
    {
        public List<GameObject>[,] Board { get; set; }
        public Player[] Players { get; set; }
        public Castle[] Castles { get; set;}
        public Hut[] Huts { get; set;}
        public List<Tower>[] Towers { get; set; }
        public List<Unit> Units { get; set; }
        public Obstacle[] Obstacles { get; set;}
        
        public int MapHeight { get; set; }
        public int MapWidth { get; set; }
        public int CurrentPlayer { get; set; }
        public string Status { get; set; }
        public GameState State { get; set; }
        public string SaveName { get; set; }
        public int ObstaclesPlaced { get; set; }

        public SaveData()
        {
            MapHeight = 10;
            MapWidth = 11;

            Board = new List<GameObject>[10, 11];
            for (int i = 0; i < 10; ++i)
                for (int j = 0; j < 11; ++j)
                    Board[i, j] = new List<GameObject>();

            Huts = new Hut[4];     
            Castles = new Castle[2];
            Players = new Player[2];
            Towers = new List<Tower>[2];
            Units = new List<Unit>();
            Obstacles = new Obstacle[2];

            CurrentPlayer = 0;
            Status = "";
            State = GameState.BUY;
            SaveName = "";
            ObstaclesPlaced = 2;   
        }

        public SaveData(GameModel model, string saveName)
        {
            MapHeight = model.Board.MapHeight;
            MapWidth = model.Board.MapWidth;

            Board = new List<GameObject>[model.Board.MapHeight, model.Board.MapWidth];
            for (int i = 0; i < model.Board.MapHeight; ++i)
                for (int j = 0; j < model.Board.MapWidth; ++j)
                    Board[i, j] = model.Board.GetObjects(i, j);

            Players = new Player[model.Players.Length];
            for (int i = 0; i < model.Players.Length; ++i)
                Players[i] = model.Players[i];

            Castles = new Castle[model.Castles.Length];
            for (int i = 0; i < model.Castles.Length; ++i)
            {
                Castles[i] = model.Castles[i];
                Board[Castles[i].XCor, Castles[i].YCor] = model.Board.GetObjects(Castles[i].XCor, Castles[i].YCor);
            }

            Huts = new Hut[model.Huts.Length];
            for (int i = 0; i < model.Huts.Length; ++i)
            {
                Huts[i] = model.Huts[i];
                Board[Huts[i].XCor, Huts[i].YCor] = model.Board.GetObjects(Huts[i].XCor, Huts[i].YCor);
            }

            Towers = new List<Tower>[model.Towers.Length];
            for (int i = 0; i < model.Towers.Length; ++i)
                Towers[i] = model.Towers[i];

            foreach (Tower tower in Towers[0])
                Board[tower.XCor, tower.YCor] = model.Board.GetObjects(tower.XCor, tower.YCor);

            foreach (Tower tower in Towers[1])
                Board[tower.XCor, tower.YCor] = model.Board.GetObjects(tower.XCor, tower.YCor);

            Units = new List<Unit>();
            foreach (var unit in model.Units)
                Units.Add(unit);
     
            Obstacles = new Obstacle[model.Obstacles.Length];
            for (int i = 0; i < model.Obstacles.Length; ++i)
            {
                Obstacles[i] = model.Obstacles[i];
                Board[Obstacles[i].XCor, Obstacles[i].YCor] = model.Board.GetObjects(Obstacles[i].XCor, Obstacles[i].YCor);
            }

            CurrentPlayer = model.CurrentPlayer;
            Status = model.Status;
            State = model.State;
            SaveName = saveName;
            ObstaclesPlaced = model.Obstacles.Length;
        }
    }
}
