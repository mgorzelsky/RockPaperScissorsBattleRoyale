using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RockPaperScissorsBattleRoyale
{
    public enum EntityIdentity { Rock, Paper, Scissors };
    class Simulation
    {
        private readonly int initialArmySize;
        private List<Rock> listOfRocks;
        private List<Scissors> listOfScissors;
        private List<Paper> listOfPapers;
        private Random rand = new Random();

        public Simulation(int initialArmySize)
        {
            this.initialArmySize = initialArmySize;
        }

        public void Start()
        {
            listOfRocks = new List<Rock>();
            listOfScissors = new List<Scissors>();
            listOfPapers = new List<Paper>();

            //Build the initial armies of Rock/Scissors/Paper
            for (int i = 0; i < initialArmySize; i++)
            {
                ArmyBuilder(listOfRocks);
                ArmyBuilder(listOfPapers);
                ArmyBuilder(listOfScissors);
            }

            //Each army gets to move once in a random direction. Depending on collision they either 
            //win, lose, or duplicate. Continues until only one army is standing.
            do
            {
                int entitiesToAdd = 0;
                //0 empty: 1: Rock 2: Scissors 3: paper
                //ROCK
                if (listOfRocks.Count > 0)
                {
                        int move = rand.Next(0, 4);
                        if (move == 2)
                        {
                            if (listOfScissors.Count != 0)
                                Battle(listOfRocks[0], listOfScissors[rand.Next(0, listOfScissors.Count)]);
                        }
                        if (move == 3)
                        {
                            if (listOfPapers.Count != 0)
                                Battle(listOfRocks[0], listOfPapers[rand.Next(0, listOfPapers.Count)]);
                        }
                        if (move == 1)
                            entitiesToAdd++;
                }
                for (int i = 0; i < entitiesToAdd; i++)
                    ArmyBuilder(listOfRocks);

                entitiesToAdd = 0;
                //0 empty: 1: Rock 2: Scissors 3: paper
                //SCISSORS
                if (listOfScissors.Count > 0)
                {
                        int move = rand.Next(0, 4);
                        if (move == 1)
                        {
                            if (listOfRocks.Count != 0)
                                Battle(listOfScissors[0], listOfRocks[rand.Next(0, listOfRocks.Count)]);
                        }
                        if (move == 3)
                        {
                            if (listOfPapers.Count != 0)
                                Battle(listOfScissors[0], listOfPapers[rand.Next(0, listOfPapers.Count)]);
                        }
                        if (move == 2)
                            entitiesToAdd++;
                }
                for (int i = 0; i < entitiesToAdd; i++)
                    ArmyBuilder(listOfScissors);

                entitiesToAdd = 0;
                //0 empty: 1: Rock 2: Scissors 3: paper
                //PAPER
                if (listOfPapers.Count > 0)
                {
                        int move = rand.Next(0, 4);
                        if (move == 1)
                        {
                            if (listOfRocks.Count != 0)
                                Battle(listOfPapers[0], listOfRocks[rand.Next(0, listOfRocks.Count)]);
                        }
                        if (move == 2)
                        {
                            if (listOfScissors.Count != 0)
                                Battle(listOfPapers[0], listOfScissors[rand.Next(0, listOfScissors.Count)]);
                        }
                        if (move == 3)
                            entitiesToAdd++;
                }
                for (int i = 0; i < entitiesToAdd; i++)
                    ArmyBuilder(listOfPapers);

                //Print out the current army numbers for each army
                Console.Write("Rock: " + listOfRocks.Count + "     ");
                Console.Write("Scissors: " + listOfScissors.Count + "     ");
                Console.Write("Paper: " + listOfPapers.Count + "     ");
                Console.WriteLine();
                Thread.Sleep(200); //Windows requires more than 15ms before each random call to ensure you don't get the same # twice
            }
            while (listOfScissors.Count != 0 && listOfPapers.Count != 0 ||
                   listOfRocks.Count != 0 && listOfPapers.Count != 0 ||
                   listOfRocks.Count != 0 && listOfScissors.Count != 0);
        }

        //Take in the combatants, cast them to the correct type, and compare. Call destroy on the loser.
        private void Battle(Entity x, Entity y)
        {
            Entity combatantOne;
            Entity combatantTwo;
            if (x is Rock)
                combatantOne = x as Rock;
            else if (x is Scissors)
                combatantOne = x as Scissors;
            else
                combatantOne = x as Paper;

            if (y is Rock)
                combatantTwo = y as Rock;
            else if (y is Scissors)
                combatantTwo = y as Scissors;
            else
                combatantTwo = y as Paper;

            if (combatantOne.GetIdentity() == EntityIdentity.Rock &&
                combatantTwo.GetIdentity() == EntityIdentity.Scissors)
            {
                ScissorsDestroyer();
                return;
            }

            if (combatantOne.GetIdentity() == EntityIdentity.Rock &&
                combatantTwo.GetIdentity() == EntityIdentity.Paper)
            {
                RockDestroyer();
                return;
            }

            if (combatantOne.GetIdentity() == EntityIdentity.Scissors &&
                combatantTwo.GetIdentity() == EntityIdentity.Rock)
            {
                ScissorsDestroyer();
                return;
            }

            if (combatantOne.GetIdentity() == EntityIdentity.Scissors &&
                combatantTwo.GetIdentity() == EntityIdentity.Paper)
            {
                PaperDestroyer();
                return;
            }

            if (combatantOne.GetIdentity() == EntityIdentity.Paper &&
                combatantTwo.GetIdentity() == EntityIdentity.Scissors)
            {
                PaperDestroyer();
                return;
            }

            if (combatantOne.GetIdentity() == EntityIdentity.Paper &&
                combatantTwo.GetIdentity() == EntityIdentity.Rock)
            {
                RockDestroyer();
                return;
            }

            return;
        }

        //3 overloads to account for different types of lists. Adds new objects to the specified list.
        private void ArmyBuilder(List<Rock> rockType)
        {
            Rock rock = new Rock();
            listOfRocks.Add(rock);
        }
        private void ArmyBuilder(List<Scissors> scissorsType)
        {
            Scissors scissors = new Scissors();
            listOfScissors.Add(scissors);
        }
        private void ArmyBuilder(List<Paper> papersType)
        {
            Paper paper = new Paper();
            listOfPapers.Add(paper);
        }

        //Remove one object from the losing army (list)
        private void RockDestroyer()
        {
            listOfRocks.RemoveAt(listOfRocks.Count - 1);
        }
        private void ScissorsDestroyer()
        {
            listOfScissors.RemoveAt(listOfScissors.Count - 1);
        }
        private void PaperDestroyer()
        {
            listOfPapers.RemoveAt(listOfPapers.Count - 1);
        }
    }
}
