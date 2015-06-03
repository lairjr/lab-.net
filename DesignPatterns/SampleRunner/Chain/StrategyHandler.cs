using Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRunner.Chain
{
    public class StrategyHandler : ISampleRunner
    {
        public void RunSample(DesingPatterns pattern)
        {
            if (pattern == DesingPatterns.Strategy)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Chose the payment type class you want to use:");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("1. Cash");
                    Console.WriteLine("2. Credit Card");

                    var option = int.Parse(Console.ReadLine());
                    Sale sale = null;
                    switch (option)
                    {
                        case 0:
                            return;
                        case 1:
                            sale = new Sale(new Cash());
                            break;
                        case 2:
                            sale = new Sale(new CreditCard());
                            break;
                    }
                    sale.PerformSale();
                    Console.ReadLine();
                }
            }
        }
    }
}
