using Craps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Dices.Dice;

namespace TestGames
{
    [TestClass]
    public class TestCraps
    {
        private CrapsEngine game; // = new CrapsEngine();

        [TestInitialize()]
        public void Initialize()
        {
            game = new CrapsEngine();
        }

        [TestMethod]
        [DataRow(DiceNames.SnakeEyes, 2)]
        [DataRow(DiceNames.Trey, 3)]
        [DataRow(4, 4)]
        [DataRow(5, 5)]
        [DataRow(6, 6)]
        [DataRow(DiceNames.Seven, 7)]
        [DataRow(8, 8)]
        [DataRow(9, 9)]
        [DataRow(10, 10)]
        [DataRow(DiceNames.YoLeven, 11)]
        [DataRow(DiceNames.BoxCars, 12)]
        public void TestDiceThrows(DiceNames rollName, int score)
        {
            Assert.AreEqual(rollName, (DiceNames)score);
        }

        [TestMethod]
        [DataRow(DiceNames.Seven)]
        [DataRow(DiceNames.YoLeven)]
        public void TestWinOnFirstThrow(int score)
        {
            Assert.AreEqual(CrapsEngine.Status.Win, game.GetStatusFromFirstThrow(score));
        }

        [TestMethod]
        [DataRow(DiceNames.SnakeEyes)]
        [DataRow(DiceNames.Trey)]
        [DataRow(DiceNames.BoxCars)]
        public void TestLooseOnFirstThrow(int score)
        {
            Assert.AreEqual(CrapsEngine.Status.Loose, game.GetStatusFromFirstThrow(score));
        }

        [TestMethod]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        public void TestContinueOnFirstThrow(int score)
        {
            Assert.AreEqual(CrapsEngine.Status.Continue, game.GetStatusFromFirstThrow(score));
        }

        [TestMethod]
        [DataRow(4, 4)]
        [DataRow(5, 5)]
        [DataRow(6, 6)]
        [DataRow(8, 8)]
        [DataRow(9, 9)]
        [DataRow(10, 10)]
        public void TestWinOnSecondThrow(int throw1, int throw2)
        {
            Assert.AreEqual(CrapsEngine.Status.Win, game.GetStatusFromLaterThow(throw1, throw2));
        }

        [TestMethod]
        [DataRow(4, DiceNames.Seven)]
        [DataRow(5, DiceNames.Seven)]
        [DataRow(6, DiceNames.Seven)]
        [DataRow(8, DiceNames.Seven)]
        [DataRow(9, DiceNames.Seven)]
        [DataRow(10, DiceNames.Seven)]
        public void TestLooseOnSecondThrow(int throw1, int throw2)
        {
            Assert.AreEqual(CrapsEngine.Status.Loose, game.GetStatusFromLaterThow(throw1, throw2));
        }

        [TestMethod]
        [DataRow(4, 5)]
        [DataRow(5, 4)]
        [DataRow(6, 8)]
        [DataRow(8, 6)]
        [DataRow(9, 10)]
        [DataRow(10, 9)]
        [DataRow(DiceNames.SnakeEyes, DiceNames.Trey)]
        [DataRow(DiceNames.Trey, DiceNames.SnakeEyes)]
        [DataRow(DiceNames.YoLeven, DiceNames.BoxCars)]
        [DataRow(DiceNames.BoxCars, DiceNames.YoLeven)]
        public void TestContinueOnSecondThrow(int throw1, int throw2)
        {
            Assert.AreEqual(CrapsEngine.Status.Continue, game.GetStatusFromLaterThow(throw1, throw2));
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(13)]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestInvalidFirstThrow(int throw1)
        {
            game.GetStatusFromFirstThrow(throw1);
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 1)]
        [DataRow(13, 13)]
        [DataRow(12, 13)]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestInvalidLaterThrow(int throw1, int throw2)
        {
            game.GetStatusFromLaterThow(throw1, throw2);
        }
    }
}
