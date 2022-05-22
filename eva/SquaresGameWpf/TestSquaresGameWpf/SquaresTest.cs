using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SquaresGameWpf.Model;
using SquaresGameWpf.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestSquaresGameWpf
{
    [TestClass]
    public class SquaresTest
    {
        SquaresModel model;
        Mock<IDataAccess> mock;

        public SquaresTest()
        {
            mock = new Mock<IDataAccess>();
            this.model = new SquaresModel(mock.Object);
        }

        [TestCleanup]



        [TestMethod]
        public void StartNewGameThreeByThree()
        {
            model.StartNewGame(5);
            Assert.AreEqual(5, model.getSize());
            Assert.AreEqual(0, model.getPlayerBluePoints());
            Assert.AreEqual(0, model.getPlayerRedPoints());
            for (int i = 0; i < model.getSize(); i++)
            {
                for (int j = 0; j < model.getSize(); j++)
                {
                    if (i % 2 == 0 && j % 2 == 0) { Assert.AreEqual(0, (int)model.getBoard()[i, j]); }
                    else if ((i % 2 == 0 && j % 2 == 1) || (i % 2 == 1 && j % 2 == 0)) { Assert.AreEqual(1, (int)model.getBoard()[i, j]); }
                    else { Assert.AreEqual(2, (int)model.getBoard()[i, j]); }
                }
            }

        }


        [TestMethod]
        public void StartNewGameFiveByFive()
        {
            model.StartNewGame(9);
            Assert.AreEqual(9, model.getSize());
            Assert.AreEqual(0, model.getPlayerBluePoints());
            Assert.AreEqual(0, model.getPlayerRedPoints());
            for (int i = 0; i < model.getSize(); i++)
            {
                for (int j = 0; j < model.getSize(); j++)
                {
                    if (i % 2 == 0 && j % 2 == 0) { Assert.AreEqual(0, (int)model.getBoard()[i, j]); }
                    else if ((i % 2 == 0 && j % 2 == 1) || (i % 2 == 1 && j % 2 == 0)) { Assert.AreEqual(1, (int)model.getBoard()[i, j]); }
                    else { Assert.AreEqual(2, (int)model.getBoard()[i, j]); }
                }
            }

        }

        [TestMethod]
        public void StartNewGameNineByNine()
        {
            model.StartNewGame(17);
            Assert.AreEqual(17, model.getSize());
            Assert.AreEqual(0, model.getPlayerBluePoints());
            Assert.AreEqual(0, model.getPlayerRedPoints());
            for (int i = 0; i < model.getSize(); i++)
            {
                for (int j = 0; j < model.getSize(); j++)
                {
                    if (i % 2 == 0 && j % 2 == 0) { Assert.AreEqual(0, (int)model.getBoard()[i, j]); }
                    else if ((i % 2 == 0 && j % 2 == 1) || (i % 2 == 1 && j % 2 == 0)) { Assert.AreEqual(1, (int)model.getBoard()[i, j]); }
                    else { Assert.AreEqual(2, (int)model.getBoard()[i, j]); }
                }
            }

        }


        [TestMethod]

        public void FieldClickedNoSquareMade()
        {
            model.StartNewGame(5);
            int beforeClicked = model.getPlayerToMove();
            model.fieldClicked(0, 1);
            if (beforeClicked == 0)
            {
                Assert.AreEqual(8, (int)model.getBoard()[0, 1]);
            }
            else
            {
                Assert.AreEqual(7, (int)model.getBoard()[0, 1]);
            }

        }

        [TestMethod]

        public void FieldClickedOneSquareMade()
        {
            model.StartNewGame(5);
            int firstMove = model.getPlayerToMove();
            model.fieldClicked(0, 1);
            model.fieldClicked(1, 0);
            model.fieldClicked(1, 2);
            model.fieldClicked(2, 1);
            if (firstMove == 0)
            {
                Assert.AreEqual(8, (int)model.getBoard()[0, 1]);
                Assert.AreEqual(5, (int)model.getBoard()[1, 0]);
                Assert.AreEqual(6, (int)model.getBoard()[1, 2]);
                Assert.AreEqual(7, (int)model.getBoard()[2, 1]);
                Assert.AreEqual(3, (int)model.getBoard()[1, 1]);
                Assert.AreEqual(1, model.getPlayerRedPoints());
                Assert.AreEqual(0, model.getPlayerBluePoints());
                Assert.AreEqual(1, model.getPlayerToMove());


            }
            else
            {
                Assert.AreEqual(7, (int)model.getBoard()[0, 1]);
                Assert.AreEqual(6, (int)model.getBoard()[1, 0]);
                Assert.AreEqual(5, (int)model.getBoard()[1, 2]);
                Assert.AreEqual(8, (int)model.getBoard()[2, 1]);
                Assert.AreEqual(4, (int)model.getBoard()[1, 1]);
                Assert.AreEqual(0, model.getPlayerRedPoints());
                Assert.AreEqual(1, model.getPlayerBluePoints());
                Assert.AreEqual(0, model.getPlayerToMove());
            }

        }

        [TestMethod]

        public void FieldClickedTwoSquaresMade()
        {
            model.StartNewGame(5);
            int firstMove = model.getPlayerToMove();
            model.fieldClicked(0, 1);
            model.fieldClicked(1, 0);
            model.fieldClicked(2, 1);
            model.fieldClicked(0, 3);
            model.fieldClicked(1, 4);
            model.fieldClicked(2, 3);
            model.fieldClicked(1, 2);


            if (firstMove == 0)
            {
                Assert.AreEqual(8, (int)model.getBoard()[0, 1]);
                Assert.AreEqual(5, (int)model.getBoard()[1, 0]);
                Assert.AreEqual(8, (int)model.getBoard()[2, 1]);
                Assert.AreEqual(7, (int)model.getBoard()[0, 3]);
                Assert.AreEqual(6, (int)model.getBoard()[1, 4]);
                Assert.AreEqual(7, (int)model.getBoard()[2, 3]);
                Assert.AreEqual(6, (int)model.getBoard()[1, 2]);

                Assert.AreEqual(4, (int)model.getBoard()[1, 1]);
                Assert.AreEqual(4, (int)model.getBoard()[1, 3]);

                Assert.AreEqual(0, model.getPlayerRedPoints());
                Assert.AreEqual(2, model.getPlayerBluePoints());
                Assert.AreEqual(0, model.getPlayerToMove());



            }
            else
            {
                Assert.AreEqual(7, (int)model.getBoard()[0, 1]);
                Assert.AreEqual(6, (int)model.getBoard()[1, 0]);
                Assert.AreEqual(7, (int)model.getBoard()[2, 1]);
                Assert.AreEqual(8, (int)model.getBoard()[0, 3]);
                Assert.AreEqual(5, (int)model.getBoard()[1, 4]);
                Assert.AreEqual(8, (int)model.getBoard()[2, 3]);
                Assert.AreEqual(5, (int)model.getBoard()[1, 2]);

                Assert.AreEqual(3, (int)model.getBoard()[1, 1]);
                Assert.AreEqual(3, (int)model.getBoard()[1, 3]);

                Assert.AreEqual(2, model.getPlayerRedPoints());
                Assert.AreEqual(0, model.getPlayerBluePoints());
                Assert.AreEqual(1, model.getPlayerToMove());
            }

        }


        [TestMethod]

        public void LoadGameMockedVersion()
        {
            model.StartNewGame(5);
            int[] numbers = { 0, 1, 0, 1, 0,
                              1, 2, 1, 2, 1,
                              0, 1, 0, 1, 0,
                              1, 2, 1, 2, 1,
                              0, 1, 0, 1, 0 };
            List<int> cheatlist = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                cheatlist.Add(numbers[i]);
            }
            GameStatus gsCheat = new GameStatus(5, 0, 0, 0, cheatlist);
            mock.Setup(m => m.LoadGame("input")).Returns(gsCheat);
            model.loadGame("input");
            Assert.AreEqual(5, model.getSize());
            Assert.AreEqual(0, model.getPlayerBluePoints());
            Assert.AreEqual(0, model.getPlayerRedPoints());
            for (int i = 0; i < model.getSize(); i++)
            {
                for (int j = 0; j < model.getSize(); j++)
                {
                    if (i % 2 == 0 && j % 2 == 0) { Assert.AreEqual(0, (int)model.getBoard()[i, j]); }
                    else if ((i % 2 == 0 && j % 2 == 1) || (i % 2 == 1 && j % 2 == 0)) { Assert.AreEqual(1, (int)model.getBoard()[i, j]); }
                    else { Assert.AreEqual(2, (int)model.getBoard()[i, j]); }
                }
            }
        }

        /*
        [TestMethod]

        public void CheckGameOver()
        {
            model.StartNewGame(5);
            Assert.AreEqual(0, model.getPlayerRedPoints());
            Assert.AreEqual(0, model.getPlayerBluePoints());
            int firstMove = model.getPlayerToMove();
            model.fieldClicked(0, 1);
            model.fieldClicked(1, 0);
            model.fieldClicked(1, 2);
            model.fieldClicked(2, 1);
            if(firstMove == 0)
            {
                Assert.AreEqual(1, model.getPlayerRedPoints());
            }
            else
            {
                Assert.AreEqual(1, model.getPlayerBluePoints());

            }
            model.checkGameOver();
            Assert.AreEqual(1, (model.getPlayerBluePoints() + model.getPlayerRedPoints()));


            model.fieldClicked(3, 0);
            model.fieldClicked(4, 1);
            model.fieldClicked(3, 2);
            model.fieldClicked(0, 3);
            model.fieldClicked(1, 4);
            model.fieldClicked(2, 3);
            model.fieldClicked(3, 4);


            Assert.AreEqual(3, (model.getPlayerBluePoints() + model.getPlayerRedPoints()));
            model.fieldClicked(4, 3);
            Assert.AreEqual(4, (model.getPlayerBluePoints() + model.getPlayerRedPoints()));


        }
        */


    }
}
