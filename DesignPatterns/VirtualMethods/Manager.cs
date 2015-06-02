using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethods
{
    public class Manager : Employee
    {
        public string Department { get; set; }

        public Manager(string name, decimal salary, string department)
            : base(name, salary)
        {
            this.Department = department;
        }

        public override string Display()
        {
            return base.Display() + string.Format("Department: {0} \n", this.Department);
        }
    }
}
