using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class CreditCard : IPayment
    {
        public void PerformPayment()
        {
            Console.WriteLine("This is the credit card sale mode...");
        }
    }
}
