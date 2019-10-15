using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissorsBattleRoyale
{
    public enum EntityIdentity { Rock, Paper, Scissors };
    class Simulation
    {
        private int numberOfRocks { get; }
        private int numberOfScissors { get; }
        private int numberOfPapers { get; }

        public Simulation(int numberOfRocks, int numberOfScissors, int numberOfPapers)
        {
            this.numberOfRocks = numberOfRocks;
            this.numberOfScissors = numberOfScissors;
            this.numberOfRocks = numberOfRocks;
        }

        public void Start()
        {

        }

        private Entity Battle(Entity x, Entity y)
        {
            if (x.Identity == EntityIdentity.Rock && y.Identity == EntityIdentity.Scissors)
                return x;

            return x;   //Placeholder
        }
    }
}
