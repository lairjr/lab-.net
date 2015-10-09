using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public enum Commands {
        Exit = 0,
        Insert = 1,
        Print = 2,
        GetFather = 3,
        PrintMaxNodeValue = 4,
        PrintMaxPath = 5
    }

    class Program
    {
        private static Dictionary<Commands, Action> commandHandler = new Dictionary<Commands,Action>();
        private static Tree tree;

        static void Main(string[] args)
        {
            SetUpCommands();
            Console.WriteLine("Insert the root value:");
            var rootValue = int.Parse(Console.ReadLine());
            tree = new Tree(rootValue);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Chose your action:");
                foreach (var action in Enum.GetValues(typeof(Commands)))
                {
                    Console.WriteLine(string.Format("{0}. {1}", (int)action, action.ToString()));
                }
                var command = (Commands)Enum.Parse(typeof(Commands), Console.ReadLine());
                commandHandler[command].Invoke();
            }
        }

        private static void SetUpCommands()
        {
            commandHandler.Add(Commands.Exit, Exit);
            commandHandler.Add(Commands.Insert, Insere);
            commandHandler.Add(Commands.Print, Print);
            commandHandler.Add(Commands.GetFather, GetFather);
            commandHandler.Add(Commands.PrintMaxNodeValue, GetMaxNodeValue);
            commandHandler.Add(Commands.PrintMaxPath, GetMaxPathValue);
        }

        private static void Insere()
        {
            Console.WriteLine("Insert value and father (4 20):");
            var values = Console.ReadLine().Split(' ');
            var nodeValue = int.Parse(values[0]);
            var fatherValue = int.Parse(values[1]);
            tree.InsertNode(nodeValue, fatherValue);
        }

        private static void Exit()
        {
            System.Environment.Exit(0);
        }

        private static void Print()
        {
            tree.Print();
        }

        private static void GetFather()
        {
            tree.GetFather();
        }

        private static void GetMaxNodeValue()
        {
            tree.PrintMaxNodeValue();
        }

        private static void GetMaxPathValue()
        {
            tree.GetMaxPath();
        }
    }
}