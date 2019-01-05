using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLearning
{
    public class OperatorOverload
    {

        
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public static bool operator >(Employee emp1, Employee emp2)
        {
            return (emp1.Salary > emp2.Salary);
        }

        public static bool operator <(Employee emp1, Employee emp2)
        {
            return (emp1.Salary < emp2.Salary);
        }

        public static Employee operator +(Employee emp1, Employee emp2)
        {
            Employee result = new Employee();
            result.Salary = (emp1.Salary + emp2.Salary);
            result.Name = emp1.Name + emp2.Name;
            return result;
        }
    }
}
