using TowerDefense;
using TowerDefense.GameObjects;
using TowerDefense.Model;
using TowerDefense.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace TowerDefenseUnitTest
{
    [TestClass]
    public class PersistenceUnitTest
    {
        private SaveData _data;
        private GameModel _model;
        private Mock<IDataAccess> _mock;

        [TestInitialize]
        public void Initialize()
        {
            _data = new SaveData();

            _data.Players = new Player[2];
            _data.Players[0] = new Player(0);
            _data.Players[1] = new Player(1);
            
            _data.Castles[0] = new TowerDefense.GameObjects.Castle(0, 0, 0);
            _data.Castles[1] = new TowerDefense.GameObjects.Castle(1, 9, 10);
            _data.Board[0, 0] = new List<GameObject>() { _data.Castles[0] };
            _data.Board[9, 10] = new List<GameObject>() { _data.Castles[1] };

            _data.Huts[0] = new Hut(0, 2, 2);
            _data.Huts[1] = new Hut(0, 2, 3);
            _data.Huts[2] = new Hut(1, 6, 2);
            _data.Huts[3] = new Hut(1, 6, 3);
            _data.Board[2, 2] = new List<GameObject>() { _data.Huts[0] };
            _data.Board[2, 3] = new List<GameObject>() { _data.Huts[1] };
            _data.Board[6, 2] = new List<GameObject>() { _data.Huts[2] };
            _data.Board[6, 3] = new List<GameObject>() { _data.Huts[3] };

            _data.Towers = new List<Tower>[2];
            _data.Towers[0] = new List<Tower>();
            _data.Towers[1] = new List<Tower>();
            _data.Towers[0].Add(new Tower(0, 5, 5));
            _data.Towers[1].Add(new Tower(1, 7, 7));
            _data.Towers[1][0].Upgrade();
            _data.Board[5, 5] = new List<GameObject>() { _data.Towers[0][0] };
            _data.Board[7, 7] = new List<GameObject>() { _data.Towers[1][0] };

            _data.ObstaclesPlaced = 2;
            _data.Obstacles = new Obstacle[_data.ObstaclesPlaced];
            _data.Obstacles[0] = new Obstacle(8, 8);
            _data.Obstacles[1] = new Obstacle(8, 9);
            _data.Board[8, 8] = new List<GameObject>() { _data.Obstacles[0] };
            _data.Board[8, 9] = new List<GameObject>() { _data.Obstacles[1] };

            _data.SaveName = "test";

            _mock = new Mock<IDataAccess>();
            _mock.Setup(mock => mock.Load(It.IsAny<string>(), It.IsAny<string>()))
                 .Returns(() => Task.FromResult(_data));

            _model = new GameModel(_mock.Object);
            for (int i = 0; i < 10; ++i)
                for (int j = 0; j < 11; ++j)
                    _model.Board.SetObjects(i, j, _data.Board[i, j]);

            _model.Board.SetObjects(0, 0, new List<GameObject>() { _data.Castles[0] });
            _model.Board.SetObjects(9, 10, new List<GameObject>() { _data.Castles[1] });

            _model.Board.SetObjects(2, 2, new List<GameObject>() { _data.Huts[0] });
            _model.Board.SetObjects(2, 3, new List<GameObject>() { _data.Huts[1] });
            _model.Board.SetObjects(6, 2, new List<GameObject>() { _data.Huts[2] });
            _model.Board.SetObjects(6, 3, new List<GameObject>() { _data.Huts[3] });

            _model.Board.SetObjects(5, 5, new List<GameObject>() { _data.Towers[0][0] });
            _model.Board.SetObjects(7, 7, new List<GameObject>() { _data.Towers[1][0] });

            _model.Board.SetObjects(8, 8, new List<GameObject>() { _data.Obstacles[0] });
            _model.Board.SetObjects(8, 9, new List<GameObject>() { _data.Obstacles[1] });
        }

        [TestMethod]
        public async Task LoadTest()
        {
            _model.StartNewGame(MapSize.SMALL);
            await _model.Load(string.Empty, string.Empty);

            SaveData modelData = new SaveData(_model, "test");
            string modelJSON = JsonConvert.SerializeObject(modelData, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            string dataJSON = JsonConvert.SerializeObject(_data, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

            Assert.AreEqual(modelJSON, dataJSON);

            _mock.Verify(dataAccess => dataAccess.Load(string.Empty, string.Empty), Times.Once());
        }
    }
}
