using System;
using System.Diagnostics;

namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            int n = 4;
            object c = n;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("На упаковку потрачено милисекунд: " + ts.TotalMilliseconds.ToString());

            stopWatch.Reset();

            stopWatch.Start();            
            object o = 53;
            int p = (int)o;
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine("На распаковку потрачено милисекунд: " + ts.TotalMilliseconds.ToString());

            Console.ReadKey();
        }
    }
}
