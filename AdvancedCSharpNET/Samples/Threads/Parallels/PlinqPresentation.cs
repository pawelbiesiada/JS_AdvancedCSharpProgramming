using System;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AdvancedCSharp.Samples.Parallels
{
    internal class PlinqPresentation
    {
        private static void Main()
        {
            var task = Task.Factory.StartNew(ProcessIntData);
            Console.ReadKey();
        }

        private static void ProcessIntData()
        {
            // Get a very large array of integers.
            int[] source = Enumerable.Range(1, 100_000_000).ToArray();
            var stopwatch = new Stopwatch();
            // Find the numbers where num % 3 == 0 is true, returned
            // in descending order.
            stopwatch.Start();
            int[] modThreeIsZero = source.Where(n => n % 3 == 0).OrderByDescending(n => n).ToArray();
            Console.WriteLine(string.Format("Found {0} numbers synchronously that match query in {1}ms!",
            modThreeIsZero.Count(), stopwatch.ElapsedMilliseconds));

            stopwatch.Restart();
            int[] modThreeIsZeroAsync = source
                .AsParallel()
                .WithDegreeOfParallelism(Environment.ProcessorCount - 2)
                .Where(n => n % 3 == 0)
                //.AsParallel() //why not at this place
                .OrderByDescending(n => n).ToArray();
            Console.WriteLine(string.Format("Found {0} numbers asynchronously that match query in {1}ms!",
            modThreeIsZeroAsync.Count(), stopwatch.ElapsedMilliseconds));
            stopwatch.Stop();
        }
    }
}
