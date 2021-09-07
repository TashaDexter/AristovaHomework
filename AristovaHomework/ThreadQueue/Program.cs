using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancelToken = new CancellationTokenSource();
            CancellationToken token = cancelToken.Token;

            Executor executor = new Executor();
            for (int i = 1; i <=10; i++)
            {
                executor.Add(()=>
                {
                    Console.WriteLine($"Task {Task.CurrentId} is in process...");
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine($"Task {Task.CurrentId} has been interrupted by token");
                        return;
                    }
                    Thread.Sleep(1000);
                    Console.WriteLine($"Task {Task.CurrentId} is finished");
                });
            }

            executor.Add(PrintDate);

            Console.WriteLine($"Ammount of tasks: {executor.Ammount}");

            executor.Start(5);

            Console.Read();
        }

        public static void PrintDate()
        {
            Console.WriteLine($"{DateTime.Now}");
        }
    }
}
