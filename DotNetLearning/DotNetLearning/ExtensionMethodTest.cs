namespace DotNetLearning
{
    public static class ExtensionMethodTest
    {
        public static void AppendHeader(this string str)
        {
            str = str + "[HEADER TEXT]";
        }

        public static int AddFiveAndDevideByTen(this int inputVal)
        {
            return ((inputVal + 5) / 10);
        }

        public static string Describe(this Employee emp)
        {
            return $"EmployeName : {emp.Name}, EmployeeSalary :{emp.Salary}";
        }
    }
}
