using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPongScoreboard.Model;
using System;
using TechTalk.SpecFlow;

namespace PingPongScoreboard.Specifications
{
    [Binding]
    public class AddFaultsToTeamsSteps : BasePingPongGameStepDefinition
    {
        [Given(@"a game is in session")]
        public void GivenAGameIsInSession()
        {
            var expectedState = PingPongGameState.Started;
            var actualState = _game.State;

            Assert.AreEqual(expectedState, actualState);
        }

        [Given(@"team (.*) has (.*) faults")]
        public void GivenTeamHasFaults(int teamNumber, int expectedFaults)
        {
            var actualFaults = _game.CalculateFaultsForTeam(teamNumber);

            Assert.AreEqual(expectedFaults, actualFaults);
        }

        [When(@"I press add fault")]
        public void WhenIPressAddFault()
        {
            _game.MarkSetAsFault();
        }
        
        [When(@"I choose team (.*)")]
        public void WhenIChooseTeam(int teamNumber)
        {
            _game.SetForTeam(teamNumber);
        }
        
        [Then(@"fault count for team (.*) should be increased by one")]
        public void ThenFaultCountForTeamShouldBeIncreasedByOne(int teamNumber)
        {
            var expectedFaults = 1;
            var actualFaults = _game.CalculateFaultsForTeam(teamNumber);

            Assert.AreEqual(expectedFaults, actualFaults);
        }
    }
}
