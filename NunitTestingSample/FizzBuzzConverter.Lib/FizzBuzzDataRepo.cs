using System;
using System.Collections.Generic;

namespace Converter
{
    public class FizzBuzzDataRepo : IFizzBuzzDataRepo
    {
        public List<int> GetFizzBuzzTestData()
        {
            //Ideally thi sis coming from DB but we will just mock.
            List<int> tempResults = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                tempResults.Add(i);
            }

            return tempResults;
        }
    }
}