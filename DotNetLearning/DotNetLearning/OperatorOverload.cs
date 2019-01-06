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

        public static bool operator ==(Employee emp1, Employee emp2)
        {
            return emp1.Salary == emp2.Salary;
        }

        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return emp1.Salary != emp2.Salary;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                var employee = obj as Employee;
                return Name == employee.Name && Salary == employee.Salary;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            var hashCode = -1423493799;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Salary.GetHashCode();
            return hashCode;
        }
    }
}
