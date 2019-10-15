using System;

namespace RockPaperScissorsBattleRoyale
{
    class Program
    {
        static void Main()
        {
            Simulation simulation = new Simulation(50);
            simulation.Start();

            //write results to file here
        }
    }
}
