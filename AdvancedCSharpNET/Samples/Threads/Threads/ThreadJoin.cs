using System;
using System.Threading;

namespace AdvancedCSharp.Samples.Threads
{
    internal class ThreadJoin
    {
        private static void Main()
        {
            var thread1 = new Thread(new ThreadStart(LongRunningMethod));
            var thread2 = new Thread(new ThreadStart(LongRunningMethod));

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Both threads should complete by now.");
            Console.ReadKey();
        }

        private static void LongRunningMethod()
        {
            double result;
            for (int i = 0; i < 5_000_000; i++)
            {
                result = Math.Acos(Math.Asin(i));
            }
            Console.WriteLine("LongRunningMethod completed execution on threadId {0}.", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
