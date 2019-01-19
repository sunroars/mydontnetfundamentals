using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLearning
{
    class DotNet472
    {
        public void PerformAddSubDevide(int param1, int param2, out int addResult, out int subResult, out int divResult)
        {
            addResult = param1 + param2;
            subResult = param1 - param2;
            divResult = param1 / param2;
        }

        public void PrintObjectValue(object obj)
        {
            switch (obj)
            {
                case int intVal:
                    Console.WriteLine($"integer value : {intVal}");
                    break;
                case Employee emp:
                    Console.WriteLine($"You passed Employee Object Name : {emp.Name}, Salary :{ emp.Salary}");
                    break;
                case decimal _:
                    Console.WriteLine("You passed decimal");
                    break;
                default:
                    Console.WriteLine(obj.ToString());
                    break;
            }
        }

    }
}
