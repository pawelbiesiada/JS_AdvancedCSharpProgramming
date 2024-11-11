using System;
using System.Threading;

namespace AdvancedCSharp.Samples.Threads
{
    internal class Volatile
    {
        //private bool flag = true;
        private volatile bool flag = true;
        private static void Main(string[] args)
        {
            var volatileClass = new Volatile();
            var thread = new Thread(() => { volatileClass.flag = false; });
            thread.Start();

            while (volatileClass.flag)
            {
                Console.WriteLine("Executing");
                Thread.Sleep(100);
            }

            //possible optimization used by compiler (Release)
            //if(volatileClass.flag)
            //{
            //    while(true)
            //    {
            //        Console.WriteLine("Executing");
            //        Thread.Sleep(100);
            //    }
            //}
        }
    }
}
