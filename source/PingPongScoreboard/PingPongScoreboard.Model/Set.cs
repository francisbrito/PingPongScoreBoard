using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PingPongScoreboard.Model
{
    public class Set
    {
        private int i;

        public Set(int i)
        {
            // TODO: Complete member initialization
            this.i = i;
        }
        public SetOutcome Outcome
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public int ForTeam
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public int Number { get; set; }
    }

    public enum SetOutcome
    {
        NotSet,
        Point,
        Fault,
        Invalid
    }
}
