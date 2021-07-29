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
            for (int i = 0; i < 100; i++)
            {
                int n = 4;
                object c = n;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("На упаковку потрачено милисекунд: " + Convert.ToDecimal(ts.TotalMilliseconds/100).ToString());

            stopWatch.Reset();

            stopWatch.Start();
            for (int i = 0; i < 100; i++)
            {
                object o = 53;
                int p = (int)o;
            }
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine("На распаковку потрачено милисекунд: " + Convert.ToDecimal(ts.TotalMilliseconds/100).ToString());

            Console.ReadKey();
        }
    }
}
