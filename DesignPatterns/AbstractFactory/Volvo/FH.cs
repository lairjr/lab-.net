using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Volvo
{
    public class FH : Truck
    {
        public FH()
        {
            this.ModelName = "FH";
        }

        public override bool HasBucket()
        {
            return false;
        }
    }
}
