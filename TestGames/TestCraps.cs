using Craps;
using System;
using Xunit;
using static GameUtils.Dice;

namespace TestGames
{
    public class TestCraps
    {
        private readonly CrapsEngine _game;

        public TestCraps()
        {
            _game = new CrapsEngine();
        }

        [Theory]
        [InlineData(DiceNames.SnakeEyes, 2)]
        [InlineData(DiceNames.Trey, 3)]
        [InlineData(DiceNames.Seven, 7)]
        [InlineData(DiceNames.YoLeven, 11)]
        [InlineData(DiceNames.BoxCars, 12)]
        public void TestDiceThrows(DiceNames rollName, int score) =>
            Assert.Equal(rollName, (DiceNames)score);

        [Theory]
        [InlineData(DiceNames.Seven)]
        [InlineData(DiceNames.YoLeven)]
        public void TestWinOnFirstThrow(DiceNames score) => 
            Assert.Equal(CrapsEngine.Status.Win, _game.GetStatusFromFirstThrow((int)score));

        [Theory]
        [InlineData(DiceNames.SnakeEyes)]
        [InlineData(DiceNames.Trey)]
        [InlineData(DiceNames.BoxCars)]
        public void TestLooseOnFirstThrow(DiceNames score) => 
            Assert.Equal(CrapsEngine.Status.Loose, _game.GetStatusFromFirstThrow((int)score));

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void TestContinueOnFirstThrow(int score) => 
            Assert.Equal(CrapsEngine.Status.Continue, _game.GetStatusFromFirstThrow(score));

        [Theory]
        [InlineData(4, 4)]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        [InlineData(8, 8)]
        [InlineData(9, 9)]
        [InlineData(10, 10)]
        public void TestWinOnSecondThrow(int throw1, int throw2) => 
            Assert.Equal(CrapsEngine.Status.Win, _game.GetStatusFromLaterThrow(throw1, throw2));

        [Theory]
        [InlineData(4, DiceNames.Seven)]
        [InlineData(5, DiceNames.Seven)]
        [InlineData(6, DiceNames.Seven)]
        [InlineData(8, DiceNames.Seven)]
        [InlineData(9, DiceNames.Seven)]
        [InlineData(10, DiceNames.Seven)]
        public void TestLooseOnSecondThrow(int throw1, DiceNames throw2) => 
            Assert.Equal(CrapsEngine.Status.Loose, _game.GetStatusFromLaterThrow(throw1, (int)throw2));

        [Theory]
        [InlineData(4, 5)]
        [InlineData(5, 4)]
        [InlineData(6, 8)]
        [InlineData(8, 6)]
        [InlineData(9, 10)]
        [InlineData(10, 9)]
        public void TestContinueOnSecondThrow(int throw1, int throw2) =>
            Assert.Equal(CrapsEngine.Status.Continue, _game.GetStatusFromLaterThrow(throw1, throw2));

        [Theory]
        [InlineData(DiceNames.SnakeEyes, DiceNames.Trey)]
        [InlineData(DiceNames.Trey, DiceNames.SnakeEyes)]
        [InlineData(DiceNames.YoLeven, DiceNames.BoxCars)]
        [InlineData(DiceNames.BoxCars, DiceNames.YoLeven)]
        public void TestContinueOnSecondThrowDiceNames(DiceNames throw1, DiceNames throw2) =>
            Assert.Equal(CrapsEngine.Status.Continue, _game.GetStatusFromLaterThrow((int)throw1, (int)throw2));

        [Theory]
        [InlineData(1)]
        [InlineData(13)]
        public void TestInvalidFirstThrow(int throw1) => 
            Assert.Throws<ArgumentOutOfRangeException>(() => _game.GetStatusFromFirstThrow(throw1));

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(13, 13)]
        [InlineData(12, 13)]
        public void TestInvalidLaterThrow(int throw1, int throw2) => 
            Assert.Throws<ArgumentOutOfRangeException>(() => _game.GetStatusFromLaterThrow(throw1, throw2));
    }
}
