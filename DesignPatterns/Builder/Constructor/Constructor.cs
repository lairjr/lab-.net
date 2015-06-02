using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Constructor
{
    public class Constructor
    {
        public static void Contruct(VehicleBuilder builder)
        {
            builder.BuildDoors();
            builder.BuildEngine();
            builder.BuildName();
            builder.BuildWheels();
        }
    }
}
