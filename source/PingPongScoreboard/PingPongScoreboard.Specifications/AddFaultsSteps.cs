using System;
using TechTalk.SpecFlow;

namespace PingPongScoreboard.Specifications
{
    [Binding]
    public class AddFaultsToTeamsSteps
    {
        [Given(@"a game is in session")]
        public void GivenAGameIsInSession()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press add fault")]
        public void WhenIPressAddFault()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I choose team (.*)")]
        public void WhenIChooseTeam(int teamNumber)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"fault count for team (.*) should be increased by one")]
        public void ThenFaultCountForTeamShouldBeIncreasedByOne(int teamNumber)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
