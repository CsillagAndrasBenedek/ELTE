using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TowerDefense;
using TowerDefense.EventArguments;
using TowerDefense.Model;
using TowerDefense.Persistence;
using TowerDefense.GameObjects;

namespace TowerDefenseUnitTest
{
    [TestClass]
    public class BuyStateUnitTest
    {
        GameModel model = new GameModel(new DataAccess());
        bool _eventRaised;
        object _eventSource;
        string _eventType;
        FieldChangedEventArgs _fieldEventArgs;
        DetailsExtendedEventArgs _detailsEventArgs;
        GameOverEventArgs _gameOverEventArgs;

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

            model.FieldChanged += new EventHandler<FieldChangedEventArgs>(OnFieldChanged);
            model.DetailsExtended += new EventHandler<DetailsExtendedEventArgs>(OnDetailsExtended);
            model.GameOver += new EventHandler<GameOverEventArgs>(OnGameOver);
        }

        void OnFieldChanged(object source, FieldChangedEventArgs e)
        {
            _eventRaised = true;
            _eventSource = source;
            _fieldEventArgs = e;
            _eventType = "FieldChanged";
        }

        void OnDetailsExtended(object source, DetailsExtendedEventArgs e)
        {
            _eventRaised = true;
            _eventSource = source;
            _detailsEventArgs = e;
            _eventType = "DetailsChanged";
        }

        void OnGameOver(object source, GameOverEventArgs e)
        {
            _eventRaised = true;
            _eventSource = source;
            _gameOverEventArgs = e;
            _eventType = "GameOver";
        }

        [TestMethod]

        public void BuyUnits()
        {
            model.StartNewGame(MapSize.SMALL);
            SetUp();

            int fundsBefore = model.Players[model.CurrentPlayer].Funds;
            int unitsBefore = model.Players[model.CurrentPlayer].UnitCount;
            model.Build(Pressed.TROOP);
            Assert.AreEqual(model.CurrentPressed, Pressed.NONE);
            Assert.AreEqual(model.Players[model.CurrentPlayer].Funds, fundsBefore - Troop.TroopCost);
            Assert.AreEqual(model.Players[model.CurrentPlayer].UnitCount, unitsBefore + 1);

            fundsBefore = model.Players[model.CurrentPlayer].Funds;
            unitsBefore = model.Players[model.CurrentPlayer].UnitCount;
            model.Build(Pressed.CAVALRY);
            Assert.AreEqual(model.CurrentPressed, Pressed.NONE);
            Assert.AreEqual(model.Players[model.CurrentPlayer].Funds, fundsBefore - Cavalry.CavalryCost);
            Assert.AreEqual(model.Players[model.CurrentPlayer].UnitCount, unitsBefore + 1);


            Assert.IsTrue(_eventRaised);
            Assert.AreSame(model, _eventSource);
            Assert.AreEqual("FieldChanged", _eventType);
        }

        [TestMethod]
        public void EndBuy() 
        {
            model.StartNewGame(MapSize.SMALL);
            SetUp();

            model.Build(Pressed.END);
            Assert.AreEqual(model.CurrentPressed, Pressed.NONE);
            Assert.AreEqual(model.CurrentPlayer, 1);
            Assert.AreEqual(model.State, GameState.BUY);

            model.Build(Pressed.END);
            Assert.AreEqual(model.CurrentPressed, Pressed.NONE);
            Assert.AreEqual(model.CurrentPlayer, 0);
            Assert.AreEqual(model.State, GameState.WAR);

            Assert.IsTrue(_eventRaised);
            Assert.AreSame(model, _eventSource);
            Assert.AreEqual("FieldChanged", _eventType);
        }

        [TestMethod]
        public void TestCurrentPressed()
        {
            model.StartNewGame(MapSize.SMALL);
            SetUp();
            Assert.AreEqual(model.CurrentPressed, Pressed.NONE);

            model.Build(Pressed.NEWTOWER);
            Assert.AreEqual(model.CurrentPressed, Pressed.NEWTOWER);
            model.Build(Pressed.NEWTOWER);
            Assert.AreEqual(model.CurrentPressed, Pressed.NONE);
            model.Build(Pressed.UPGRADE);
            Assert.AreEqual(model.CurrentPressed, Pressed.UPGRADE);
            model.Build(Pressed.REMOVE);
            Assert.AreEqual(model.CurrentPressed, Pressed.REMOVE);

            Assert.IsTrue(_eventRaised);
            Assert.AreSame(model, _eventSource);
            Assert.AreEqual("FieldChanged", _eventType);
        }

        [TestMethod]
        public void TestCheckGameOver()
        {
            model.StartNewGame(MapSize.SMALL);
            SetUp();
            model.CheckGameOver();
            Assert.IsFalse(_eventRaised);

            model.Castles[0].Health = 0;
            model.CheckGameOver();
            Assert.IsTrue(_eventRaised);
            Assert.AreSame(model, _eventSource);
            Assert.AreEqual("FieldChanged", _eventType);
            Assert.AreEqual(model.State, GameState.OVER);
        }
    }
}
