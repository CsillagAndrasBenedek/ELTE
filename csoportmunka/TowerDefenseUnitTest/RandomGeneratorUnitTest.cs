using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.Model;
using TowerDefense.Persistence;

namespace TowerDefenseUnitTest
{
    [TestClass]
    public class RandomGeneratorUnitTest
    {
        private GameModel _model;
        private Mock<IDataAccess> _mock;
        

        [TestInitialize]
        public void Initialize() 
        {
            _mock = new Mock<IDataAccess>();
            _model = new GameModel(_mock.Object);
        }


        [TestMethod]
        public void CheckingSmallBoardSize() 
        {
            _model.StartNewGame(MapSize.SMALL);
            Assert.AreEqual(_model.Board.MapHeight,10);
            Assert.AreEqual(_model.Board.MapWidth, 11);
        }

        [TestMethod]
        public void CheckingMediumBoardSize()
        {
            _model.StartNewGame(MapSize.MEDIUM);
            Assert.AreEqual(_model.Board.MapHeight, 12);
            Assert.AreEqual(_model.Board.MapWidth, 13);
        }

        [TestMethod]
        public void CheckingLargeBoardSize()
        {
            _model.StartNewGame(MapSize.LARGE);
            Assert.AreEqual(_model.Board.MapHeight, 14);
            Assert.AreEqual(_model.Board.MapWidth, 15);
        }


        [TestMethod]
        public void CheckingRandomZeroOrOne()
        {
            _model.StartNewGame(MapSize.SMALL);
            int generated = _model.RandomGeneratorZeroOrOne();
            Assert.IsTrue(generated == 0 || generated == 1);
        }

        [TestMethod]
        public void CheckingRandomCastlePositions()
        {
            _model.StartNewGame(MapSize.SMALL);


            List<Position> castlePos =_model.GenerateCastlePositions(_model.Board.MapHeight, _model.Board.MapWidth);

            //Number of huts are correct
            Assert.AreEqual(castlePos.Count, 2);

            //Indexes between boundaries
            Assert.IsTrue(castlePos[0].X > 0 && castlePos[0].X < _model.Board.MapHeight - 1);
            Assert.IsTrue(castlePos[0].Y > 0 && castlePos[0].Y < _model.Board.MapWidth - 1);
            Assert.IsTrue(castlePos[1].X > 0 && castlePos[1].X < _model.Board.MapHeight - 1);
            Assert.IsTrue(castlePos[1].Y > 0 && castlePos[1].Y < _model.Board.MapWidth - 1);

            //Castles are at least two-square distance away from each other
            Assert.IsTrue(Math.Abs(castlePos[0].X - castlePos[1].X) > 2 || Math.Abs(castlePos[0].Y - castlePos[1].Y) > 2);
        }

        [TestMethod]
        public void CheckingRandomHutPositions()
        {
            _model.StartNewGame(MapSize.SMALL);


            List<Position> castlePos = _model.GenerateCastlePositions(_model.Board.MapHeight, _model.Board.MapWidth);
            _model.Castles[0] = new TowerDefense.GameObjects.Castle(0, castlePos[0].X, castlePos[0].Y);
            _model.Castles[1] = new TowerDefense.GameObjects.Castle(1, castlePos[1].X, castlePos[1].Y);


            List<Position> hutPos = _model.GenerateHutPositions(_model.Board.MapHeight, _model.Board.MapWidth);
            
            //Number of huts are correct
            Assert.AreEqual(hutPos.Count, 4);

            //Indexes between boundaries
            Assert.IsTrue(hutPos[0].X >= 0 && hutPos[0].X < _model.Board.MapHeight);
            Assert.IsTrue(hutPos[0].Y >= 0 && hutPos[0].Y < _model.Board.MapWidth);
            Assert.IsTrue(hutPos[1].X >= 0 && hutPos[1].X < _model.Board.MapHeight);
            Assert.IsTrue(hutPos[1].Y >= 0 && hutPos[1].Y < _model.Board.MapWidth);
            Assert.IsTrue(hutPos[2].X >= 0 && hutPos[2].X < _model.Board.MapHeight);
            Assert.IsTrue(hutPos[2].Y >= 0 && hutPos[2].Y < _model.Board.MapWidth);
            Assert.IsTrue(hutPos[3].X >= 0 && hutPos[3].X < _model.Board.MapHeight);
            Assert.IsTrue(hutPos[3].Y >= 0 && hutPos[3].Y < _model.Board.MapWidth);


            //Huts are at least one-square distance away from castles
            Assert.IsTrue(Math.Abs(hutPos[0].X - castlePos[0].X) > 1 || Math.Abs(hutPos[0].Y - castlePos[0].Y) > 1);
            Assert.IsTrue(Math.Abs(hutPos[0].X - castlePos[1].X) > 1 || Math.Abs(hutPos[0].Y - castlePos[1].Y) > 1);
            
            Assert.IsTrue(Math.Abs(hutPos[1].X - castlePos[0].X) > 1 || Math.Abs(hutPos[1].Y - castlePos[0].Y) > 1);
            Assert.IsTrue(Math.Abs(hutPos[1].X - castlePos[1].X) > 1 || Math.Abs(hutPos[1].Y - castlePos[1].Y) > 1);

            Assert.IsTrue(Math.Abs(hutPos[2].X - castlePos[0].X) > 1 || Math.Abs(hutPos[2].Y - castlePos[0].Y) > 1);
            Assert.IsTrue(Math.Abs(hutPos[2].X - castlePos[1].X) > 1 || Math.Abs(hutPos[2].Y - castlePos[1].Y) > 1);

            Assert.IsTrue(Math.Abs(hutPos[3].X - castlePos[0].X) > 1 || Math.Abs(hutPos[3].Y - castlePos[0].Y) > 1);
            Assert.IsTrue(Math.Abs(hutPos[3].X - castlePos[1].X) > 1 || Math.Abs(hutPos[3].Y - castlePos[1].Y) > 1);


            //Every huts has different positions
            Assert.IsTrue(hutPos[0].X != hutPos[1].X || hutPos[0].X != hutPos[1].Y);
            Assert.IsTrue(hutPos[0].X != hutPos[2].X || hutPos[0].X != hutPos[2].Y);
            Assert.IsTrue(hutPos[0].X != hutPos[3].X || hutPos[0].X != hutPos[3].Y);

            Assert.IsTrue(hutPos[1].X != hutPos[2].X || hutPos[1].X != hutPos[2].Y);
            Assert.IsTrue(hutPos[1].X != hutPos[3].X || hutPos[1].X != hutPos[3].Y);

            Assert.IsTrue(hutPos[2].X != hutPos[3].X || hutPos[2].X != hutPos[3].Y);
        }

        [TestMethod]
        public void CheckingRandomObstaclePositions()
        {
            _model.StartNewGame(MapSize.SMALL);


            List<Position> castlePos = _model.GenerateCastlePositions(_model.Board.MapHeight, _model.Board.MapWidth);
            _model.Castles[0] = new TowerDefense.GameObjects.Castle(0, castlePos[0].X, castlePos[0].Y);
            _model.Castles[1] = new TowerDefense.GameObjects.Castle(1, castlePos[1].X, castlePos[1].Y);


            List<Position> hutPos = _model.GenerateHutPositions(_model.Board.MapHeight, _model.Board.MapWidth);
            _model.Huts[0] = new TowerDefense.GameObjects.Hut(0,hutPos[0].X, hutPos[0].Y);
            _model.Huts[1] = new TowerDefense.GameObjects.Hut(1, hutPos[1].X, hutPos[1].Y);
            _model.Huts[2] = new TowerDefense.GameObjects.Hut(0, hutPos[2].X, hutPos[2].Y);
            _model.Huts[3] = new TowerDefense.GameObjects.Hut(1, hutPos[3].X, hutPos[3].Y);

            List<Position> obstaclePos = _model.GenerateObstaclePositions(_model.Board.MapHeight, _model.Board.MapWidth);

            _model.Obstacles = new TowerDefense.GameObjects.Obstacle[obstaclePos.Count];
            for (int i = 0; i < obstaclePos.Count; i++)
            {
                _model.Obstacles[i] = new TowerDefense.GameObjects.Obstacle(obstaclePos[i].X, obstaclePos[i].Y);
            }

            //Number of obstacles are correct
            int tenPercent = (int)((_model.Board.MapHeight * _model.Board.MapWidth) / 10);
            Assert.AreEqual(obstaclePos.Count, tenPercent );

            //Indexes between boundaries
            for (int i = 0; i < obstaclePos.Count; i++)
            {
                
                Assert.IsTrue(obstaclePos[i].X >= 0 && obstaclePos[i].X < _model.Board.MapHeight);
                Assert.IsTrue(obstaclePos[i].Y >= 0 && obstaclePos[i].Y < _model.Board.MapWidth);
            }

            //Obstacles are at least one-square distance away from ...
            for (int i = 0; i < obstaclePos.Count; i++)
            {
                //... castles
                Assert.IsTrue(Math.Abs(obstaclePos[i].X - castlePos[0].X) > 1 || Math.Abs(obstaclePos[i].Y - castlePos[0].Y) > 1);
                Assert.IsTrue(Math.Abs(obstaclePos[i].X - castlePos[1].X) > 1 || Math.Abs(obstaclePos[i].Y - castlePos[1].Y) > 1);

                //... huts
                Assert.IsTrue(Math.Abs(obstaclePos[i].X - hutPos[0].X) > 1 || Math.Abs(obstaclePos[i].Y - hutPos[0].Y) > 1);
                Assert.IsTrue(Math.Abs(obstaclePos[i].X - hutPos[1].X) > 1 || Math.Abs(obstaclePos[i].Y - hutPos[1].Y) > 1);
                Assert.IsTrue(Math.Abs(obstaclePos[i].X - hutPos[2].X) > 1 || Math.Abs(obstaclePos[i].Y - hutPos[2].Y) > 1);
                Assert.IsTrue(Math.Abs(obstaclePos[i].X - hutPos[3].X) > 1 || Math.Abs(obstaclePos[i].Y - hutPos[3].Y) > 1);


            }

            //Every obstacle positions are different
            for (int i = 0; i < obstaclePos.Count - 1; i++)
            {
                for (int j = i + 1; j < obstaclePos.Count; j++)
                {
                    Assert.IsTrue(obstaclePos[i].X != obstaclePos[j].X || obstaclePos[i].Y != obstaclePos[j].Y);
                }
            }
        }

    }
}
