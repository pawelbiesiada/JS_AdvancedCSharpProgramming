using System;
using System.Threading.Tasks;

namespace AdvancedCSharp.Samples.Tasks
{
    internal class BeginEndInvoke
    {
        private static void Main()
        {
            var action = new Action<string>(ActionMethod);
            var asyncResult = action.BeginInvoke("SomeText",(ar) => { Console.WriteLine("When here?"); }, null);

            Console.WriteLine("Started action asynchronously");
            Task.Delay(10).Wait();
            action.EndInvoke(asyncResult);
            Console.WriteLine("Completed action");
            Console.ReadKey();

            Console.WriteLine();
            var function = new Func<bool, string>(FunctionMethod);
            var asyncReturn = function.BeginInvoke(true, (ar) => { Console.WriteLine("Async object state parameter is {0}",ar.AsyncState); }, 5);
            Console.WriteLine("Started function asynchronously");
            Task.Delay(10).Wait();
            var result = function.EndInvoke(asyncReturn);
            Console.WriteLine("Completed function with result: {0}", result);
            Console.ReadKey();
        }

        private static void ActionMethod(string str)
        {
            Console.WriteLine("Processing ActionMethod with parameter {0}", str);
            Task.Delay(3000).Wait();
            Console.WriteLine("Processed ActionMethod completed");
        }

        private static string FunctionMethod(bool state)
        {
            Console.WriteLine("Processing FunctionMethod with parameter {0}", state);
            Task.Delay(3000).Wait();
            Console.WriteLine("Processed FunctionMethod completed");

            return "FunctionMethod result";
        }
    }
}
