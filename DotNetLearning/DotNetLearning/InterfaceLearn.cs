using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLearning
{
    interface InterfaceLearn :InterfaceOne,InterfaceTwo
    {
        void SimplestMethod(int abc);
    }

    interface InterfaceOne
    {
        void SimpleMethod();

        void SimplestMethod();
    }

    interface InterfaceTwo
    {
        void SimpleMethod();
    }

    public class InterfaceImplementor : InterfaceLearn
    {
        void InterfaceOne.SimpleMethod()
        {
            throw new NotImplementedException();
        }

        void InterfaceTwo.SimpleMethod()
        {
            throw new NotImplementedException();
        }

        public void SimplestMethod()
        {
            throw new NotImplementedException();
        }

        public void SimplestMethod(int abc)
        {
            throw new NotImplementedException();
        }
    }
}
