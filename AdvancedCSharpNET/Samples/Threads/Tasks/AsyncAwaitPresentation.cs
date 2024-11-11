using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdvancedCSharp.Samples.Tasks
{
    internal class AsyncAwaitPresentation
    {
        private static void Main()
        {
            var asyncAwait = new AsyncAwaitPresentation();
            asyncAwait.Run();
        }
        public void Run()
        {
            var value = "Pawel";
            var result = GetNameAsync(value);
            Console.WriteLine("More processing is pending.");
            result.Wait();
            var textToDisplay = result.Result;
            Console.WriteLine(textToDisplay);
            Console.WriteLine("Awaited for asynchronous call to complete.");
            Console.ReadKey();
        }

        private async Task<string> GetNameAsync(string myName)
        {
            //await Task.Delay(1000); //non-blocking - releases main thread to process
            //Task.Delay(1000).Wait(); //blocking, starts new thread and wait until it's done
            Thread.Sleep(1000); // blocking, on same thread
            string result = "";
            try
            {
                var t = SayHiByNameAsync(myName);
                Task.Delay(2000).Wait();
                result = await t; //Check Main Tread and Worker Thread
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //throw;
            }
            Console.WriteLine("Doing some more work in async method.");
            return result;
        }

        private Task<string> SayHiByNameAsync(string name)
        {
            var task = Task.Factory.StartNew((str) =>
            {
                Console.WriteLine("\tStarted new thread.");
                //throw new Exception();
                Task.Delay(10000).Wait();
                return string.Format("Hi {0}!!!", str);
            }, name);
            return task;
        }
    }
}
