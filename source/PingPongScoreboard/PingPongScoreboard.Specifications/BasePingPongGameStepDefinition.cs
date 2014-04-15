using PingPongScoreboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace PingPongScoreboard.Specifications
{
    public class BasePingPongGameStepDefinition : Steps
    {
        protected PingPongGame _game;

        public BasePingPongGameStepDefinition()
        {
            _game = new PingPongGame();
        }

        [BeforeScenario]
        public void SetUp()
        {
            _game.GenerateSets(11);
            _game.Start();
        }
    }
}
