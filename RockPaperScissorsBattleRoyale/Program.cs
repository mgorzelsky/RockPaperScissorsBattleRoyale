using System;

namespace RockPaperScissorsBattleRoyale
{
    class Program
    {
        static void Main()
        {
            Console.Write("How many times would you like to run the simulation? : ");
            Int32.TryParse(Console.ReadLine(), out int numberOfSimulations);

            Console.Write("How many soldiers should each army start with? : ");
            Int32.TryParse(Console.ReadLine(), out int initialArmySize);

            string[] textHeader = { "Starting army size: " + initialArmySize + "   Number of simulations: " + numberOfSimulations };
            System.IO.File.WriteAllLines(@"C:\Users\Admin1\Documents\CodeFiles\RPSBRresults.txt", textHeader);

            for (int i = 0; i < numberOfSimulations; i++)
            {
                Simulation simulation = new Simulation(initialArmySize);

                using System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Admin1\Documents\CodeFiles\RPSBRresults.txt", true);
                file.WriteLine(simulation.Start());
            }
        }
    }
}
