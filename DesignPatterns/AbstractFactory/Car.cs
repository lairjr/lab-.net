using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class Car : Vehicle
    {
        public string TransmissionTytpe { get; set; }

        public abstract bool IsHatch();
    }
}
