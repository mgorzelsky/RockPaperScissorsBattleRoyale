using System;

namespace RockPaperScissorsBattleRoyale
{
    class Program
    {
        static void Main()
        {
            string[] textHeader = { "Log: wins in Rock-Paper-Scissors Battle Royal", "" };
            System.IO.File.WriteAllLines(@"C:\Users\Admin1\Documents\CodeFiles\RPSBRresults.txt", textHeader);

            int numberOfSimulations = 5;
            for (int i = 0; i < numberOfSimulations; i++)
            {
                Simulation simulation = new Simulation(10);

                using System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Admin1\Documents\CodeFiles\RPSBRresults.txt", true);
                file.WriteLine(simulation.Start());
            }
        }
    }
}
