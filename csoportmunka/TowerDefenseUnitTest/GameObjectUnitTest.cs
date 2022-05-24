using Microsoft.VisualStudio.TestTools.UnitTesting;
using TowerDefense;
using TowerDefense.GameObjects;

namespace TowerDefenseUnitTest
{
    [TestClass]
    public class GameObjectUnitTest
    {
        AbstractGameObjectFactory UnitFactory = FactoryProducer.GetFactory(false);
        AbstractGameObjectFactory BuildingFactory = FactoryProducer.GetFactory(true);

        [TestMethod]
        public void CheckStepableBuildings()
        {

            GameObject tower = BuildingFactory.GetGameObject("tower", 1, 0, 0);
            GameObject hut = BuildingFactory.GetGameObject("hut", 1, 3, 3);
            GameObject castle = BuildingFactory.GetGameObject("castle", 1, 9, 9);

            Assert.AreEqual(tower.Stepable, false);
            Assert.AreEqual(hut.Stepable, false);
            Assert.AreEqual(castle.Stepable, true);

        }

        [TestMethod]
        public void BuildingPlayerIDCheck()
        {
            GameObject tower = BuildingFactory.GetGameObject("tower", 1, 0, 0);
            GameObject hut = BuildingFactory.GetGameObject("hut", 2, 3, 3);

            Assert.AreEqual(tower.PlayerID, 1);
            Assert.AreEqual(hut.PlayerID, 2);
        }

        [TestMethod]
        public void BuildingTypeCheck()
        {
            GameObject tower = BuildingFactory.GetGameObject("tower", 1, 0, 0);
            GameObject hut = BuildingFactory.GetGameObject("hut", 1, 3, 3);
            GameObject castle = BuildingFactory.GetGameObject("castle", 1, 9, 9);

            Assert.AreEqual(tower.Type, FieldType.TOWER);
            Assert.AreEqual(hut.Type, FieldType.HUT);
            Assert.AreEqual(castle.Type, FieldType.CASTLE);
        }

        [TestMethod]
        public void BuildingCoordinateCheck()
        {
            GameObject tower = BuildingFactory.GetGameObject("tower", 1, 3, 7);
            Assert.AreEqual(3, tower.XCor);
            Assert.AreEqual(7, tower.YCor);
        }

        [TestMethod]
        public void TowerUpgradeCheck()
        {
            GameObject tower = BuildingFactory.GetGameObject("tower", 1, 3, 7);
            
            Assert.AreEqual(25, (tower as Tower).Cost);
            Assert.AreEqual(1, (tower as Tower).Level);

            Assert.AreEqual(true, (tower as Tower).Upgrade());

            Assert.AreEqual(50, (tower as Tower).Cost);
            Assert.AreEqual(2, (tower as Tower).Level);

            Assert.AreEqual(true, (tower as Tower).Upgrade());

            Assert.AreEqual(75, (tower as Tower).Cost);
            Assert.AreEqual(3, (tower as Tower).Level);

            Assert.AreEqual(false, (tower as Tower).Upgrade());
        }

        [TestMethod]
        public void CheckStepableUnits()
        {
            GameObject cavalry = UnitFactory.GetGameObject("cavalry", 1, 0, 0);
            GameObject troop = UnitFactory.GetGameObject("troop", 1, 0, 0);


            Assert.AreEqual(cavalry.Stepable, true);
            Assert.AreEqual(troop.Stepable, true);

        }

        [TestMethod]
        public void UnitPlayerIDCheck()
        {
            GameObject cavalry = UnitFactory.GetGameObject("cavalry", 1, 0, 0);
            GameObject troop = UnitFactory.GetGameObject("troop", 2, 0, 0);

            Assert.AreEqual(cavalry.PlayerID, 1);
            Assert.AreEqual(troop.PlayerID, 2);

        }

        [TestMethod]
        public void CheckUnitHealth()
        {
            GameObject cavalry = UnitFactory.GetGameObject("cavalry", 1, 0, 0);
            GameObject troop = UnitFactory.GetGameObject("troop", 2, 0, 0);

            Assert.AreEqual(100, cavalry.Health);
            Assert.AreEqual(50, troop.Health);

            cavalry.Health -= 25;
            troop.Health -= 100;

            Assert.AreEqual(75, cavalry.Health);
            Assert.IsTrue(troop.Health <= 0);
        }

        public void CheckUnitType()
        {
            GameObject cavalry = UnitFactory.GetGameObject("cavalry", 1, 0, 0);
            GameObject troop = UnitFactory.GetGameObject("troop", 2, 0, 0);

            Assert.AreEqual(cavalry.Type, FieldType.CAVALRY);
            Assert.AreEqual(troop.Type, FieldType.TROOP);
        }

        [TestMethod]
        public void UnitCoordinateCheck()
        {
            GameObject troop = UnitFactory.GetGameObject("troop", 2, 1, 1);
            Assert.AreEqual(1, troop.XCor);
            Assert.AreEqual(1, troop.YCor);
        }
    }
}
