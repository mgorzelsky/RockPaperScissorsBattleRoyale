using System;

namespace RockPaperScissorsBattleRoyale
{
    class Program
    {
        static void Main()
        {
            Simulation simulation = new Simulation(10);
            simulation.Start();

            //write results to file here
        }
    }
}
