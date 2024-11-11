using System;
using System.Threading;

namespace AdvancedCSharp.Samples.Threads
{
    internal class MonitorLocking
    {
        private static object _lockedObject = new object();
        private static object _notLockedObject = new object();

        private static void Main()
        {
            var t1 = new Thread(PrintNumbersMonitor);
            var t2 = new Thread(PrintNumbersWithLock);
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.ReadKey();
        }

        private static void PrintNumbersMonitor()
        {
            // object _lockedObject = new object(); - this is not valid, why???
            Monitor.Enter(_lockedObject);
            try
            {
                Console.WriteLine("ThreadId {0} is executing PrintNumbersMonitor()",
                Thread.CurrentThread.ManagedThreadId);
                Console.Write("Your numbers: ");
                for (int i = 0; i < 5; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(100 * (r.Next(5) + 1));
                    Console.Write("{0}, ", i);
                }
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(_lockedObject);                
            }
        }

        private static void PrintNumbersWithLock()
        {
            // object _lockedObject = new object(); - this is not valid, why???
            lock (_lockedObject)
            {
                Console.WriteLine("ThreadId {0} is executing PrintNumbersWithLock()",
                Thread.CurrentThread.ManagedThreadId);
                Console.Write("Your numbers: ");
                for (int i = 0; i < 5; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(100 * (r.Next(5) + 1));
                    Console.Write("{0}, ", i);
                }
                Console.WriteLine();
            }
        }
    }
}
