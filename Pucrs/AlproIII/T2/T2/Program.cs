using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2
{
    class Program
    {
        private static NumberGraph graph = new NumberGraph();
        private static Dictionary<Operations, Action> operationsHandler = new Dictionary<Operations, Action>();
        private static readonly string inputFolder = "Files";
        private static readonly string outputFolder = "Output";
        private static readonly int numberBase = 6;

        enum Operations
        {
            Exit = 0,
            SearchOnFile = 1,
            SearchOnFolder = 2
        }

        static void SetupOperations()
        {
            operationsHandler.Add(Operations.Exit, Exit);
            operationsHandler.Add(Operations.SearchOnFile, SearchOnFile);
            operationsHandler.Add(Operations.SearchOnFolder, SearchOnFolder);
        }

        static void Main(string[] args)
        {
            SetupOperations();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Chose your option:");

                foreach (var action in Enum.GetValues(typeof(Operations)))
                {
                    Console.WriteLine(string.Format("{0}. {1}", (int)action, action.ToString()));
                }

                var command = (Operations)Enum.Parse(typeof(Operations), Console.ReadLine());
                operationsHandler[command].Invoke();
            }
        }

        private static void Exit()
        {
            System.Environment.Exit(0);
        }

        private static void SearchOnFile()
        {
            Console.WriteLine("Type file path and output:");
            var filePath = Console.ReadLine();

            graph.Destroy();

            InsertInNumbers(filePath);

            GenerateOutput(filePath);
        }

        private static void InsertInNumbers(string filePath)
        {
            var fullPath = inputFolder + "\\" + filePath;
            var fileLines = File.ReadAllLines(fullPath);

            foreach (var line in fileLines)
            {
                var basedNumber = BasedNumber.Parse(Convert.ToInt32(line), numberBase);
                graph.Insert(basedNumber);
            }
        }

        private static void GenerateOutput(string filePath)
        {
            Console.WriteLine(string.Format("File[{0}]: Searching longest path...", filePath));

            var clock = new Stopwatch();

            clock.Start();

            var biggestPath = graph.GetBiggestPath();

            clock.Stop();

            var isFirst = true;

            var fullPath = outputFolder + "\\" + filePath + ".result";
            using (var sw = File.CreateText(fullPath))
            {
                sw.WriteLine(string.Format("Time spent: {0} milliseconds", clock.ElapsedMilliseconds));
                sw.WriteLine(string.Format("Longest path: {0}", biggestPath.Count()));

                foreach (var number in biggestPath)
                {
                    if (isFirst)
                    {
                        sw.Write(string.Format("{0}", number.ToDecimal()));
                        isFirst = false;
                    }
                    else
                        sw.Write(string.Format(", {0}", number.ToDecimal()));
                }
            }
        }

        private static void SearchOnFolder()
        {
            var files = Directory.GetFiles(inputFolder).Select(f => Path.GetFileName(f));

            foreach (var file in files)
            {
                graph.Destroy();

                InsertInNumbers(file);

                GenerateOutput(file);
            }
        }
    }
}
