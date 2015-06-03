using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Builders
{
    public class KawazakiBuilder : VehicleBuilder
    {
        public override void BuildDoors()
        {
            this.Vehicle.Doors = 0;
        }

        public override void BuildEngine()
        {
            this.Vehicle.Engine = "500C";
        }

        public override void BuildName()
        {
            this.Vehicle.Name = "Kawazaki";
        }

        public override void BuildWheels()
        {
            this.Vehicle.Wheels = 2;
        }
    }
}
