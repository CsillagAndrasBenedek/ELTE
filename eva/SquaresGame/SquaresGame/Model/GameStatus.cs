using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresGame.Model
{
    public class GameStatus
    {
        public int PlayerBlue { get; set; }
        public int PlayerRed { get; set; }

        public int Size { get; set; }
        public int playerToMove { get; set; }

        public List<int> Table { get; set; }

        public GameStatus(int size, int playerBlue, int playerRed, int playerToMove, List<int> table)
        {
            Size = size;
            PlayerBlue = playerBlue;
            PlayerRed = playerRed;
            this.playerToMove = playerToMove;
            Table = table;
        }
    }
}
