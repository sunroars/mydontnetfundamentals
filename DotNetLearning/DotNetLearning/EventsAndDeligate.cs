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
            myAdditionMethod(5,5);
        }
    }
}
