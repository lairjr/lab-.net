using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Volksvagem
{
    public class Titan : Truck
    {
        public Titan()
        {
            this.ModelName = "Titan";
        }

        public override bool HasBucket()
        {
            return true;
        }
    }
}
