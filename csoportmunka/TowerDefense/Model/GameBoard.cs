using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.Model
{
    public class GameBoard
    {
        public int MapHeight { get; set; }
        public int MapWidth { get; set; }
        

        private readonly List<GameObject>[,] _gameBoard;

        public GameBoard(int mapHeight, int mapWidth)
        {
            _gameBoard = new List<GameObject>[mapHeight, mapWidth];
            MapHeight = mapHeight;
            MapWidth = mapWidth;
        }

        public bool IsValidField(int row, int col)
        {
            if (row < 0 || row > MapHeight - 1)
            {
                throw new ArgumentOutOfRangeException("row", "Error. Row coordinate out of range.");
            }

            if (col < 0 || col > MapWidth - 1)
            {
                throw new ArgumentOutOfRangeException("col", "Error. Column coordinate out of range.");
            }

            return true;
        }

        public void SetObjects(int row, int col, List<GameObject> objects)
        {
            if (IsValidField(row, col))
            {
                _gameBoard[row, col] = objects;
            }
        }

        public List<GameObject> GetObjects(int row, int col)
        {
            if (IsValidField(row, col))
            {
                return _gameBoard[row, col];
            }

            return null;
        }
    }
}