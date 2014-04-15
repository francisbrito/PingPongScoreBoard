using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPongScoreboard.Model;
using System;
using TechTalk.SpecFlow;

namespace PingPongScoreboard.Specifications
{
    [Binding]
    public class AddScoresToTeamsSteps : BasePingPongGameStepDefinition
    {
        [Given(@"team (.*) has (.*) points")]
        public void GivenTeamHasPoints(int teamNumber, int expectedPoints)
        {
            Given(@"a game is in session");
            var actualPoints = _game.CalculatePointsForTeam(teamNumber);

            Assert.AreEqual(expectedPoints, actualPoints);
        }
        
        [When(@"I press add score")]
        public void WhenIPressAddScore()
        {
            _game.MarkSetAsPoint();

            And(@"I choose team 1");
        }
        
        [Then(@"score for team (.*) should be increased by one")]
        public void ThenScoreForTeamShouldBeIncreasedByOne(int teamNumber)
        {
            var expectedPoints = 1;
            var actualPoints = _game.CalculatePointsForTeam(teamNumber);

            Assert.AreEqual(expectedPoints, actualPoints);
        }
    }
}
