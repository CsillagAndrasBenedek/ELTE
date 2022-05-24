using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TowerDefense;
using TowerDefense.EventArguments;
using TowerDefense.Model;
using TowerDefense.Persistence;

namespace TowerDefenseUnitTest
{
    [TestClass]
    public class MapEditorUnitTest
    {
        MapModel model = new MapModel(new DataAccess());
        bool _eventRaised;
        object _eventSource;
        string _eventType;
        MapFieldChangedEventArgs _eventArgs;
        EventArgs _e;

        void SetUp()
        {
            for (int i = 0; i < model.Board.MapHeight; ++i)
            {
                for (int j = 0; j < model.Board.MapWidth; ++j)
                {

                    if (model.Board.GetObjects(i, j) == null)
                    {
                        model.Board.SetObjects(i, j, new List<GameObject>());
                    }
                }
            }

            model.MapFieldChanged += new EventHandler<MapFieldChangedEventArgs>(OnMapFieldChanged);
            model.MapCorrect += new EventHandler<EventArgs> (OnMapCorrect);
        }

        void OnMapFieldChanged(object source, MapFieldChangedEventArgs e)
        {
            _eventRaised = true;
            _eventSource = source;
            _eventArgs = e;
            _eventType = "MapFieldChanged";
        }

        void OnMapCorrect(object source, EventArgs e)
        {
            _eventRaised = true;
            _eventSource = source;
            _e = e;
            _eventType = "MapCorrect";
        }

        [TestMethod]

        public void CheckNewMap()
        {
            model.StartNewMap(10, 15);
            SetUp();
            Assert.AreEqual(10, model.Board.MapHeight);
            Assert.AreEqual(15, model.Board.MapWidth);
            Assert.AreEqual(model.CurrentPressed, MapPressed.NONE);
            for (int i = 0; i < model.PlayerNum; i++)
            {
                Assert.AreEqual(false, model.CastlesExist[i]);
                Assert.AreEqual(model.HutNum, model.HutsLeft[i]);
            }
            Assert.AreEqual(0, model.ObstaclesPlaced);
        }


        
        [TestMethod]
        public void CorrectMapCheck()
        {
            model.StartNewMap(10, 15);
            SetUp();
            model.Build(MapPressed.CASTLE1);
            model.HandleBuyPhase(0, 0);
            model.Build(MapPressed.CASTLE2);
            model.HandleBuyPhase(3, 3);
            model.Build(MapPressed.HUT1);
            model.HandleBuyPhase(5, 5);
            model.Build(MapPressed.HUT2);
            model.HandleBuyPhase(6, 6);
            model.Build(MapPressed.HUT1);
            model.HandleBuyPhase(7, 7);
            model.Build(MapPressed.HUT2);
            model.HandleBuyPhase(8, 8);
            model.Build(MapPressed.OBSTACLE);
            model.HandleBuyPhase(9, 9);
            model.Build(MapPressed.OBSTACLE);
            model.HandleBuyPhase(7, 8);
            model.CheckPath();
            Assert.IsTrue(_eventRaised);
            Assert.AreSame(model, _eventSource);
            Assert.AreEqual("MapCorrect", _eventType);
        }

        [TestMethod]
        public void IncorrectMapCheck()
        {
            model.StartNewMap(10, 15);
            SetUp();
            model.Build(MapPressed.CASTLE1);
            model.HandleBuyPhase(0, 0);
            model.Build(MapPressed.CASTLE2);
            model.HandleBuyPhase(4, 0);
            model.Build(MapPressed.HUT1);
            model.HandleBuyPhase(2, 0);
            model.Build(MapPressed.HUT2);
            model.HandleBuyPhase(6, 6);
            model.Build(MapPressed.HUT1);
            model.HandleBuyPhase(2, 1);
            model.Build(MapPressed.HUT2);
            model.HandleBuyPhase(8, 8);
            model.Build(MapPressed.OBSTACLE);
            model.HandleBuyPhase(0, 2);
            model.Build(MapPressed.OBSTACLE);
            model.HandleBuyPhase(1, 2);
            model.CheckPath();
            Assert.IsTrue(_eventRaised);
            Assert.AreSame(model, _eventSource);
            Assert.AreEqual("MapFieldChanged", _eventType);
            Assert.AreEqual(_eventArgs.CastlesExist, model.CastlesExist);
            Assert.AreEqual(_eventArgs.HutsLeft, model.HutsLeft);
            Assert.AreEqual(_eventArgs.ObstaclesPlaced, model.ObstaclesPlaced);
        }

        [TestMethod]

        public void CheckCastleBuild()
        {
            model.StartNewMap(10, 15);
            SetUp();
            model.Build(MapPressed.CASTLE1);
            Assert.AreEqual(MapPressed.CASTLE1, model.CurrentPressed);
            model.Build(MapPressed.CASTLE1);
            Assert.AreEqual(MapPressed.NONE, model.CurrentPressed);

            model.Build(MapPressed.CASTLE2);
            Assert.AreEqual(MapPressed.CASTLE2, model.CurrentPressed);
            model.Build(MapPressed.CASTLE2);
            Assert.AreEqual(MapPressed.NONE, model.CurrentPressed);


            Assert.IsTrue(_eventRaised);
            Assert.AreSame(model, _eventSource);
            Assert.AreEqual("MapFieldChanged", _eventType);
        }

        [TestMethod]
        public void CheckHutBuild()
        {
            model.StartNewMap(10, 10);
            SetUp();
            model.Build(MapPressed.HUT1);
            Assert.AreEqual(MapPressed.HUT1, model.CurrentPressed);
            model.Build(MapPressed.HUT1);
            Assert.AreEqual(MapPressed.NONE, model.CurrentPressed);
            model.Build(MapPressed.HUT2);
            Assert.AreEqual(MapPressed.HUT2, model.CurrentPressed);
            model.Build(MapPressed.HUT2);
            Assert.AreEqual(MapPressed.NONE, model.CurrentPressed);


            Assert.IsTrue(_eventRaised);
            Assert.AreSame(model, _eventSource);
            Assert.AreEqual("MapFieldChanged", _eventType);
        }

        [TestMethod]
        public void CheckObstacleBuild()
        {
            model.StartNewMap(10, 10);
            SetUp();
            model.Build(MapPressed.OBSTACLE);
            Assert.AreEqual(MapPressed.OBSTACLE, model.CurrentPressed);
            model.Build(MapPressed.OBSTACLE);
            Assert.AreEqual(MapPressed.NONE, model.CurrentPressed);


            Assert.IsTrue(_eventRaised);
            Assert.AreSame(model, _eventSource);
            Assert.AreEqual("MapFieldChanged", _eventType);
        }

        [TestMethod]
        public void CheckDeleteBuild()
        {
            model.StartNewMap(10, 10);
            SetUp();
            model.Build(MapPressed.DELETE);
            Assert.AreEqual(MapPressed.DELETE, model.CurrentPressed);
            model.Build(MapPressed.DELETE);
            Assert.AreEqual(MapPressed.NONE, model.CurrentPressed);


            Assert.IsTrue(_eventRaised);
            Assert.AreSame(model, _eventSource);
            Assert.AreEqual("MapFieldChanged", _eventType);
        }

        [TestMethod]
        public void CheckCastleBuy()
        {
            model.StartNewMap(10, 10);
            SetUp();
            model.Build(MapPressed.CASTLE1);
            model.HandleBuyPhase(0, 0);
            Assert.AreEqual(MapPressed.NONE, model.CurrentPressed);
            Assert.AreEqual(true, model.CastlesExist[0]);
            Assert.AreEqual(false, model.CastlesExist[1]);
            Assert.AreEqual(1, model.Board.GetObjects(0, 0).Count);
            Assert.AreEqual(FieldType.CASTLE, model.Board.GetObjects(0, 0)[0].Type);
            Assert.AreEqual(0, model.Board.GetObjects(0, 0)[0].PlayerID);
            Assert.AreEqual(0, model.Board.GetObjects(0, 0)[0].XCor);
            Assert.AreEqual(0, model.Board.GetObjects(0, 0)[0].YCor);

            model.Build(MapPressed.CASTLE2);
            model.HandleBuyPhase(0, 0);
            Assert.AreEqual(MapPressed.CASTLE2, model.CurrentPressed);
            model.HandleBuyPhase(3, 5);
            Assert.AreEqual(MapPressed.NONE, model.CurrentPressed);
            Assert.AreEqual(true, model.CastlesExist[0]);
            Assert.AreEqual(true, model.CastlesExist[1]);
            Assert.AreEqual(1, model.Board.GetObjects(3, 5).Count);
            Assert.AreEqual(FieldType.CASTLE, model.Board.GetObjects(3, 5)[0].Type);
            Assert.AreEqual(1, model.Board.GetObjects(3, 5)[0].PlayerID);
            Assert.AreEqual(3, model.Board.GetObjects(3, 5)[0].XCor);
            Assert.AreEqual(5, model.Board.GetObjects(3, 5)[0].YCor);


            Assert.IsTrue(_eventRaised);
            Assert.AreSame(model, _eventSource);
            Assert.AreEqual("MapFieldChanged", _eventType);
        }

        [TestMethod]
        public void CheckHutBuy()
        {
            model.StartNewMap(10, 10);
            SetUp();
            model.Build(MapPressed.HUT1);
            model.HandleBuyPhase(0, 0);
            Assert.AreEqual(MapPressed.NONE, model.CurrentPressed);
            Assert.AreEqual(model.HutNum - 1, model.HutsLeft[0]);
            Assert.AreEqual(model.HutNum, model.HutsLeft[1]);
            Assert.AreEqual(1, model.Board.GetObjects(0, 0).Count);
            Assert.AreEqual(FieldType.HUT, model.Board.GetObjects(0, 0)[0].Type);
            Assert.AreEqual(0, model.Board.GetObjects(0, 0)[0].PlayerID);
            Assert.AreEqual(0, model.Board.GetObjects(0, 0)[0].XCor);
            Assert.AreEqual(0, model.Board.GetObjects(0, 0)[0].YCor);

            model.Build(MapPressed.HUT2);
            model.HandleBuyPhase(0, 0);
            Assert.AreEqual(MapPressed.HUT2, model.CurrentPressed);
            model.HandleBuyPhase(1, 1);
            Assert.AreEqual(MapPressed.NONE, model.CurrentPressed);
            Assert.AreEqual(model.HutNum - 1, model.HutsLeft[0]);
            Assert.AreEqual(model.HutNum - 1, model.HutsLeft[1]);
            Assert.AreEqual(1, model.Board.GetObjects(1, 1).Count);
            Assert.AreEqual(FieldType.HUT, model.Board.GetObjects(1, 1)[0].Type);
            Assert.AreEqual(1, model.Board.GetObjects(1, 1)[0].PlayerID);
            Assert.AreEqual(1, model.Board.GetObjects(1, 1)[0].XCor);
            Assert.AreEqual(1, model.Board.GetObjects(1, 1)[0].YCor);


            Assert.IsTrue(_eventRaised);
            Assert.AreSame(model, _eventSource);
            Assert.AreEqual("MapFieldChanged", _eventType);
        }

        [TestMethod]
        public void CheckObstacleBuy()
        {
            model.StartNewMap(10, 10);
            SetUp();
            model.Build(MapPressed.OBSTACLE);
            model.HandleBuyPhase(0, 0);
            Assert.AreEqual(MapPressed.NONE, model.CurrentPressed);
            Assert.AreEqual(1, model.ObstaclesPlaced);
            Assert.AreEqual(1, model.Board.GetObjects(0, 0).Count);
            Assert.AreEqual(FieldType.MOUNTAIN, model.Board.GetObjects(0, 0)[0].Type);
            Assert.AreEqual(-1, model.Board.GetObjects(0, 0)[0].PlayerID);
            Assert.AreEqual(0, model.Board.GetObjects(0, 0)[0].XCor);
            Assert.AreEqual(0, model.Board.GetObjects(0, 0)[0].YCor);

            model.Build(MapPressed.OBSTACLE);
            model.HandleBuyPhase(0, 0);
            Assert.AreEqual(MapPressed.OBSTACLE, model.CurrentPressed);
            model.HandleBuyPhase(1, 1);
            Assert.AreEqual(MapPressed.NONE, model.CurrentPressed);
            Assert.AreEqual(2, model.ObstaclesPlaced);
            Assert.AreEqual(1, model.Board.GetObjects(1, 1).Count);
            Assert.AreEqual(FieldType.MOUNTAIN, model.Board.GetObjects(1, 1)[0].Type);
            Assert.AreEqual(-1, model.Board.GetObjects(1, 1)[0].PlayerID);
            Assert.AreEqual(1, model.Board.GetObjects(1, 1)[0].XCor);
            Assert.AreEqual(1, model.Board.GetObjects(1, 1)[0].YCor);


            Assert.IsTrue(_eventRaised);
            Assert.AreSame(model, _eventSource);
            Assert.AreEqual("MapFieldChanged", _eventType);
        }

        [TestMethod]
        public void CheckDeleteObject()
        {
            model.StartNewMap(10, 10);
            SetUp();
            model.Build(MapPressed.OBSTACLE);
            model.HandleBuyPhase(0, 0);
            model.Build(MapPressed.DELETE);
            Assert.AreEqual(MapPressed.DELETE, model.CurrentPressed);
            model.HandleBuyPhase(7, 6);
            Assert.AreEqual(MapPressed.DELETE, model.CurrentPressed);
            model.HandleBuyPhase(0, 0);
            Assert.AreEqual(MapPressed.NONE, model.CurrentPressed);
            Assert.AreEqual(0, model.ObstaclesPlaced);
            Assert.AreEqual(0, model.Board.GetObjects(0, 0).Count);

            model.Build(MapPressed.HUT2);
            model.HandleBuyPhase(1, 1);
            model.Build(MapPressed.DELETE);
            model.HandleBuyPhase(1, 1);
            Assert.AreEqual(MapPressed.NONE, model.CurrentPressed);
            Assert.AreEqual(model.HutNum, model.HutsLeft[0]);
            Assert.AreEqual(model.HutNum, model.HutsLeft[1]);
            Assert.AreEqual(0, model.Board.GetObjects(1, 1).Count);

            model.Build(MapPressed.CASTLE1);
            model.HandleBuyPhase(2, 2);
            model.Build(MapPressed.DELETE);
            model.HandleBuyPhase(1, 1);
            Assert.AreEqual(MapPressed.DELETE, model.CurrentPressed);
            model.HandleBuyPhase(2, 2);
            Assert.AreEqual(MapPressed.NONE, model.CurrentPressed);
            Assert.AreEqual(false, model.CastlesExist[0]);
            Assert.AreEqual(false, model.CastlesExist[1]);
            Assert.AreEqual(0, model.Board.GetObjects(2, 2).Count);


            Assert.IsTrue(_eventRaised);
            Assert.AreSame(model, _eventSource);
            Assert.AreEqual("MapFieldChanged", _eventType);
        }

        [TestMethod]

        public void TestCheckDistance()
        {
            model.StartNewMap(10, 10);
            SetUp();

            model.Build(MapPressed.CASTLE1);
            model.HandleBuyPhase(0, 0);
            bool correct = model.CheckDistance(1, 1, FieldType.CASTLE);
            Assert.IsFalse(correct);
            correct = model.CheckDistance(2, 2, FieldType.CASTLE);
            Assert.IsTrue(correct);
            correct = model.CheckDistance(1, 1, FieldType.MOUNTAIN);
            Assert.IsFalse(correct);
            correct = model.CheckDistance(1, 2, FieldType.MOUNTAIN);
            Assert.IsTrue(correct);
            correct=model.CheckDistance(0, 1, FieldType.HUT);
            Assert.IsFalse(correct);
            correct = model.CheckDistance(1, 2, FieldType.HUT);
            Assert.IsTrue(correct);

            model.Build(MapPressed.HUT1);
            model.HandleBuyPhase(4, 4);
            correct = model.CheckDistance(4, 5, FieldType.HUT);
            Assert.IsTrue(correct);
            correct = model.CheckDistance(5, 4, FieldType.MOUNTAIN);
            Assert.IsTrue(correct);
            correct = model.CheckDistance(4, 5, FieldType.CASTLE);
            Assert.IsFalse(correct);
            correct = model.CheckDistance(6, 6, FieldType.CASTLE);
            Assert.IsTrue(correct);
        }

    }
}
