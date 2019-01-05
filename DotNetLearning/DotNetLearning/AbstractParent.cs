using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLearning
{
    public abstract class AbstractParent
    {
        public virtual void SimpleMethod()
        {
            Console.WriteLine("ParentClass : SimpleMethod");
        }

        public virtual void SecondSimpleMethod()
        {
            Console.WriteLine("ParentClass : SecondSimpleMethod");
        }

        public abstract void SimpleAbstractMethod();

        public abstract void SecondAbstractMethod();
    }

    public abstract class AbstractSecondParent : MagluClass
    {

    }

    public class MagluClass
    { 
    
    }

    public class AbstractDerived : AbstractParent
    {
        public override void SimpleAbstractMethod()
        {
            throw new NotImplementedException();
        }

        public override void SimpleMethod()
        {
            Console.WriteLine("AbstractDerived : SimpleMethod");
        }

        public override void SecondAbstractMethod()
        {
            throw new NotImplementedException();
        }
    }
}
