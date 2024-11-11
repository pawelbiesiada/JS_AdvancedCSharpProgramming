using System;
using System.Threading;

namespace AdvancedCSharp.Samples.Threads
{
    internal class ThreadException
    {
        private static void Main()
        {
            
            var t = new Thread(ThreadMethod);

            try
            {
                t.Start();
                t.Join();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception type {0}", ex.GetType());
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.ReadKey();
        }

        private static void ThreadMethod()
        {
            var val = 0;
            double result = 5 / val;
        }
    }
}
