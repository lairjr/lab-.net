using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class Truck : Vehicle
    {
        public string TrackerName { get; set; }

        public abstract bool HasBucket();
    }
}
