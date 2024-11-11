using System;
using System.Threading.Tasks;

namespace AdvancedCSharp.Samples.Tasks
{
    internal class TaskPresentation
    {
        private static void Main()
        {
            var task = new Task(LongRunningMethod);
            Console.WriteLine("Task {0} status is {1}", task.Id, task.Status);
            task.Start();
            Console.WriteLine("Task {0} status is {1}", task.Id, task.Status);
            Task.Delay(1).Wait();
            Console.WriteLine("Task {0} status is {1}", task.Id, task.Status);
            task.Wait();
            Console.WriteLine("Task {0} status is {1}", task.Id, task.Status);
            
            Console.ReadKey();
        }

        private static void LongRunningMethod()
        {
            double result;
            for (int i = 0; i < 10000000; i++)
            {
                result = Math.Acos(Math.Asin(i));
            }
        }
    }
}
