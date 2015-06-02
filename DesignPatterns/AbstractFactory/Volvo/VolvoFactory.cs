using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Volvo
{
    public class VolvoFactory : AbstractFactory
    {
        public override Truck CreateTruck()
        {
            return new FH();
        }

        public override Car CreateCar()
        {
            return new Concept();
        }
    }
}
