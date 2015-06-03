using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethods
{
    public class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        public virtual string Display()
        {
            return string.Format("Name: {0} \nSalary: {1} \n", this.Name, this.Salary);
        }
    }
}
