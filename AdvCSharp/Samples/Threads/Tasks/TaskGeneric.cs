using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdvancedCSharp.Samples.Tasks
{
    internal class TaskGeneric
    {
        private static void Main()
        {
            //Non-generic Task - Action
            var task = Task.Factory.StartNew(() => { Task.Delay(1000).Wait(); return string.Format("Hello!!!"); });
            task.Wait();
            Console.WriteLine(task.Result);


            //Generic Task - Action<object>
            string name = "Pawel";
            var task2 = Task.Factory.StartNew((str) =>
                        {
                            Task.Delay(5000).Wait(); Console.WriteLine("Hello {0}!!!", str);
                        }, name);
            task2.Wait();

            //Generic Task - Func<object, string>
            var task3 = new Task<string>(SayHello, name);
            task3.Start();
            string value = task3.Result;
            Console.WriteLine("Ready & Waiting.");
            Console.ReadKey();
        }

        private static string SayHello(object name)
        {
            return $"Say Hello {name}";
        }
    }
}
