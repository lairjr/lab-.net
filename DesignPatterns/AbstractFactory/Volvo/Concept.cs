using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Volvo
{
    public class Concept : Car
    {
        public Concept()
        {
            this.ModelName = "Concept";
        }

        public override bool IsHatch()
        {
            return false;
        }
    }
}
