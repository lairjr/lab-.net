using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class Program
    {
        private static BinaryTree tree = new BinaryTree();
        private static IDictionary<MenuActions, Action> actionHandler;

        public enum MenuActions
        {
            Exit = 0,
            Import = 1,
            Print = 2,
            Exist = 3,
            Destroy = 4,
            Height = 5,
            Count = 6,
            Father = 7
        }

        static void Main(string[] args)
        {
            SetupActions();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Chose your option:");
                foreach (var action in Enum.GetValues(typeof(MenuActions)))
                {
                    Console.WriteLine(string.Format("{0}. {1}", (int)action, action.ToString()));
                }
                var command = (MenuActions)Enum.Parse(typeof(MenuActions), Console.ReadLine());
                actionHandler[command].Invoke();
            }
        }

        private static void SetupActions()
        {
            actionHandler = new Dictionary<MenuActions, Action>();

            actionHandler.Add(MenuActions.Exit, Exit);
            actionHandler.Add(MenuActions.Import, Import);
            actionHandler.Add(MenuActions.Print, Print);
            actionHandler.Add(MenuActions.Exist, Exist);
            actionHandler.Add(MenuActions.Destroy, Destroy);
            actionHandler.Add(MenuActions.Height, Height);
            actionHandler.Add(MenuActions.Count, Count);
            actionHandler.Add(MenuActions.Father, Father);
        }

        private static void Import()
        {
            Console.WriteLine("Type file path:");

            var filePath = Console.ReadLine();
            var fileLines = File.ReadAllLines(filePath);

            foreach (var line in fileLines)
            {
                tree.insert(Convert.ToInt32(line));
            }
        }

        private static void Print()
        {
            tree.Print();
        }

        private static void Destroy()
        {
            tree.destroy();
        }

        private static void Exist()
        {
            Console.WriteLine("Type the value you are looking for:");
            var value = int.Parse(Console.ReadLine());
            var exist = tree.Exist(value);
            if (exist)
                Console.WriteLine("Value exist!");
            else
                Console.WriteLine("Value DOES NOT exist!");
            Console.ReadLine();
        }

        private static void Exit()
        {
            System.Environment.Exit(0);
        }

        private static void Height()
        {
            var treeHeight = tree.GetHeight();
            Console.WriteLine(string.Format("Tree height: {0}", treeHeight));
            Console.ReadLine();
        }

        private static void Count()
        {
            var count = tree.GetCount();
            Console.WriteLine(string.Format("Count: {0}", count));
            Console.ReadLine();
        }

        private static void Father()
        {
            Console.WriteLine("Type the value you are looking for:");
            var value = int.Parse(Console.ReadLine());
            var fatherValue = tree.GetFather(value);

            Console.WriteLine(string.Format("Father: {0}", fatherValue));
            Console.ReadLine();
        }
    }
}
