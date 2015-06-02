using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Vehicle
    {
        public int Doors { get; set; }
        public string Engine { get; set; }
        public string Name { get; set; }
        public int Wheels { get; set; }

        public void Show()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Format("Doors: {0}", this.Doors));
            Console.WriteLine(string.Format("Engine: {0}", this.Engine));
            Console.WriteLine(string.Format("Name: {0}", this.Name));
            Console.WriteLine(string.Format("Wheels: {0}", this.Wheels));
            Console.WriteLine(string.Empty);
        }
    }
}
