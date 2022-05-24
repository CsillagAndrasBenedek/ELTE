using System;
using System.Collections.Generic;
using System.Drawing;
using TowerDefense.Model;
using Newtonsoft.Json;

namespace TowerDefense.GameObjects
{
    public abstract class Unit : GameObject
    {
        protected int _hit;
        protected int _cost;
        protected int _stepSize;
        protected bool _isDead;

        protected LinkedList<Position> _pathToShortest;

        public int Hit
        {
            get => _hit;
            set => _hit = value;
        }

        public int Cost
        {
            get => _cost;
            set => _cost = value;
        }

        public int StepSize
        {
            get => _stepSize;
            set
            {
                if (value >= 0)
                    _stepSize = value;
                else
                    throw new ArgumentException("Number must be non negative");
            }
        }

        public LinkedList<Position> PathToShortest
        {
            get => _pathToShortest;
            set => _pathToShortest = value;
        }
        public bool IsDead { get => _isDead; set => _isDead = value; }

        public void Move()
        {
            if (_pathToShortest.Count == 0)
                return;

            LinkedListNode<Position> next = _pathToShortest.First;
            _pathToShortest.RemoveFirst();

            XCor = next.Value.X;
            YCor = next.Value.Y;


        }

        public void Attack(Castle target)
        {
            target.Health -= Hit;
        }
    }

    public class Troop : Unit
    {
        private static readonly int MaxHealth = 50;
        private static readonly int TroopHitPower = 10;
        public static readonly int TroopCost = 25;
        public static readonly int DefaultStepsize = 3;

        public Troop(int player_id, int x, int y)
        {
            _health = MaxHealth;
            _hit = TroopHitPower;
            _cost = TroopCost;

            _stepSize = DefaultStepsize;
            _isDead = false;

            _stepable = true;

            _playerID = player_id;
            _uniqueID = GetNewUniqueID();

            if (player_id == 0)
            {
                _borcolor = Color.Blue;
                _imgPath = "../../../images/soldier_blue.png";
            }
            else
            {
                _borcolor = Color.Red;
                _imgPath = "../../../images/soldier_red.png";
            }

            _xCor = x;
            _yCor = y;

            _color = Color.Crimson;

            _fieldType = FieldType.TROOP;
        }

        [JsonConstructor]
        public Troop(int player_id, int x, int y, bool stepable, int health,
            string unique_id, Color borcolor, Color color, FieldType fieldtype, int hit, int cost, int stepsize, bool isdead, string imgPath)
        {
            PlayerID = player_id;
            XCor = x;
            YCor = y;
            Stepable = stepable;
            Health = health;
            StepSize = stepsize;
            UniqueID = unique_id;
            BorderColor = borcolor;
            FieldColor = color;
            Type = fieldtype;
            Hit = hit;
            Cost = cost;
            IsDead = isdead;
            ImgPath = imgPath;
        }

        public int MaxHP
        {
            get => MaxHealth;
        }

        public override string[] ObjectInfo()
        {
            string[] info = { (PlayerID + 1).ToString(), Type.ToString(), Health.ToString() };
            return info;
        }
    }

    public class Cavalry : Unit
    {
        private static readonly int MaxHealth = 100;
        private static readonly int CavalryHitPower = 15;
        public static readonly int CavalryCost = 35;
        public static readonly int DefaultStepsize = 3;

        public Cavalry(int player_id, int x, int y)
        {
            _health = MaxHealth;
            _hit = CavalryHitPower;
            _cost = CavalryCost;
            _stepSize = DefaultStepsize;

            _stepable = true;
            _playerID = player_id;
            _uniqueID = GetNewUniqueID();
            _isDead = false;

            _xCor = x;
            _yCor = y;

            if (player_id == 0)
            {
                _borcolor = Color.Blue;
                _imgPath = "../../../images/horse_blue.png";
            }
            else
            {
                _borcolor = Color.Red;
                _imgPath = "../../../images/horse_red.png";
            }

            _color = Color.DarkRed;

            _fieldType = FieldType.CAVALRY;

            _pathToShortest = null;
        }

        [JsonConstructor]
        public Cavalry(int player_id, int x, int y, bool stepable, int health,
            string unique_id, Color borcolor, Color color, FieldType fieldtype, int hit, int cost, int stepsize, bool isdead, string imgPath)
        {
            PlayerID = player_id;
            XCor = x;
            YCor = y;
            Stepable = stepable;
            Health = health;
            StepSize = stepsize;
            UniqueID = unique_id;
            BorderColor = borcolor;
            FieldColor = color;
            Type = fieldtype;
            Hit = hit;
            Cost = cost;
            IsDead = isdead;
            ImgPath = imgPath;
        }

        public int MaxHP
        {
            get => MaxHealth;
        }

        public override string[] ObjectInfo()
        {
            string[] info = { (PlayerID + 1).ToString(), Type.ToString(), Health.ToString() };
            return info;
        }
    }
}