using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TowerDefense;
using TowerDefense.GameObjects;
using TowerDefense.Model;

namespace TowerDefenseUnitTest
{
    [TestClass]
    public class UtilsUnitTest
    {
        AbstractGameObjectFactory UnitFactory = FactoryProducer.GetFactory(false);
        AbstractGameObjectFactory BuildingFactory = FactoryProducer.GetFactory(true);

        [TestMethod]
        public void SimpleShortestPath()
        {
            GameBoard board = new GameBoard(4, 4);
            GameObject castle = BuildingFactory.GetGameObject("castle", 1, 3, 3);
            GameObject troop = UnitFactory.GetGameObject("troop", 2, 0, 0);

            board.SetObjects(0, 1, new List<GameObject>());

            for(int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    board.SetObjects(i, j, new List<GameObject>());
                }

            }

            board.SetObjects(castle.XCor, castle.YCor, new List<GameObject>() { castle });
            board.SetObjects(castle.XCor, castle.YCor, new List<GameObject>() { troop });

            PathFinder pf = new PathFinder(board, troop.XCor, troop.YCor, castle.XCor, castle.YCor);

            LinkedList<Position> res = pf.GetShortestPath();

            Assert.AreEqual(6, res.Count);
        }
        [TestMethod]
        public void PathWithTowers()
        {
            GameBoard board = new GameBoard(5, 5);
            GameObject castle = BuildingFactory.GetGameObject("castle", 1, 4, 4);
            GameObject troop = UnitFactory.GetGameObject("troop", 2, 0, 0);

            board.SetObjects(0, 1, new List<GameObject>());

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    board.SetObjects(i, j, new List<GameObject>());
                }

            }

            GameObject tower1 = BuildingFactory.GetGameObject("tower", 1, 0, 1);
            GameObject tower2 = BuildingFactory.GetGameObject("tower", 1, 1, 1);
            GameObject tower3 = BuildingFactory.GetGameObject("tower", 1, 2, 1);
            GameObject tower4 = BuildingFactory.GetGameObject("tower", 1, 3, 1);

            board.SetObjects(castle.XCor, castle.YCor, new List<GameObject>() { castle });
            board.SetObjects(castle.XCor, castle.YCor, new List<GameObject>() { troop });

            board.SetObjects(tower1.XCor, tower1.YCor, new List<GameObject>() { tower1 });
            board.SetObjects(tower2.XCor, tower2.YCor, new List<GameObject>() { tower2 });
            board.SetObjects(tower3.XCor, tower3.YCor, new List<GameObject>() { tower3 });
            board.SetObjects(tower4.XCor, tower3.YCor, new List<GameObject>() { tower4 });

            GameObject tower5 = BuildingFactory.GetGameObject("tower", 1, 1, 3);
            GameObject tower6 = BuildingFactory.GetGameObject("tower", 1, 2, 3);
            GameObject tower7 = BuildingFactory.GetGameObject("tower", 1, 3, 3);
            GameObject tower8 = BuildingFactory.GetGameObject("tower", 1, 4, 3);

            board.SetObjects(tower5.XCor, tower5.YCor, new List<GameObject>() { tower5 });
            board.SetObjects(tower6.XCor, tower6.YCor, new List<GameObject>() { tower6 });
            board.SetObjects(tower7.XCor, tower7.YCor, new List<GameObject>() { tower7 });
            board.SetObjects(tower8.XCor, tower8.YCor, new List<GameObject>() { tower8 });



            PathFinder pf = new PathFinder(board, troop.XCor, troop.YCor, castle.XCor, castle.YCor);

            LinkedList<Position> res = pf.GetShortestPath();

            Assert.AreEqual(16, res.Count);
        }

        [TestMethod]
        public void PathWithTowersNoSolution()
        {
            GameBoard board = new GameBoard(5, 5);
            GameObject castle = BuildingFactory.GetGameObject("castle", 1, 4, 4);
            GameObject troop = UnitFactory.GetGameObject("troop", 2, 0, 0);

            board.SetObjects(0, 1, new List<GameObject>());

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    board.SetObjects(i, j, new List<GameObject>());
                }

            }

            GameObject tower1 = BuildingFactory.GetGameObject("tower", 1, 0, 1);
            GameObject tower2 = BuildingFactory.GetGameObject("tower", 1, 1, 1);
            GameObject tower3 = BuildingFactory.GetGameObject("tower", 1, 2, 1);
            GameObject tower4 = BuildingFactory.GetGameObject("tower", 1, 3, 1);

            board.SetObjects(castle.XCor, castle.YCor, new List<GameObject>() { castle });
            board.SetObjects(castle.XCor, castle.YCor, new List<GameObject>() { troop });

            board.SetObjects(tower1.XCor, tower1.YCor, new List<GameObject>() { tower1 });
            board.SetObjects(tower2.XCor, tower2.YCor, new List<GameObject>() { tower2 });
            board.SetObjects(tower3.XCor, tower3.YCor, new List<GameObject>() { tower3 });
            board.SetObjects(tower4.XCor, tower3.YCor, new List<GameObject>() { tower4 });

            GameObject tower5 = BuildingFactory.GetGameObject("tower", 1, 1, 3);
            GameObject tower6 = BuildingFactory.GetGameObject("tower", 1, 2, 3);
            GameObject tower7 = BuildingFactory.GetGameObject("tower", 1, 3, 3);
            GameObject tower8 = BuildingFactory.GetGameObject("tower", 1, 4, 3);

            GameObject tower9 = BuildingFactory.GetGameObject("tower", 1, 3, 4);

            board.SetObjects(tower5.XCor, tower5.YCor, new List<GameObject>() { tower5 });
            board.SetObjects(tower6.XCor, tower6.YCor, new List<GameObject>() { tower6 });
            board.SetObjects(tower7.XCor, tower7.YCor, new List<GameObject>() { tower7 });
            board.SetObjects(tower8.XCor, tower8.YCor, new List<GameObject>() { tower8 });

            board.SetObjects(tower9.XCor, tower9.YCor, new List<GameObject>() { tower9 });



            PathFinder pf = new PathFinder(board, troop.XCor, troop.YCor, castle.XCor, castle.YCor);

            LinkedList<Position> res = pf.GetShortestPath();

            Assert.AreEqual(0, res.Count);
        }
    }
}
