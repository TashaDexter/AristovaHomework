using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadQueue
{
    public class Executor : IJobExecutor
    {
        private List<Task> tasks = new List<Task>();
        private Semaphore semaphore;
        public int Ammount
        {
            get
            {
                return tasks.Count;  
            }
        }

        public void Start(int maxConcurrent)
        {
            semaphore = new Semaphore(maxConcurrent, maxConcurrent);

            while ( Ammount > 0)
            {
                semaphore.WaitOne();

                tasks.First().Start();

                Console.WriteLine("Semaphore works");
                Thread.Sleep(3000);

                semaphore.Release();

                tasks.RemoveAt(0);
            }
        }

        public void Add(Action action)
        {
            tasks.Add(new Task(action));
        }

        public void Clear()
        {
            tasks.Clear();
        }
    }
}
