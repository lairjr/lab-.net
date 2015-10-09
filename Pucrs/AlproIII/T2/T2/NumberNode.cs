using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2
{
    public class NumberNode
    {
        public BasedNumber Number { get; set; }
        public List<NumberNode> LinkedNumbers { get; set; }

        public NumberNode(BasedNumber number)
        {
            this.Number = number;
            this.LinkedNumbers = new List<NumberNode>();
        }
    }
}
