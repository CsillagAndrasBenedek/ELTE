using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresGameWpf.EventArguments
{
    public class StatusStripChangedEventArgs
    {
        public int BluePoints { get; set; }

        public int RedPoints { get; set; }

        public int PlayerMoveNext { get; set; }

        public StatusStripChangedEventArgs(int bluePoints, int redPoints, int playerMoveNext)
        {
            BluePoints = bluePoints;
            RedPoints = redPoints;
            PlayerMoveNext = playerMoveNext;
        }
    }
}
