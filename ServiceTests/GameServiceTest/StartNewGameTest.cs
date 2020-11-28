using Models;
using NUnit.Framework;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTests.GameServiceTest
{
    [TestFixture]
    public class StartNewGameTest
    {
        [Test]
        public void CannotStartNewGameIfNoPlayers()
        {
            var unitUnderTest = new GameService();

            Assert.False(unitUnderTest.StartNewGame());
        }

        [Test]
        public void WhenPassingNoPlayers_CannotStartNewGame()
        {
            var unitUnderTest = new GameService();

            Assert.False(unitUnderTest.StartNewGame(new List<Player>()));
        }

        [Test]
        public void WhenPassingNoPlayers_WithPreviouslyRunningGame_CanStartGame()
        {
            var unitUnderTest = new GameService();

            unitUnderTest.StartNewGame(new List<Player>() { new Player() });

            Assert.True(unitUnderTest.StartNewGame(new List<Player>()));
        }
    }
}
