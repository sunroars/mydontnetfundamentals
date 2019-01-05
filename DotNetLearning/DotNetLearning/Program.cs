using ReferenceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetLearning
{
    class Program
    {
        static void Main(string[] args)
        {

            //OperatorOverloadTest();

            //StringAndBuilderPerformance();

            //TryToRunMutexThread();

            InheritanceExample();

            //ValueTypeRefTypeExample();

            //BoxingUnboxing();

            //string abc = "";

            //abc.AppendHeader();

            //EventTest();

            //ThreadEventExample();

            //ConstReadonlyExample();

            //Console.WriteLine("Return Value : " + CoalesceAndTernaryOperator());

            Console.WriteLine("Press any key to continue . . . . .");

            Console.ReadKey();

        }

        static void OperatorOverloadTest()
        {
            Employee emp1 = new Employee() { Name = "Sunil", Salary = 6000 };
            Employee emp2 = new Employee() { Name = "Jayesh", Salary = 7000 };

            Console.WriteLine("Result : " + (emp1 > emp2));

            Console.WriteLine("Sum Salary : " + (emp1 + emp2).Salary);
        }

        static void StringAndBuilderPerformance()
        {
            StringAndBuilder.BuilderMain();
        }

        static void TryToRunMutexThread()
        {

            using (Mutex mutThread = new Mutex(false, "MutexThreadingExample"))
            {
                if (!mutThread.WaitOne(1000, true))
                {
                    Console.WriteLine("Another app instance is running. Bye!");
                    return;
                }
                int count = 0;

                while (count < 100)
                {
                    Console.WriteLine("Normal Processing : " + count);
                    count++;
                    Thread.Sleep(1000);
                }

                Console.WriteLine("Thread Completed");
            }

        }

        static string CoalesceAndTernaryOperator()
        {
            string a = "a";

            string b = "a";

            string x = "";

            x = a.Equals(b) ? "TRUE" : null;

            int i = 1;
            int j = 1;
            int k = 1;

            int zero = 0;

            i = i == 1 ? j + 1 : k / zero;

            i = i == 1 ? Foo() : Bar();

            return x ?? "Default";

        }

        static int Foo()
        {
            return 0;
        }

        static int Bar()
        {
            return 0;
        }

        static void ConstReadonlyExample()
        {
            Console.WriteLine("Static Value befor CTOR : " + MyClass.staticIntValue);

            MyClass mcObj = new MyClass();

            Console.WriteLine("Static Value after CTOR 1: " + MyClass.staticIntValue);

            MyClass mcObjInt = new MyClass(25);

            Console.WriteLine("Static Value after CTOR 2 : " + MyClass.staticIntValue);

            MyClass mcObjInt2 = new MyClass(25);
            MyClass mcObjInt3 = new MyClass(25);

            Console.WriteLine("Static Value after CTOR 3/4 : " + MyClass.staticIntValue);

            Console.WriteLine("Readonly Value : " + mcObj.roIntValue);

            Console.WriteLine("Readonly Value IntCTOR: " + mcObjInt.roIntValue);

            // mcObj.roIntValue = 99; Compile Time Error

            //MyClass.constIntValue = 98;  Compile Time Error

            Console.WriteLine("Const Value : " + MyClass.constIntValue);
        }

        static void InheritanceExample()
        {
            ParentClass p = new ParentClass();
            p.SimpleMethod();

            //Run time error
            //DerivedClass d = new ParentClass() as DerivedClass;
            //d.SimpleMethod();

            ParentClass pd = new DerivedClass() as ParentClass;
            pd.SimpleMethod();

            DerivedClass dc = new ParentClass() as DerivedClass; ;
            dc.SimpleMethod();

            ParentClass psd = new SecondDerivedClass() as ParentClass;
            psd.SimpleMethod();

        }

        static void ValueTypeRefTypeExample()
        {
            int number = 5;
            string myString = "Sunil";
            List<int> intList = new List<int>() { 1, 2, 3 };

            ValueTypeRefType objVal = new ValueTypeRefType();
            objVal.AlterNumber(ref number);
            objVal.AlterCollection(intList);
            objVal.AlterString(ref myString);

            Console.WriteLine("Number After AlterNumber : " + number);

            Console.WriteLine("IntList Count After Alter : " + intList.Count);

            Console.WriteLine("MyString After AlterString : " + myString);
        }

        static void BoxingUnboxing()
        {

            Int16 intObj16 = 9;

            object objRandom = intObj16;

            intObj16 = (Int16)objRandom;

            // Int16 intObj = objRandom;

        }

        static void EventTest()
        {
            //EventsAndDeligate objEnD = new EventsAndDeligate();
            //objEnD.PingSupplierEvent += objEnD_PingSupplierEvent;
            //objEnD.FiveSecondsCalculator();

            //EventsAndDeligate objEnD = new EventsAndDeligate();

            EventsAndDeligate objEnD = new EventsAndDeligate();
            objEnD.ApplyMyAdditionLogic(AddNumbers);
        }

        static int AddNumbers(int abc, int def)
        {
            Console.WriteLine("Sum is :" + (abc + def));

            return 0;
        }

        static void objEnD_PingSupplierEvent()
        {
            Console.WriteLine("Ping received from supplier class");
        }

        static void ThreadEventExample()
        {
            ThreadResetEvents objTRE = new ThreadResetEvents();

            objTRE.DrawPatternAuto();
        }

        #region Method Overloading

        public static void SimpleMethod()
        {
            Console.WriteLine("SimpleMethod");
        }

        public static void SimpleMethod(int abc)
        {
            Console.WriteLine("SimpleMethod : " + abc);
        }

        public static void SimpleMethod(string xyz)
        {
            Console.WriteLine("SimpleMethod : " + xyz);
        }

        #endregion
    }

}
