using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RockPaperScissorsBattleRoyale
{
    public enum MovementCollision { nothing, rock, paper, scissors, lizard, spock };
    class Simulation
    {
        private readonly int initialArmySize;
        private Army rock;
        private Army paper;
        private Army scissors;
        private Army lizard;
        private Army spock;
        private int sizeOfRockArmy;
        private int sizeOfPaperArmy;
        private int sizeOfScissorArmy;
        private int sizeOfLizardArmy;
        private int sizeOfSpockArmy;

        public Simulation(int initialArmySize)
        {
            this.initialArmySize = initialArmySize;
        }

        public void Start()
        {
            rock = new Army(initialArmySize);
            paper = new Army(initialArmySize);
            scissors = new Army(initialArmySize);
            lizard = new Army(initialArmySize);
            spock = new Army(initialArmySize);

            sizeOfRockArmy = rock.GetArmySize();
            sizeOfPaperArmy = paper.GetArmySize();
            sizeOfScissorArmy = scissors.GetArmySize();
            sizeOfLizardArmy = lizard.GetArmySize();
            sizeOfSpockArmy = spock.GetArmySize();

            //while (((sizeOfPaperArmy != 0) && (sizeOfScissorArmy != 0) && (sizeOfLizardArmy != 0)  && (sizeOfSpockArmy != 0)) ||    //Rock wins
            //       ((sizeOfRockArmy != 0)  && (sizeOfScissorArmy != 0) && (sizeOfLizardArmy != 0)  && (sizeOfSpockArmy != 0)) ||    //Paper wins
            //       ((sizeOfRockArmy != 0)  && (sizeOfPaperArmy != 0)   && (sizeOfLizardArmy != 0)  && (sizeOfSpockArmy != 0)) ||    //Scissors win
            //       ((sizeOfRockArmy != 0)  && (sizeOfPaperArmy != 0)   && (sizeOfScissorArmy != 0) && (sizeOfSpockArmy != 0)) ||    //Lizard wins
            //       ((sizeOfRockArmy != 0)  && (sizeOfPaperArmy != 0)   && (sizeOfScissorArmy != 0) && (sizeOfLizardArmy != 0)))     //Spock wins
            bool noWinner = true;
            while (noWinner)
            {
                //Rock army turn
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
                        case (MovementCollision.lizard):
                            lizard.RemoveSoldier();
                            break;
                        case (MovementCollision.spock):
                            rock.RemoveSoldier();
                            break;
                    }
                }

                //Paper army turn
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
                        case (MovementCollision.lizard):
                            paper.RemoveSoldier();
                            break;
                        case (MovementCollision.spock):
                            spock.RemoveSoldier();
                            break;
                    }
                }

                //Scissor army turn
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
                        case (MovementCollision.lizard):
                            lizard.RemoveSoldier();
                            break;
                        case (MovementCollision.spock):
                            scissors.RemoveSoldier();
                            break;
                    }
                }

                //Lizard army turn
                if (sizeOfLizardArmy > 0)
                {
                    MovementCollision result = lizard.Move();
                    switch (result)
                    {
                        case (MovementCollision.rock):
                            lizard.RemoveSoldier();
                            break;
                        case (MovementCollision.paper):
                            paper.RemoveSoldier();
                            break;
                        case (MovementCollision.scissors):
                            lizard.RemoveSoldier();
                            break;
                        case (MovementCollision.lizard):
                            lizard.AddSoldier();
                            break;
                        case (MovementCollision.spock):
                            spock.RemoveSoldier();
                            break;
                    }
                }

                //Spock army turn
                if (sizeOfSpockArmy > 0)
                {
                    MovementCollision result = spock.Move();
                    switch (result)
                    {
                        case (MovementCollision.rock):
                            rock.RemoveSoldier();
                            break;
                        case (MovementCollision.paper):
                            spock.RemoveSoldier();
                            break;
                        case (MovementCollision.scissors):
                            scissors.RemoveSoldier();
                            break;
                        case (MovementCollision.lizard):
                            spock.RemoveSoldier();
                            break;
                        case (MovementCollision.spock):
                            spock.AddSoldier();
                            break;
                    }
                }

                sizeOfRockArmy = rock.GetArmySize();
                sizeOfPaperArmy = paper.GetArmySize();
                sizeOfScissorArmy = scissors.GetArmySize();
                sizeOfLizardArmy = lizard.GetArmySize();
                sizeOfSpockArmy = spock.GetArmySize();

                //Print out the current army numbers for each army
                Console.Write("Rock: " + sizeOfRockArmy + "     ");
                Console.Write("Paper: " + sizeOfPaperArmy + "     ");
                Console.Write("Scissors: " + sizeOfScissorArmy + "     ");
                Console.Write("Lizard: " + sizeOfLizardArmy + "     ");
                Console.Write("Spock: " + sizeOfSpockArmy + "     ");
                Console.WriteLine();
                Thread.Sleep(200); //Windows requires more than 15ms before each random call to ensure you don't get the same # twice

                //Rock Wins
                if (sizeOfPaperArmy == 0 && sizeOfScissorArmy == 0 && sizeOfLizardArmy == 0 && sizeOfSpockArmy == 0)
                    noWinner = false;
                //Paper Wins
                if (sizeOfRockArmy == 0 && sizeOfScissorArmy == 0 && sizeOfLizardArmy == 0 && sizeOfSpockArmy == 0)
                    noWinner = false;
                //Scissors Wins
                if (sizeOfRockArmy == 0 && sizeOfPaperArmy == 0 && sizeOfLizardArmy == 0 && sizeOfSpockArmy == 0)
                    noWinner = false;
                //Lizard Wins
                if (sizeOfRockArmy == 0 && sizeOfPaperArmy == 0 && sizeOfScissorArmy == 0 && sizeOfSpockArmy == 0)
                    noWinner = false;
                //Spock Wins
                if (sizeOfRockArmy == 0 && sizeOfPaperArmy == 0 && sizeOfScissorArmy == 0 && sizeOfLizardArmy == 0)
                    noWinner = false;
            }
        }
    }
}
