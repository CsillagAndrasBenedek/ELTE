using System;
using System.Collections.Generic;
using System.Text;
using TowerDefense.Model;

namespace TowerDefense.EventArguments
{
    public class MapFieldChangedEventArgs
    {
        public MapFieldChangedEventArgs(GameBoard newBoard, string statusLabel, bool[] castlesExist, int[] hutsLeft, int obstaclesPlaced)
        {
            NewBoard = newBoard;
            StatusLabel = statusLabel;
            CastlesExist = castlesExist;
            HutsLeft = hutsLeft;
            ObstaclesPlaced = obstaclesPlaced;
        }

        public GameBoard NewBoard { get; set; }
        public string StatusLabel { get; set; }
        public bool[] CastlesExist { get; set; }
        public int[] HutsLeft { get; set; }
        public int ObstaclesPlaced { get; set; }    
    }
}
