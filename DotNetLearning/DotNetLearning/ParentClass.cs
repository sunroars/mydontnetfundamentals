using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLearning
{

    public class ParentClass
    {
        public virtual void SimpleMethod()
        {
            Console.WriteLine("ParentClass : SimpleMethod");
        }
    }

    public class DerivedClass : ParentClass
    {
        public override void SimpleMethod()
        {
            Console.WriteLine("DerivedClass : SimpleMethod");
        }
    }

    public class SecondDerivedClass : DerivedClass
    {
        public override void SimpleMethod()
        {
            Console.WriteLine("SecondDerivedClass : SimpleMethod");
        }
    }
}
