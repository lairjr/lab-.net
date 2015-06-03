using Builder;
using Builder.Builders;
using Builder.Constructor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRunner.Chain
{
    public class BuilderHandler : ISampleRunner
    {
        public void RunSample(DesingPatterns pattern)
        {
            if (pattern == DesingPatterns.Builder)
            {
                while (true)
                {
                    Console.WriteLine("Chose which builder you want to use:");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("1. Kawazaki");
                    Console.WriteLine("2. Fusca");
                    var option = int.Parse(Console.ReadLine());
                    VehicleBuilder builder = null;

                    switch (option)
                    {
                        case 0:
                            return;
                        case 1:
                            builder = new KawazakiBuilder();
                            break;
                        case 2:
                            builder = new FuscaBuilder();
                            break;
                    }
                    Constructor.Contruct(builder);
                    builder.Vehicle.Show();
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
