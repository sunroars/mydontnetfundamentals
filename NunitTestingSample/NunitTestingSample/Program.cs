using Converter;
using System;

namespace NunitTestingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzzConverter convert = new FizzBuzzConverter();

            Console.WriteLine("Hello World!");

            for (int counter = 0; counter < 100; counter++)
            {
                Console.WriteLine($"Value of Counter : {convert.GetConvertedValue(counter)}");
            }
            Console.ReadKey();
        }
    }
}
