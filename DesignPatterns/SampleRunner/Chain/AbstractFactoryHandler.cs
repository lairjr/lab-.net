using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory;
using AbstractFactory.Volksvagem;
using AbstractFactory.Volvo;

namespace SampleRunner.Chain
{
    public class AbstractFactoryHandler : ISampleRunner
    {
        public void RunSample(DesingPatterns pattern)
        {
            if (pattern == DesingPatterns.AbstractFactory)
            {
                while (true)
                {
                    Console.WriteLine("Chose which factory you want to use:");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("1. Volksvagem");
                    Console.WriteLine("2. Volvo");
                    var option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 0:
                            return;
                        case 1:
                            this.RunFactory(new VolksvagemFactory());
                            Console.Clear();
                            break;
                        case 2:
                            this.RunFactory(new VolvoFactory());
                            Console.Clear();
                            break;
                    }
                }
            }
        }

        private void RunFactory(AbstractFactory.AbstractFactory factory)
        {
            Console.WriteLine("Chose which type of vehicle you want to see:");
            Console.WriteLine("1. Truck");
            Console.WriteLine("2. Car");

            var option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine(factory.CreateTruck().ModelName);
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine(factory.CreateCar().ModelName);
                    Console.ReadLine();
                    break;
            }
        }
    }
}
