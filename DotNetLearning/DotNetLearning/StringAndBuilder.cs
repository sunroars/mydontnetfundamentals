using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DotNetLearning
{
    public class StringAndBuilder
    {
        public static void BuilderMain()
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            Slow();
            Console.WriteLine("slow elapsed " + (st.ElapsedMilliseconds) + " ms");

            st.Restart();
            Fast();
            Console.WriteLine("fast elapsed " + (st.ElapsedMilliseconds) + " ms");
        }

        public static void Fast()
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < 100000; i++)
                s.Append("*");
        }

        public static void Slow()
        {
            String s = "";
            for (int i = 0; i < 100000; i++)
                s += "*";
        }
    }
}
