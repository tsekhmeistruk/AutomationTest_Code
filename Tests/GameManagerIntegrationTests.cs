using AutomationTest_Code;
using AutomationTest_Code.Entities;
using NUnit.Framework;

namespace AutomationTest_Code_Tests
{
    public class GameManagerIntegrationTests
    {
        private GameManager _gameManager;
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _gameManager = new GameManager();
            _player = new Player();
        }

        [TestCase(50, 1, "Success")]
        [TestCase(5.5, 0.11, "Success")]
        [TestCase(0, 1, "Insufficient Balance")]
        [TestCase(0.00001, 0.00001001, "Insufficient Balance")]
        [TestCase(0, -1, "Insufficient Balance")] //It looks like a bug. A negative bet's behavior seems weird.
        public void RunAutoPlayTests(double balance, double betAmount, string expectedResult)
        {
            _player.Balance = balance;
            var actualResult = _gameManager.RunAutoPlay(_player, betAmount);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
