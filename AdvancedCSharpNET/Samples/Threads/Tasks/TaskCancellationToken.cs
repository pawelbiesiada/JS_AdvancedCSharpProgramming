using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdvancedCSharp.Samples.Threads.Tasks
{
    class TaskCancellationToken
    {
        private static void Main()
        {
            var cts = new CancellationTokenSource();

            var task = new Task((token) => LongRunningProcess((CancellationToken)token)
            , cts.Token);
            task.Start();

            try
            {
                Task.Delay(3000).Wait();
                cts.Cancel(true);
                task.Wait();
                Console.WriteLine("Task completed");
                if (task.Exception != null)
                    throw task.Exception;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Main thread.");
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }

        private static void LongRunningProcess(CancellationToken ct)
        {
            for (int i = 0; i < 10; i++)
            {
                if (ct.IsCancellationRequested)
                {
                    ///
                    ///


                    ct.ThrowIfCancellationRequested(); //throws OperationCanceledException
                }
                Thread.Sleep(1000);
            }
        }
        private static void LongRunningProcessDelay(CancellationToken ct)
        {
            Task.Delay(10000, ct).Wait();
            try
            {
                Task.Delay(10000, ct).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Async thread");
                Console.WriteLine(ex);
                //throw;    if not handled here, the exception will be propagated to main thread
            }
        }
    }
}
