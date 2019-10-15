using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RockPaperScissorsBattleRoyale
{
    public enum EntityIdentity { Rock, Paper, Scissors };
    class Simulation
    {
        private int numberOfRocks { get; }
        private int numberOfScissors { get; }
        private int numberOfPapers { get; }
        private List<Rock> listOfRocks;
        private List<Scissors> listOfScissors;
        private List<Paper> listOfPapers;
        private Random rand = new Random();

        public Simulation(int numberOfRocks, int numberOfScissors, int numberOfPapers)
        {
            this.numberOfRocks = numberOfRocks;
            this.numberOfScissors = numberOfScissors;
            this.numberOfPapers = numberOfPapers;
        }

        public void Start()
        {
            listOfRocks = new List<Rock>();
            listOfScissors = new List<Scissors>();
            listOfPapers = new List<Paper>();

            //Build the initial armies of Rock/Scissors/Paper
            for (int i = 0; i < numberOfRocks; i++)
                ArmyBuilder(listOfRocks);

            for (int i = 0; i < numberOfScissors; i++)
                ArmyBuilder(listOfScissors);

            for (int i = 0; i < numberOfPapers; i++)
                ArmyBuilder(listOfPapers);

            do
            {
                int entitiesToAdd = 0;
                //0 empty: 1: Rock 2: Scissors 3: paper
                //ROCK
                if (listOfRocks.Count > 0)
                {
                    //for (int i = 0; i < listOfRocks.Count; i++)
                    //{
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
                    //}
                }
                for (int i = 0; i < entitiesToAdd; i++)
                    ArmyBuilder(listOfRocks);

                entitiesToAdd = 0;
                //0 empty: 1: Rock 2: Scissors 3: paper
                //SCISSORS
                if (listOfScissors.Count > 0)
                {
                    //for (int i = 0; i < listOfScissors.Count; i++)
                    //{
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
                    //}
                }
                for (int i = 0; i < entitiesToAdd; i++)
                    ArmyBuilder(listOfScissors);

                entitiesToAdd = 0;
                //0 empty: 1: Rock 2: Scissors 3: paper
                //PAPER
                if (listOfPapers.Count > 0)
                {
                    //for (int i = 0; i < listOfPapers.Count; i++)
                    //{
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
                    //}
                }
                for (int i = 0; i < entitiesToAdd; i++)
                    ArmyBuilder(listOfPapers);

                //{
                //    //Rock
                //    int move = rand.Next(0, 4);
                //    if (move == 2)
                //        Battle(listOfRocks[0], listOfScissors[rand.Next(0, listOfScissors.Count)]);
                //    if (move == 3)
                //        Battle(listOfRocks[0], listOfPapers[rand.Next(0, listOfPapers.Count)]);
                //    if (move == 1)
                //        ArmyBuilder(listOfRocks);
                //}
                //{
                //    //Scissors
                //    int move = rand.Next(0, 4);
                //    if (move == 1)
                //        Battle(listOfScissors[0], listOfRocks[rand.Next(0, listOfRocks.Count)]);
                //    if (move == 3)
                //        Battle(listOfScissors[0], listOfPapers[rand.Next(0, listOfPapers.Count)]);
                //    if (move == 2)
                //        ArmyBuilder(listOfScissors);
                //}
                //{
                //    int move = rand.Next(0, 4);
                //    if (move == 1)
                //        Battle(listOfPapers[0], listOfRocks[rand.Next(0, listOfRocks.Count)]);
                //    if (move == 2)
                //        Battle(listOfPapers[0], listOfScissors[rand.Next(0, listOfScissors.Count)]);
                //    if (move == 3)
                //        ArmyBuilder(listOfPapers);
                //}

                Console.Write("Rock: " + listOfRocks.Count + "     ");
                Console.Write("Scissors: " + listOfScissors.Count + "     ");
                Console.Write("Paper: " + listOfPapers.Count + "     ");
                Console.WriteLine();
                Thread.Sleep(200);
            }
            while (listOfScissors.Count != 0 && listOfPapers.Count != 0 ||
                   listOfRocks.Count != 0 && listOfPapers.Count != 0 ||
                   listOfRocks.Count != 0 && listOfScissors.Count != 0);

            //string winner = Battle(listOfRocks[0], listOfPapers[0]);
            //Console.WriteLine(winner);
            //foreach (Rock rock in listOfRocks)
            //    Console.WriteLine(rock);
            //Console.WriteLine();
            //foreach (Scissors scissors in listOfScissors)
            //    Console.WriteLine(scissors);
            //Console.WriteLine();
            //foreach (Paper paper in listOfPapers)
            //    Console.WriteLine(paper);
            //Console.WriteLine();
        }

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
