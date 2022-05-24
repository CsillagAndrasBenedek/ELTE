using System;

namespace TowerDefense.GameObjects
{

    public abstract class AbstractGameObjectFactory
    {
        public abstract GameObject GetGameObject(string type, int player_id, int x, int y);
    }
    class UnitFactory: AbstractGameObjectFactory
    {
  
        public override GameObject GetGameObject(string type, int player_id, int x, int y)
        {
            return type.ToLower() switch
            {
                "cavalry" => new Cavalry(player_id, x, y),
                "troop" => new Troop(player_id, x, y),
                _ => throw new ArgumentException("Units can be cavalry or troop")
            };
        }
    }

    class BuildingFactory: AbstractGameObjectFactory
    {
        public override GameObject GetGameObject(string type, int player_id, int x, int y)
        {
            return type.ToLower() switch
            {
                "tower" => new Tower(player_id, x, y),
                "castle" => new Castle(player_id, x, y),
                "hut" => new Hut(player_id, x, y),
                _ => throw new ArgumentException("Buildings can be tower, hut, or castle")
            };
        }
    }

    public class FactoryProducer
    {
        private static BuildingFactory _buildingFactory;
        private static UnitFactory _unitFactory;

        public static AbstractGameObjectFactory GetFactory(bool IsBuilding)
        {
            if(IsBuilding)
            {
                if(_buildingFactory == null)
                    _buildingFactory = new BuildingFactory();
                return _buildingFactory;
            }
            else
            {
                if (_unitFactory == null)
                    _unitFactory = new UnitFactory();
                return _unitFactory;
            }
        }
    }
}
