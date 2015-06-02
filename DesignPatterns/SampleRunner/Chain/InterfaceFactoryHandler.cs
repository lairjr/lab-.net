using InterfaceFactory.Car;
using InterfaceFactory.Plane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRunner.Chain
{
    public class InterfaceFactoryHandler : ISampleRunner
    {
        public void RunSample(DesingPatterns pattern)
        {
            if (pattern == DesingPatterns.InterfaceFactory)
            {
                while (true)
                {
                    Console.WriteLine("Chose which factory you want to use:");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("1. Plane");
                    Console.WriteLine("2. Car");

                    var option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 0:
                            return;
                        case 1:
                            var car = InterfaceFactory.InterfaceFactory<ICar>.GetInstance();
                            car.Ride();
                            Console.Clear();
                            break;
                        case 2:
                            var plane = InterfaceFactory.InterfaceFactory<IPlane>.GetInstance();
                            plane.Fly();
                            Console.Clear();
                            break;
                    }
                }
            }
        }
    }
}
