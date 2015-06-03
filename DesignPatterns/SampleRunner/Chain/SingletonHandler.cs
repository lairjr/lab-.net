using SampleRunner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRunner.Chain
{
    public class SingletonHandler : ISampleRunner
    {
        public void RunSample(DesingPatterns pattern)
        {
            if (pattern == DesingPatterns.Singleton)
            {
                Console.WriteLine("Creating new object...");
                var newPerson = Singleton.GenericSingle<Person>.GetInstance();
                Console.WriteLine("Set person name: ");
                newPerson.Name = Console.ReadLine();
                Console.WriteLine("Trying to instanciated second object...");
                var secondPerson = Singleton.GenericSingle<Person>.GetInstance();
                Console.WriteLine(string.Format("Second object name: {0}", secondPerson.Name));
                Console.WriteLine(string.Empty);
            }
        }
    }
}