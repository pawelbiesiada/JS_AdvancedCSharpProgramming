using System;
using System.Threading.Tasks;
using System.Threading;

namespace AdvancedCSharp.Samples.Parallels
{
    internal class ParallelForeach
    {
        private static void Main()
        {
            var arr = new int[20];
            for (int i = 0; i < 20; i++)
            {
                arr[i] = i;
            }

            var loopResults = Parallel.ForEach(arr, new ParallelOptions() {MaxDegreeOfParallelism = 8 }, PrintMessage);
            
            Console.ReadKey();
        }

        private static void PrintMessage(int number)
        {
            Console.WriteLine("Executed iteration {0}. ThreadId {1}", number, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
