using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetLearning
{
    public class ThreadResetEvents
    {
        ManualResetEvent mEventStar = new ManualResetEvent(true);
        ManualResetEvent mEventHash = new ManualResetEvent(true);
        //AutoResetEvent aEvent = new AutoResetEvent(false);

        ManualResetEvent aEvent = new ManualResetEvent(false);

        private int i = 0, j = 0, K = 0;

        public void DrawPattern()
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(DrawStar));

            Thread t2 = new Thread(new ParameterizedThreadStart(DrawHash));

            t1.Start();

            t2.Start();
        }

        public void DrawPatternAuto()
        {
            Thread ta1 = new Thread(new ParameterizedThreadStart(DrawStarAuto));

            Thread ta2 = new Thread(new ParameterizedThreadStart(DrawHashAuto));

            Thread ta3 = new Thread(new ParameterizedThreadStart(DrawTildaAuto));

            ta1.Start();

            ta2.Start();

            ta3.Start();

            aEvent.Set();

            Thread.Sleep(1000);

            aEvent.Reset();

            Console.WriteLine("Press any key for starting Draw pattern again...");

            Console.ReadKey();

            aEvent.Set();
        }

        private void DrawStarAuto(object obj)
        {
            while (i < 5)
            {
                Console.WriteLine(".*.");
                Thread.Sleep(2000);
                aEvent.WaitOne();
                i++;
            }

        }

        private void DrawHashAuto(object obj)
        {
            while (j < 5)
            {
                Console.WriteLine(".#.");
                Thread.Sleep(2000);
                aEvent.WaitOne();

                j++;
            }
        }

        private void DrawTildaAuto(object obj)
        {
            while (K < 5)
            {
                Console.WriteLine(".~.");
                Thread.Sleep(2000);
                aEvent.WaitOne();

                K++;
            }
        }

        private void DrawStar(object obj)
        {
            while (i < 5)
            {
                Console.WriteLine(".*.");
                mEventHash.Set();
                mEventStar.Reset();
                mEventStar.WaitOne();

                i++;
            }

        }

        private void DrawHash(object obj)
        {
            while (j < 5)
            {
                Console.WriteLine(".#.");
                mEventStar.Set();
                mEventHash.Reset();
                mEventHash.WaitOne();

                j++;
            }
        }
    }
}
