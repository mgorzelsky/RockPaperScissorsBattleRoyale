using System;

namespace RockPaperScissorsBattleRoyale
{
    class Program
    {
        static void Main()
        {
            Simulation simulation = new Simulation(5, 5, 5);
            simulation.Start();

            //write results to file here
        }
    }
}
