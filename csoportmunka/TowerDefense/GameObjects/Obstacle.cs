using System;
using System.Drawing;
using Newtonsoft.Json;

namespace TowerDefense.GameObjects
{
    public class Obstacle : GameObject
    {
        public static readonly int MinObstacles = 2;

        public Obstacle(int x, int y)
        {
            _fieldType = FieldType.MOUNTAIN;
            _color = Color.SaddleBrown;
            _imgPath = "../../../images/mountains.png";

            _stepable = false;
            _playerID = -1;
            _uniqueID = GetNewUniqueID();

            _xCor = x;
            _yCor = y;
        }

        [JsonConstructor]
        public Obstacle(int player_id, int x, int y, bool stepable, int health, string unique_id, Color borcolor, Color color, FieldType fieldtype, string imgPath)
        {
            PlayerID = player_id;
            XCor = x;
            YCor = y;
            Stepable = stepable;
            Health = health;
            UniqueID = unique_id;
            BorderColor = borcolor;
            FieldColor = color;
            Type = fieldtype;
            ImgPath = imgPath;
        }

        public override string[] ObjectInfo()
        {
            string[] info = { "-", Type.ToString(), "-" };
            return info;
        }
    }
}