using System;
using System.Threading.Tasks;

namespace AdvancedCSharp.Samples.Tasks
{
    internal class TaskFactoryPresentation
    {
        private static void Main()
        {
            var task = Task.Factory.StartNew(new Action(() => { Console.WriteLine("Run async task"); }));
            task.Wait();

            var function = new Func<string, string>((name) => { Task.Delay(3000).Wait(); return string.Format("Hi {0}!", name); });
            var asyncResult = function.BeginInvoke("Pawel", null, "obj");
            Task.Delay(1000).Wait();
            var taskFromAsync = Task.Factory.FromAsync<string>(asyncResult, function.EndInvoke );
            taskFromAsync.Wait();
            Console.WriteLine(taskFromAsync.Result);

            Console.ReadKey();
        }
    }
}
