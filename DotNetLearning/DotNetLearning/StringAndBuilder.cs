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
            slow();
            Console.WriteLine("slow elapsed " + (st.ElapsedMilliseconds) + " ms");

            st.Restart();
            fast();
            Console.WriteLine("fast elapsed " + (st.ElapsedMilliseconds) + " ms");
        }

        public static void fast()
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < 100000; i++)
                s.Append("*");
        }

        public static void slow()
        {
            String s = "";
            for (int i = 0; i < 100000; i++)
                s += "*";
        }
    }
}
