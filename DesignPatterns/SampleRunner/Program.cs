using SampleRunner.Chain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var chainHandler = new ChainHandler();
            while (true)
            {
                WriteMenu();

                var command = Console.ReadLine();
                switch (command)
                {
                    case "0":
                        return;
                    default:
                        var selectedIndex = int.Parse(command);
                        var designSelected = (DesingPatterns)selectedIndex;
                        Console.Clear();
                        ChainHandler.RunSample(designSelected);

                        Console.Write("Press any key to return to main menu...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                };
            }
        }

        private static void WriteMenu()
        {
            Console.WriteLine("Which sample do you want to run?");
            Console.WriteLine(string.Empty);

            Console.WriteLine("0. Exit");
            foreach (var design in Enum.GetValues(typeof(DesingPatterns)))
            {
                Console.WriteLine(string.Format("{0}. {1}", (int)design, design));
            }
        }
    }
}
