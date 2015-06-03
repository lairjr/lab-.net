using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Cash : IPayment
    {
        public void PerformPayment()
        {
            Console.WriteLine("This is the cash sale mode...");
        }
    }
}
