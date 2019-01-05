using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaysOfThreading
{
    class Program
    {
        static Semaphore smObj = new Semaphore(3, 3);

        static void Main(string[] args)
        {
            //ThreadUsingAsyncBeginEndInvoke();

            //ThreadUsingAsync();

            //TryToRunMutexThread();

            //SemaphoreExample();

            //ThreadStartingWithTPL();

            //ThreadStartingWithThreadPool();

            ParallelForAndForEach();

            Console.ReadKey();


        }

        static void ParallelForAndForEach()
        {
            List<Exception> listOfExceptions = new List<Exception>();

            List<int> intList = new List<int>() { 1, 2, 3, 0 , 5, 6, 7, 8, 9, 10, 0 };

            //ParallelLoopResult loopResult = Parallel.ForEach(intList, DoSomeOperationOnItem);

            ParallelLoopResult loopResults = Parallel.For(0, 11, X => DoSomeOperationOnItem(intList[X], listOfExceptions));

            //intList.ForEach(X => DoSomeOperationOnItem(X, listOfExceptions));
        }

        static void DoSomeOperationOnItem(int item)
        {

            try
            {
                item = 100 / item;
            }
            catch (AggregateException aex)
            {
                //Console.Write(aex.InnerException.Message);  // Attempted to divide by 0
            }

            item = item + 3;
        }

        static List<Exception> DoSomeOperationOnItem(int item,List<Exception> listOfExceptions )
        {

            try
            {
                item = 100 / item;

                Console.WriteLine("Executing for : " + item);
            }
            catch (Exception aex)
            {
                listOfExceptions.Add(aex);
                //Console.Write(aex.InnerException.Message);  // Attempted to divide by 0
            }

            return listOfExceptions;
        }


        static void ThreadStartingWithThreadPool()
        {
            int outMinWKThreadCount = 0;
            int outMinPORTThreadCount = 0;
            int outMaxWKThreadCount = 0;
            int outMaxPORTThreadCount = 0;

            ThreadPool.GetMinThreads(out outMinWKThreadCount, out outMinPORTThreadCount);
            ThreadPool.GetMaxThreads(out outMaxWKThreadCount, out outMaxPORTThreadCount);

            ThreadPool.QueueUserWorkItem(DoWorkForThreadPool);
            ThreadPool.QueueUserWorkItem(DoWorkForThreadPool);
            ThreadPool.QueueUserWorkItem(DoWorkForThreadPool);
            ThreadPool.QueueUserWorkItem(DoWorkForThreadPool);
            ThreadPool.QueueUserWorkItem(DoWorkForThreadPool);

        }

        static void ThreadStartingWithTPL()
        {
            Task<int> manageTask = Task.Factory.StartNew<int>(() => DoWorkForTPL());

            Console.WriteLine("TPL Result : " + manageTask.Result);

        }

        static void DoWorkForThreadPool(object obj)
        {
            int i = 0;

            while (i < 5)
            {
                Thread.Sleep(500);
                Console.WriteLine("Doing work in POOL THREAD # " + Thread.CurrentThread.ManagedThreadId);
                i++;
            }
        }

        static int DoWorkForTPL()
        {
            int i = 0;

            while (i < 10)
            {
                Thread.Sleep(500);
                Console.WriteLine("Doing work in TPL TP");
                i++;
            }

            return i;
        }

        static void SemaphoreExample()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(EnterTheDoorSemaphore).Start(i);
            }

        }

        static void EnterTheDoorSemaphore(object counter)
        {

            int count = (int)counter;
            Console.WriteLine("Requesting Entry: " + count);
            smObj.WaitOne();
            Console.WriteLine("Entered : " + count);
            Thread.Sleep(count * 2200);
            Console.WriteLine("Enxiting : " + count);
            smObj.Release();
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
                    Thread.Sleep(1000);
                    count++;
                }

                Console.WriteLine("Thread Completed");
            }

        }

        static void ThreadUsingAsyncBeginEndInvoke()
        {
            Func<int, string> doWork = DoSomething;

            IAsyncResult workResult = doWork.BeginInvoke(1000, null, null);

            Console.WriteLine("Junk Text");
            Console.WriteLine("Junk Text");
            Console.WriteLine("Junk Text");
            Console.WriteLine("Junk Text");
            Console.WriteLine("Junk Text");
            Console.WriteLine("Junk Text");

            Console.WriteLine(doWork.EndInvoke(workResult));
        }

        static void ThreadUsingAsync()
        {
            Func<int, string> doWork = DoSomething;

            IAsyncResult workResult = doWork.BeginInvoke(1000, InvokeCompleted, doWork);

            Console.WriteLine("Junk Text");
            Console.WriteLine("Junk Text");
            Console.WriteLine("Junk Text");
            Console.WriteLine("Junk Text");
            Console.WriteLine("Junk Text");
            Console.WriteLine("Junk Text");

        }

        private static void InvokeCompleted(IAsyncResult ar)
        {
            if (ar.IsCompleted)
            {
                Func<int, string> doWorkLocal = (Func<int, string>)ar.AsyncState;

                string result = doWorkLocal.EndInvoke(ar);

                Console.WriteLine("Async Thread Completed");
            }
        }

        static string DoSomething(int count)
        {
            Thread.Sleep(count);
            return "Async Thread Completed ";
        }
    }
}
