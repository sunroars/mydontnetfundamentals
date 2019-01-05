using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceLibrary
{
    public class MyClass
    {
        //Following assignment will happen only once for all the object Initializations for this class
        public static int staticIntValue = staticIntValue + 1;

        public readonly int roIntValue;

        public const int constIntValue = 20;

        public MyClass()
        {
            //If Static variable is changed in CTOR it will get changed
            //staticIntValue = staticIntValue + 1;

            roIntValue = 15;
        }

        public MyClass(int value)
        {
            roIntValue = value;
        }
    }
}
