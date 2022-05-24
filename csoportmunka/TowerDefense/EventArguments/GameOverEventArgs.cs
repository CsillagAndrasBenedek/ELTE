using System;
using System.Collections.Generic;
using System.Text;

namespace TowerDefense.EventArguments
{
    public class GameOverEventArgs
    {
        public bool Player1CastleIsOk { get; set; }

        public bool Player2CastleIsOk { get; set; }

        public GameOverEventArgs(bool player1CastleIsOk, bool player2CastleIsOk)
        {
            Player1CastleIsOk = player1CastleIsOk;
            Player2CastleIsOk = player2CastleIsOk;
        }
    }
}
