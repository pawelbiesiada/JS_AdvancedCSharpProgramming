using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdvancedCSharp.Samples.Parallels
{
    internal class ParallelInvoke
    {
        private static void Main()
        {
            var arr = new Action[20];
            for (int i = 0; i < 20; i++)
            {
                var j = i;
                arr[i] = new Action(() => PrintMessage(j));
            }

            Parallel.Invoke(arr);
            
            Console.ReadKey();
        }

        private static void PrintMessage(int number)
        {
            Console.WriteLine("Executed iteration {0}. ThreadId {1}", number, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
