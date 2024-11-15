using System;
using System.Threading;

namespace AdvancedCSharp.Samples.Threads
{
    internal class CriticalSectionUnsafe
    {
        private static int _commonCounter;
        private static int _thread1Counter;
        private static int _thread2Counter;

        private static void Main()
        {
            _commonCounter = 0;
            _thread1Counter = 0;
            _thread2Counter = 0;

            var t1 = new Thread(Increment1);
            var t2= new Thread(Increment2);
            t1.Start();
            t2.Start();

            //
            //
            //

            t1.Join();
            t2.Join();

            Console.WriteLine("Thread1 executed the loop {0} times", _thread1Counter.ToString("N0"));
            Console.WriteLine("Thread2 executed the loop {0} times", _thread2Counter.ToString("N0"));
            Console.WriteLine("Both Thread1 & Thread2 executed the loop {0} times", (_thread1Counter + _thread2Counter).ToString("N0"));
            Console.WriteLine("CommonCounter was increased {0} times", _commonCounter.ToString("N0"));
            Console.ReadKey();
        }

        private static object locker = new object();

        private static void Increment1()
        {
            while (_commonCounter < 10_000_000)
            {
                lock (locker)
                {
                    if (_commonCounter >= 10_000_000)
                        return;

                    _commonCounter++;
                }
                _thread1Counter++;
            }
        }
        private static void Increment2()
        {
            while (_commonCounter < 10_000_000)
            {
                lock (locker)
                {
                    if (_commonCounter >= 10_000_000)
                        return;

                    _commonCounter++;
                }
                _thread2Counter++;
            }
        }
    }
}
