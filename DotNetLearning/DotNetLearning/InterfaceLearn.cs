using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLearning
{
    interface InterfaceLearn :InterfaceOne,InterfaceTwo, InterfaceThree
    {
        void SimplestMethod(int abc);
    }

    interface InterfaceOne
    {
        void SimpleMethod();

        void SimpleMethod(string abc);

        void SimplestMethod();
    }

    interface InterfaceTwo
    {
        void SimpleMethod();
    }

    interface InterfaceThree
    {
        void SimplestMethod(string abc);
    }

    public class InterfaceImplementor : InterfaceLearn
    {
        void InterfaceOne.SimpleMethod()
        {
            throw new NotImplementedException();
        }

         void InterfaceOne.SimpleMethod(string abc)
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

        public void SimplestMethod(string abc)
        {
            throw new NotImplementedException();
        }
    }
}
