using System;
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
}
}
