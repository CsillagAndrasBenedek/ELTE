using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresGame.EventArguments
{
    public class GameOverEventArgs
    {
        public int BluePoint { get; set; }

        public int RedPoint { get; set; }

        public GameOverEventArgs(int bluePoint, int redPoint)
        {
            BluePoint = bluePoint;
            RedPoint = redPoint;
        }
    }
}
