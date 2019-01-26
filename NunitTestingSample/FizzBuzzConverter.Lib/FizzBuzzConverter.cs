using System;
using System.Collections.Generic;
using System.Text;

namespace Converter
{
    public class FizzBuzzConverter
    {
        public FizzBuzzConverter()
        {

        }

        public string GetConvertedValue(int inputVal)
        {
            StringBuilder sb = new StringBuilder();

            if (inputVal % 3 == 0)
                sb.Append("Fizz");
            if (inputVal % 5 == 0)
                sb.Append("Buzz");
            if (sb.Length == 0)
                sb.Append(inputVal.ToString());

            return sb.ToString();
        }

        public List<string> GetConvertedValues(IFizzBuzzDataRepo repo)
        {
            StringBuilder sb = new StringBuilder();
            List<string> convertedResuls = new List<string>();

            foreach (var inputVal in repo.GetFizzBuzzTestData())
            {
                if (inputVal % 3 == 0)
                    sb.Append("Fizz");
                if (inputVal % 5 == 0)
                    sb.Append("Buzz");
                if (sb.Length == 0)
                    sb.Append(inputVal.ToString());

                convertedResuls.Add($"Input {inputVal} OutPut {sb.ToString()}");
                sb.Clear();
            }
            return convertedResuls;

        }
    }
}
