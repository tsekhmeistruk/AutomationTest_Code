using AutomationTest_Code;
using AutomationTest_Code.Entities;
using AutomationTest_Code.Game;
using Moq;
using NUnit.Framework;

namespace AutomationTest_Code_Tests
{
    public class GameManagerUnitTests
    {
        private GameManager _gameManager;
        private Mock<Player> _player;
        private Mock<IGameRound> _gameRound;

        [SetUp]
        public void Setup()
        {
            _gameRound = new Mock<IGameRound>();
            _player = new Mock<Player>();
        }

        [TestCase(false, false, 0, 50, 1, 50, "Success")]
        [TestCase(true, true, 5, 5, 5, 50, "Success")]
        [TestCase(true, false, 5, 5, 5, 50, "Insufficient Balance")]
        [TestCase(false, true, 5, 5, 5, 50, "Success")]
        [TestCase(false, false, 0, 49, 1, 50, "Insufficient Balance")]
        [TestCase(false, false, 0, 1, 1, 1, "Success")]
        public void RunAutoPlayUnitTests_MainVerifications(bool hasBonus,
                                                           bool isWin,
                                                           double winAmount,
                                                           double balance,
                                                           double betAmount,
                                                           int roundCount,
                                                           string expectedResult)
        {
            var gameRoundResult = new GameRoundResult()
            {
                HasBonus = hasBonus,
                IsWin = isWin,
                WinAmount = winAmount
            };
            
            _gameRound.Setup(r => r.GenerateRound(It.IsAny<Player>())).Returns(gameRoundResult);
            _gameManager = new GameManager(_gameRound.Object, roundCount);
            
            _player.Object.Balance = balance;
            var actualResult = _gameManager.RunAutoPlay(_player.Object, betAmount);
            Assert.AreEqual(expectedResult, actualResult);
        }

        //Bug: even when a roundCount has value 0 or -1, it goes 1 round, but should not
        [TestCase(true, true, 10, 1, 1, 0)]
        [TestCase(true, true, 10, 1, 1, -1)]
        public void RunAutoPlayUnitTests_VerifyZeroRoundCount(bool hasBonus,
                                                              bool isWin,
                                                              double winAmount,
                                                              double balance,
                                                              double betAmount,
                                                              int roundCount)
        {
            var gameRoundResult = new GameRoundResult()
            {
                HasBonus = hasBonus,
                IsWin = isWin,
                WinAmount = winAmount
            };
            _gameRound.Setup(r => r.GenerateRound(It.IsAny<Player>())).Returns(gameRoundResult);
            _gameManager = new GameManager(_gameRound.Object, roundCount);
            _player.Object.Balance = balance;
            _gameManager.RunAutoPlay(_player.Object, betAmount);
            var actualBalance = _player.Object.Balance;
            Assert.IsTrue(actualBalance <= 1, "Actual balance should not be increased when 0 or -1 roundCount is specified.");
        }
    }
}
