using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;

namespace TowerDefense.GameObjects
{
    public class Tower : Building
    {
        private int _level;
        private int _hitPower;
        private int _cost;
        private bool _isRemoved;

        public static readonly int DefaultCost = 25;
        public static readonly int DefaultPower = 15;
        public static readonly int DefaultRefund = 15;

        private static readonly Dictionary<int, Color> ColorDict = new Dictionary<int, Color> { { 1, Color.LightGray }, { 2, Color.DarkGray }, { 3, Color.Gray } };

        public bool IsRemoved { get => _isRemoved; set => _isRemoved = value; }

        public Tower(int player_id, int x, int y)
        {
            _level = 1;
            _hitPower = DefaultPower;
            _cost = DefaultCost;
            HittingRadius = 1;
            _stepable = false;
            _destroyable = false;

            _isRemoved = false;

            _playerID = player_id;

            _uniqueID = GetNewUniqueID();

            _xCor = x;
            _yCor = y;

            if (player_id == 0)
            {
                _borcolor = Color.Blue;
                _imgPath = "../../../images/tower_blue.png";
            }
            else
            {
                _borcolor = Color.Red;
                _imgPath = "../../../images/tower_red.png";
            }

            _color = ColorDict[_level];

            _fieldType = FieldType.TOWER;
        }

        public Tower(int level, int player_id, int x, int y)
        {
            if (level < 0 || level > 3)
                throw new ArgumentException("Value must be between 0 and 3");

            _level = level;
            _cost = level * DefaultCost;
            _hitPower = level * DefaultPower;

            _stepable = false;
            _destroyable = false;

            _isRemoved = false;

            _playerID = player_id;
            _uniqueID = GetNewUniqueID();

            _xCor = x;
            _yCor = y;

            _fieldType = FieldType.TOWER;
        }

        [JsonConstructor]
        public Tower(int player_id, int x, int y, bool stepable, bool destroyable, int health,
            string unique_id, Color borcolor, Color color, FieldType fieldtype, int level, int hittingradius, int hitpower, int cost, bool isRemoved, string imgPath)
        {
            PlayerID = player_id;
            XCor = x;
            YCor = y;
            Stepable = stepable;
            Destroyable = destroyable;
            Health = health;
            UniqueID = unique_id;
            BorderColor = borcolor;
            FieldColor = color;
            Type = fieldtype;
            Level = level;
            HittingRadius = hittingradius;
            HitPower = hitpower;
            Cost = cost;
            IsRemoved = isRemoved;
            ImgPath = imgPath;
        }

        public int Level
        {
            get => _level;
            private set
            {
               _level = value;
            }
        }

        public int HitPower
        {
            get => _hitPower;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Value must be positive");
                else
                    _hitPower = value;
            }
        }

        public int HittingRadius
        {
            get; set;
        }

        public int Cost
        {
            get => _cost;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Positive numbers expected");
                else
                    _cost = value;
            }
        }

        public void Attack(Unit target)
        {
            target.Health -= HitPower;
        }

        //Upgrades the tower if that is possible, and returns whether the tower was upgradeable
        public bool Upgrade()
        {
            if (_level == 3)
                return false;

            _level++;
            _hitPower += DefaultPower;
            _cost += DefaultCost;
            _color = ColorDict[_level];
            return true;
        }

        public void Demolish()
        {
            return;
        }

        public void CheckSurroundings()
        {
            return;
        }

        public override string[] ObjectInfo()
        {
            string[] info = { (PlayerID + 1).ToString(), Type.ToString(), Level.ToString() };
            return info;
        }
    }
}