using System;
using System.Threading;

namespace AdvancedCSharp.Samples.Threads
{
    internal class InterlockedOperations
    {
        private static int _counter;
        private static int _counterUnsafe;

        private static void Main()
        {
            _counter = 0;
            _counterUnsafe = 0;
            var thread = new Thread(new ThreadStart(ThreadMethod));
            thread.Start();

            for (int i = 0; i < 200000; i++)
            {
                Interlocked.Add(ref _counter, -9); //_counter -= 9
                Interlocked.Increment(ref _counter); //_counter++
                _counterUnsafe++;
            }
            thread.Join();
            // Counter should be 0
            Console.WriteLine("Counter = {0}\tCounterUnsafe = {1}", _counter, _counterUnsafe);
        }

        private static void ThreadMethod()
        {
            for (int i = 0; i < 200000; i++)
            {
                Interlocked.Add(ref _counter, -9);
                Interlocked.Decrement(ref _counter);
                _counterUnsafe--;
            }
        }
    }
}
