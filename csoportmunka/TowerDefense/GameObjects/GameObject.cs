using System;
using System.Drawing;

namespace TowerDefense
{
    public enum FieldType { CASTLE, HUT, TOWER, TROOP, CAVALRY, MOUNTAIN };
    public abstract class GameObject
    {
        protected string _uniqueID;
        protected int _playerID;

        protected bool _stepable;

        protected Color _color;
        protected Color _borcolor;

        protected string _imgPath;

        protected int _xCor;
        protected int _yCor;

        protected FieldType _fieldType;

        protected int _health;

        public int Health 
        {   
            get => _health;
            set
            {
                if (_health < 0)
                    _health = 0;
                else
                    _health = value;
            }
        }

        public FieldType Type
        {
            get => _fieldType;
            set => _fieldType = value;
        }


        public string UniqueID
        {
            get => _uniqueID;
            set => _uniqueID = value;
        }


        public string GetNewUniqueID()
        {
            return string.Format(@"{0}", Guid.NewGuid());
        }

        public int PlayerID
        {
            get => _playerID;
            set => _playerID = value;
        }

        public int XCor
        {
            get => _xCor;

            set
            {
                if (value >= 0)
                    _xCor = value;
                else
                    throw new ArgumentException("Number must be non negative");
            }
        }
        public int YCor
        {
            get => _yCor;
            set
            {
                if (value >= 0)
                    _yCor = value;
                else
                    throw new ArgumentException("Number must be non negative");
            }
        }

        public Color FieldColor
        {
            get => _color;
            set => _color = value;
        }

        public Color BorderColor
        {
            get => _borcolor;
            set => _borcolor = value;
        }

        public string ImgPath
        {
            get => _imgPath;
            set => _imgPath = value;
        }

        public bool Stepable
        {
            get => _stepable;
            set => _stepable = value;
        }


        public abstract string[] ObjectInfo();
    }
}