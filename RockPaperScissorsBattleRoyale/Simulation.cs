using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RockPaperScissorsBattleRoyale
{
    public enum MovementCollision { nothing, rock, paper, scissors };
    class Simulation
    {
        private readonly int initialArmySize;
        Rock rock;
        Paper paper;
        Scissors scissors;
        int sizeOfRockArmy;
        int sizeOfPaperArmy;
        int sizeOfScissorArmy;

        public Simulation(int initialArmySize)
        {
            this.initialArmySize = initialArmySize;
        }

        public void Start()
        {
            rock = new Rock(initialArmySize);
            paper = new Paper(initialArmySize);
            scissors = new Scissors(initialArmySize);

            sizeOfRockArmy = rock.GetArmySize();
            sizeOfPaperArmy = paper.GetArmySize();
            sizeOfScissorArmy = scissors.GetArmySize();

            do
            {
                if (sizeOfRockArmy > 0)
                {
                    MovementCollision result = rock.Move();
                    switch (result)
                    {
                        case (MovementCollision.rock):
                            rock.AddSoldier();
                            break;
                        case (MovementCollision.paper):
                            rock.RemoveSoldier();
                            break;
                        case (MovementCollision.scissors):
                            scissors.RemoveSoldier();
                            break;
                    }
                }

                if (sizeOfPaperArmy > 0)
                {
                    MovementCollision result = paper.Move();
                    switch (result)
                    {
                        case (MovementCollision.rock):
                            rock.RemoveSoldier();
                            break;
                        case (MovementCollision.paper):
                            paper.AddSoldier();
                            break;
                        case (MovementCollision.scissors):
                            paper.RemoveSoldier();
                            break;
                    }
                }

                if (sizeOfScissorArmy > 0)
                {
                    MovementCollision result = scissors.Move();
                    switch (result)
                    {
                        case (MovementCollision.rock):
                            scissors.RemoveSoldier();
                            break;
                        case (MovementCollision.paper):
                            paper.RemoveSoldier();
                            break;
                        case (MovementCollision.scissors):
                            scissors.AddSoldier();
                            break;
                    }
                }

                sizeOfRockArmy = rock.GetArmySize();
                sizeOfPaperArmy = paper.GetArmySize();
                sizeOfScissorArmy = scissors.GetArmySize();

                //Print out the current army numbers for each army
                Console.Write("Rock: " + sizeOfRockArmy + "     ");
                Console.Write("Paper: " + sizeOfPaperArmy + "     ");
                Console.Write("Scissors: " + sizeOfScissorArmy + "     ");
                Console.WriteLine();
                Thread.Sleep(200); //Windows requires more than 15ms before each random call to ensure you don't get the same # twice
            }
            while (sizeOfScissorArmy != 0 && sizeOfPaperArmy != 0 ||
                   sizeOfRockArmy != 0 && sizeOfPaperArmy != 0 ||
                   sizeOfRockArmy != 0 && sizeOfScissorArmy != 0);
        }
    }
}
