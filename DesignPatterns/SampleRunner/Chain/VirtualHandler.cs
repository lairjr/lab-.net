using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualMethods;

namespace SampleRunner.Chain
{
    public class VirtualHandler : ISampleRunner
    {
        public void RunSample(DesingPatterns pattern)
        {
            if (pattern == DesingPatterns.VirtualMethods)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Chose which kind of employee u wanna see:");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("1. Employee");
                    Console.WriteLine("2. Manager");
                    Console.WriteLine("3. Employee coming from Manager");

                    var option = int.Parse(Console.ReadLine());
                    Employee employee;
                    Manager manager;
                    switch (option)
                    {
                        case 0:
                            return;
                        case 1:
                            employee = new Employee("Lair", 10000);
                            Console.Write(employee.Display());
                            Console.ReadLine();
                            break;
                        case 2:
                            manager = new Manager("Lair", 10000, "IT");
                            Console.Write(manager.Display());
                            Console.ReadLine();
                            break;
                        case 3:
                            employee = (Employee)new Manager("Lair", 10000, "TI");
                            Console.Write(employee.Display());
                            Console.ReadLine();
                            break;
                    }
                }
            }
        }
    }
}
