using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Newtonsoft.Json;

namespace TowerDefense.GameObjects
{
    public class Castle : Building
    {
        //private int _health = 100;
        public bool _standing = true;

        public Castle(int player_id, int x, int y)
        {
            _stepable = true;
            _destroyable = true;

            _playerID = player_id;
            _health = 100;

            _uniqueID = GetNewUniqueID();

            _xCor = x;
            _yCor = y;

            if (player_id == 0)
            {
                _borcolor = Color.Blue;
                _imgPath = "../../../images/castle_blue.png";
            }
            else
            {
                _borcolor = Color.Red;
                _imgPath = "../../../images/castle_red.png";
            }

            _color = Color.SkyBlue;

            _fieldType = FieldType.CASTLE;
        }

        [JsonConstructor]
        public Castle(int player_id, int x, int y, bool stepable, bool destroyable, int health, string unique_id, Color borcolor, Color color, FieldType fieldtype, string imgPath)
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
            ImgPath = imgPath;
        }
        
        public bool Standing
        {
            get => _standing;
            set => _standing = value;
        }

        public override string[] ObjectInfo()
        {
            string [] info = { (PlayerID+1).ToString(), Type.ToString(), Health.ToString()};
            return info;
        }

    }
}