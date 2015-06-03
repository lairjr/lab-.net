using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Volksvagem
{
    public class Fusca : Car
    {
        public Fusca()
        {
            this.ModelName = "Fusca";
        }

        public override bool IsHatch()
        {
            return true;
        }
    }
}
