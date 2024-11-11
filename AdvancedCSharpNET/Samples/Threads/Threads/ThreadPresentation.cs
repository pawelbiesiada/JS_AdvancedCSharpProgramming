using System;
using System.Threading;

namespace AdvancedCSharp.Samples.Threads
{
    internal class ThreadPresentation
    {
        private static void Main()
        {
            Console.WriteLine("Main threadId {0} is in status {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.ThreadState);
            var thread = new Thread(new ThreadStart(LongRunningMethod));
            Console.WriteLine("ThreadId {0} is in status {1}", thread.ManagedThreadId, thread.ThreadState);
            thread.Start();          
            while (thread.IsAlive)
            {
                Console.WriteLine("ThreadId {0} in while is in status {1}", thread.ManagedThreadId, thread.ThreadState);
                Thread.Sleep(500);
            }
            Console.WriteLine("ThreadId {0} is in status {1}", thread.ManagedThreadId, thread.ThreadState);
            Console.ReadKey();
        }

        private static void LongRunningMethod()
        {
            double result;
            for (int i = 0; i < 100000000; i++)
            {
                result = Math.Acos(Math.Asin(i));
            }
            Console.WriteLine("LongRunningMethod completed execution on threadId {0}.", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
