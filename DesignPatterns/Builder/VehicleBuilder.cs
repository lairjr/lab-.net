using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public abstract class VehicleBuilder
    {
        public VehicleBuilder()
        {
            this.Vehicle = new Vehicle();
        }

        public Vehicle Vehicle { get; set; }

        public abstract void BuildDoors();
        public abstract void BuildEngine();
        public abstract void BuildName();
        public abstract void BuildWheels();
    }
}
