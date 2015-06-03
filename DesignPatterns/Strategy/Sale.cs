using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Sale
    {
        private IPayment salePayment;

        public Sale(IPayment salePayment)
        {
            this.salePayment = salePayment;
        }

        public void PerformSale()
        {
            Console.WriteLine("Initializing sale process...");
            Console.WriteLine("Calling perform payment...");
            salePayment.PerformPayment();
        }
    }
}
