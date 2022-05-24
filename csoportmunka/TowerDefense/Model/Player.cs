using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TowerDefense.Model
{
    public class Player
    {
        protected int _funds;
        protected int _playerID;
        protected int _unitCount;
        protected bool _isCastleOk;
        public static readonly int DefaultFunds = 500;
        private Position _castlePosition;

        public Player(int playerID)
        {
            _funds = DefaultFunds;
            _playerID = playerID;
            _unitCount = 0;
            _isCastleOk = true;
        }

        [JsonConstructor]
        public Player(int funds, int playerID, int unitCount, bool isCastleOk)
        {
            _funds = funds;
            _playerID = playerID;
            _unitCount = unitCount;
            _isCastleOk = isCastleOk;
        }

        public int Funds
        {
            set => _funds = value;
            get => _funds;
        }

        public void SetUnitCount(int newCount) 
        {
            _unitCount = newCount;
        }

        public int UnitCount
        {
            set => _unitCount = value;
            get => _unitCount;
        }

        public bool IsCastleOK
        {
            get => _isCastleOk;
        }

        public Position CastlePosition 
        { 
            get => _castlePosition;
            set => _castlePosition = value;
        }
    }
}
