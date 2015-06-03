using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceFactory.Car
{
    public class Car : ICar
    {
        public void Ride()
        {
            Console.WriteLine("Car is riding...");
            Console.ReadLine();
        }
    }
}
