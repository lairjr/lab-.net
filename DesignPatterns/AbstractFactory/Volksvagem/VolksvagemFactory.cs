using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Volksvagem
{
    public class VolksvagemFactory : AbstractFactory
    {
        public override Truck CreateTruck()
        {
            return new Titan();
        }

        public override Car CreateCar()
        {
            return new Fusca();
        }
    }
}
