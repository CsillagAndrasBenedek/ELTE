using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Newtonsoft.Json;

namespace TowerDefense.GameObjects
{
    public class Hut : Building
    {
        public Hut(int player_id, int x, int y)
        {
            _stepable = false;
            _destroyable = false;

            _playerID = player_id;
            _uniqueID = GetNewUniqueID();

            _xCor = x;
            _yCor = y;

            if (player_id == 0)
            {
                _borcolor = Color.Blue;
                _imgPath = "../../../images/barracks_blue.png";
            }
            else
            {
                _borcolor = Color.Red;
                _imgPath = "../../../images/barracks_red.png";
            }

            _color = Color.MediumSeaGreen;

            _fieldType = FieldType.HUT;
        }

        [JsonConstructor]
        public Hut(int player_id, int x, int y, bool stepable, bool destroyable, int health, string unique_id, Color borcolor, Color color, FieldType fieldtype, string imgPath)
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

        public void TrainUnits(int amount, string type, int player_id, int x, int y)
        {
            UnitFactory uf = new UnitFactory();


            for (int i = 0; i < amount; i++)
                _ = uf.GetGameObject(type, player_id, x, y); //valamihez hozza kell majd adni
        }

        public override string[] ObjectInfo()
        {
            string[] info = { (PlayerID + 1).ToString(), Type.ToString(), "-" };
            return info;
        }
    }
}