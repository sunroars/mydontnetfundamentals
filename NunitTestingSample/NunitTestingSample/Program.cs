using Converter;
using System;
using System.Collections.Generic;

namespace NunitTestingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzzConverter convert = new FizzBuzzConverter();

            Console.WriteLine("Hello World!");

            FizzBuzzDataRepo drepo = new FizzBuzzDataRepo();

            List<int> testData = drepo.GetFizzBuzzTestData();

            foreach (int counter in testData)
            {
                Console.WriteLine($"Value of Counter : {convert.GetConvertedValue(counter)}");
            }

            Console.ReadKey();
        }
    }
}
