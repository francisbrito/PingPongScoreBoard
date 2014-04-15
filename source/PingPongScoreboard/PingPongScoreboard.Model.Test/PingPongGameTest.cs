using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PingPongScoreboard.Model.Test
{
    [TestClass]
    public class PingPongGameTest
    {
        [TestMethod]
        public void GameStateShouldDefaultToNotSet()
        {
            var game = new PingPongGame();

            var expectedState = PingPongGameState.NotSet;
            var actualState = game.State;

            Assert.AreEqual(expectedState, actualState);
        }

        [TestMethod]
        public void GameStartSetsStateToStarted()
        {
            var game = new PingPongGame();

            game.Start();

            var expectedState = PingPongGameState.Started;
            var actualState = game.State;

            Assert.AreEqual(expectedState, actualState);
        }

        [TestMethod]
        public void GameEndSetsStateToFinished()
        {
            var game = new PingPongGame();

            game.End();

            var expectedState = PingPongGameState.Finished;
            var actualState = game.State;

            Assert.AreEqual(expectedState, actualState);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GameGenerateSetsShouldThrowIfArgumentIsNegativeOrZero()
        {
            var game = new PingPongGame();

            game.GenerateSets(-1);
            game.GenerateSets(0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GameGenerateSetsShouldBeCalledBeforeGameStart()
        {
            var game = new PingPongGame();

            game.Start();
            game.GenerateSets(11);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GameGoToNextSetShouldThrowIfArgumentIsGreaterThanIndexOfLastSet()
        {
            var game = new PingPongGame();

            game.GenerateSets(1);
            game.Start();

            game.GoToNextSet();
        }

        [TestMethod]
        public void GameGoToNextShouldMoveCurrentSetToNextSet()
        {
            var game = new PingPongGame();

            game.GenerateSets(7);
            game.Start();

            var expected = 1;
            var actual = game.CurrentSet.Number;
            Assert.AreEqual(expected, actual);

            game.GoToNextSet();
            expected = 2;
            actual = game.CurrentSet.Number;
            Assert.AreEqual(expected, actual);

            game.GoToNextSet();
            expected = 3;
            actual = game.CurrentSet.Number;
            Assert.AreEqual(expected, actual);

            game.GoToNextSet();
            expected = 4;
            actual = game.CurrentSet.Number;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GameGoToPreviousShouldThrowIfArgumentIsLesserThanZero()
        {
            var game = new PingPongGame();

            game.GenerateSets(1);
            game.Start();

            game.GoToPreviousSet();
        }

        [TestMethod]
        public void GameGoToPreviousShouldMoveCurrentSetToPreviousSet()
        {
            var game = new PingPongGame();

            game.GenerateSets(7);
            game.Start();

            var expected = 1;
            var actual = game.CurrentSet.Number;
            Assert.AreEqual(expected, actual);

            game.GoToNextSet();
            game.GoToNextSet();
            game.GoToNextSet();
            game.GoToNextSet();

            expected = 5;
            actual = game.CurrentSet.Number;
            Assert.AreEqual(expected, actual);

            game.GoToPreviousSet();
            expected = 4;
            actual = game.CurrentSet.Number;
            Assert.AreEqual(expected, actual);

            game.GoToPreviousSet();
            expected = 3;
            actual = game.CurrentSet.Number;
            Assert.AreEqual(expected, actual);

            game.GoToPreviousSet();
            expected = 2;
            actual = game.CurrentSet.Number;
            Assert.AreEqual(expected, actual);

            game.GoToPreviousSet();
            expected = 1;
            actual = game.CurrentSet.Number;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GameGoToSetShouldThrowIfArgumentIsOutsideOfNumberOfSetsBounds()
        {
            var game = new PingPongGame();

            game.GenerateSets(11);
            game.Start();

            game.GoToSet(-1);
            game.GoToSet(12);
        }

        [TestMethod]
        public void GameGoToSetShouldMoveCurrentSetToGivenArgument()
        {
            var game = new PingPongGame();

            game.GenerateSets(11);
            game.Start();

            game.GoToSet(1);
            var expected = 1;
            var actual = game.CurrentSet.Number;
            Assert.AreEqual(expected, actual);

            game.GoToSet(2);
            expected = 2;
            actual = game.CurrentSet.Number;
            Assert.AreEqual(expected, actual);

            game.GoToSet(4);
            expected = 4;
            actual = game.CurrentSet.Number;
            Assert.AreEqual(expected, actual);

            game.GoToSet(8);
            expected = 8;
            actual = game.CurrentSet.Number;
            Assert.AreEqual(expected, actual);

            game.GoToSet(1);
            expected = 1;
            actual = game.CurrentSet.Number;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GameMarkSetAsPointForTeamShouldThrowIfArgumentIsNegativeZeroOrGreaterThanTwo()
        {
            var game = new PingPongGame();

            game.GenerateSets(11);
            game.Start();

            game.MarkSetAsPointForTeam(-1);
            game.MarkSetAsPointForTeam(0);
            game.MarkSetAsPointForTeam(3);
        }

        [TestMethod]
        public void GameMarkSetAsPointForTeamShouldMarkCurrentSetAsAPointForAGivenTeam()
        {
            var game = new PingPongGame();

            game.GenerateSets(11);
            game.Start();

            game.MarkSetAsPointForTeam(1);

            var expected = 1;
            var actual = game.CurrentSet.ForTeam;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GameMarkSetAsFaultForTeamShouldThrowIfArgumentIsNegativeZeroOrGreaterThanTwo()
        {
            var game = new PingPongGame();

            game.GenerateSets(11);
            game.Start();

            game.MarkSetAsFaultForTeam(-1);
            game.MarkSetAsFaultForTeam(0);
            game.MarkSetAsFaultForTeam(3);
        }
    }
}
