using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceFactory.Plane
{
    public class Plane : IPlane
    {
        public void Fly()
        {
            Console.WriteLine("Plane is flying...");
            Console.ReadLine();
        }
    }
}
