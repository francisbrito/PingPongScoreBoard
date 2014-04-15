using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PingPongScoreboard.Model
{
    public class Set
    {
        private int _number;
        private int _forTeam;
        private SetOutcome _outcome;

        public Set(int number)
        {
            _number = number;
            _forTeam = 0;

            _outcome = SetOutcome.NotSet;
        }

        public SetOutcome Outcome
        {
            get
            {
                return _outcome;
            }
        }

        public int ForTeam
        {
            get
            {
                return _forTeam;
            }
        }

        public int Number 
        {
            get
            {
                return _number;
            }
        }

        public void MarkAsOutcomeFor(SetOutcome outcome, int teamNumber)
        {
            MarkAsOutcome(outcome);
            SetForTeam(teamNumber);
        }

        public void MarkAsOutcome(SetOutcome outcome)
        {
            _outcome = outcome;
        }

        public void MarkAsPoint()
        {
            _outcome = SetOutcome.Point;
        }

        public void MarkAsFault()
        {
            _outcome = SetOutcome.Fault;
        }

        public void MarkAsInvalid()
        {
            _outcome = SetOutcome.Invalid;
        }

        public void SetForTeam(int teamNumber)
        {
            _forTeam = teamNumber;
        }
    }

    public enum SetOutcome
    {
        NotSet,
        Point,
        Fault,
        Invalid
    }
}
