using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetLearning
{

    public class EventsAndDeligate
    {
        public EventsAndDeligate()
        {

        }

        public delegate void PingSupplier();

        public event PingSupplier PingSupplierEvent;

        public void FiveSecondsCalculator()
        {
            while (true)
            {
                Thread.Sleep(5000);

                PingSupplierEvent.Invoke();

                Thread.Sleep(5000);
            }

        }

        public void ApplyMyAdditionLogic(Func<int, int, int> myAdditionMethod)
        {
            myAdditionMethod(5, 5);
        }
    }

    public class TrainSignalDelegate
    {

        public delegate void TrainIsComing();

        public event TrainIsComing comingEvent;

        public void HereComesTheTarin()
        {
            comingEvent();
        }
    }

    public class Vehicle
    {
        public Vehicle(TrainSignalDelegate trainSignal)
        {
            trainSignal.comingEvent += StopTheVehicle;
        }

        public virtual void StopTheVehicle()
        {
            Console.WriteLine("Vehicle is Stopping");
        }
    }

    public class Truck : Vehicle
    {
        public Truck(TrainSignalDelegate trainSignal) : base(trainSignal)
        {
        }

        public override void StopTheVehicle()
        {
            Console.WriteLine("Truck is Stopping");
        }

    }

    public class Bike : Vehicle
    {
        public Bike(TrainSignalDelegate trainSignal) : base(trainSignal)
        {
        }

        public override void StopTheVehicle()
        {
            Console.WriteLine("Bike is Stopping");
        }

    }


    public class ShowNumbersUsingDelegate
    {
        public delegate bool NumberMatchCondition(int number);

        public List<int> numberList = new List<int>() { 1, 2, 3, 4, 5, 11, 25, 52, 200 };

        public IEnumerable<int> ReturnNumbersBasedOnCondition(List<int> NumberList, NumberMatchCondition matchCondition)
        {
            foreach (var number in NumberList)
            {
                if (matchCondition(number))
                {
                    yield return number;
                }
            }
        }

    }
}
