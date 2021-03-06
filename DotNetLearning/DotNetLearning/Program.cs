﻿using ReferenceLibrary;
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
            ShowNumbersUsingDelegateExample();

            //TrainDelegateExaple();

            //OperatorOverloadTest();

            //StringAndBuilderPerformance();

            //TryToRunMutexThread();

            //InheritanceExample();

            //ValueTypeRefTypeExample();

            //BoxingUnboxing();

            //string abc = "";

            //abc.AppendHeader();

            //EventTest();

            //ThreadEventExample();

            //ConstReadonlyExample();

            //DotNet472DiscardExample();

            //DotNet472PatternMatchingExample();

            //Console.WriteLine("Return Value : " + CoalesceAndTernaryOperator());

            Console.WriteLine("Press any key to continue . . . . .");

            Console.ReadKey();

        }

        static void ShowNumbersUsingDelegateExample()
        {
            ShowNumbersUsingDelegate snd = new ShowNumbersUsingDelegate();

            IEnumerable<int> listResult1 = snd.ReturnNumbersBasedOnCondition(snd.numberList, delegate(int num){return num > 5;});
            IEnumerable<int> listResult2 = snd.ReturnNumbersBasedOnCondition(snd.numberList, delegate (int num) { return num > 25; });
            IEnumerable<int> listResult3 = snd.ReturnNumbersBasedOnCondition(snd.numberList, delegate (int num) { return num > 50; });
        }

        static void OperatorOverloadTest()
        {
            Employee emp1 = new Employee() { Name = "Sunil", Salary = 6000 };
            Employee emp2 = new Employee() { Name = "Jayesh", Salary = 7000 };

            Console.WriteLine("GT Comparision Result : " + (emp1 > emp2));

            Console.WriteLine("Sum Salary : " + (emp1 + emp2).Salary);

            Console.WriteLine("== Comparision Result : " + (emp1 == emp2));

            Console.WriteLine("!= Comparision Result : " + (emp1 != emp2));

            Console.WriteLine("equals Comparision Result : " + (emp1.Equals(emp2)));

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

        static void TrainDelegateExaple()
        {
            TrainSignalDelegate tsd = new TrainSignalDelegate();
            new Vehicle(tsd);
            new Truck(tsd);
            new Bike(tsd);
            new Vehicle(tsd);
            new Vehicle(tsd);
            tsd.HereComesTheTarin();
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

        #region DotNet 4.7.2 Features

        public static void DotNet472DiscardExample()
        {
            DotNet472 dn472 = new DotNet472();
            dn472.PerformAddSubDevide(10, 2, out int add, out int sub, out int del);
            Console.WriteLine($"Add 1 : {add}");

            dn472.PerformAddSubDevide(10, 2, out int addRes, out int _, out int _);
            Console.WriteLine($"Add 2 : {addRes}");

            dn472.PerformAddSubDevide(10, 2, out int addOnly, out _, out _);
            Console.WriteLine($"Add 3 : {addOnly}");
        }

        public static void DotNet472PatternMatchingExample()
        {
            DotNet472 dn472 = new DotNet472();
            dn472.PrintObjectValue(10);
            dn472.PrintObjectValue(new Employee() { Name = "Sunil", Salary = 5000 });
            dn472.PrintObjectValue(10.12345M);
            dn472.PrintObjectValue("Hello World");

        }


        #endregion

    }

}
