using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Builders
{
    public class FuscaBuilder : VehicleBuilder
    {
        public override void BuildDoors()
        {
            this.Vehicle.Doors = 4;
        }

        public override void BuildEngine()
        {
            this.Vehicle.Engine = "V4";
        }

        public override void BuildName()
        {
            this.Vehicle.Name = "Fusca";
        }

        public override void BuildWheels()
        {
            this.Vehicle.Wheels = 4;
        }
    }
}
