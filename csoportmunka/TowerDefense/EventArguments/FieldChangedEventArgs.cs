using System;
using System.Collections.Generic;
using System.Text;
using TowerDefense.Model;

namespace TowerDefense.EventArguments
{
    public class FieldChangedEventArgs
    {
        public FieldChangedEventArgs(int player1Gold, int player2Gold, int player1Castle, int player2Castle, GameBoard newBoard, int currentPlayer, string statusLabel)
        {
            Player1Gold = player1Gold;
            Player2Gold = player2Gold;
            Player1Castle = player1Castle;
            Player2Castle = player2Castle;
            NewBoard = newBoard;
            CurrentPlayer = currentPlayer;
            StatusLabel = statusLabel;
        }

        public int Player1Gold { get; set; }
        public int Player2Gold { get; set; }
        public int Player1Castle { get; set; }
        public int Player2Castle { get; set; }
        public GameBoard NewBoard { get; set; }
        public int CurrentPlayer { get; set; }
        public string StatusLabel { get; set; }
    }
}
