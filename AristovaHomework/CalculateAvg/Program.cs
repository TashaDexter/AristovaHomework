using System;
using System.Diagnostics;
using System.Linq;
using Bogus;
using System.Threading;
using System.Threading.Tasks;

namespace CalculateAvg
{
    class Program
    {
        public static double sum=0;

        public static double avg;

        public static int[] array = new int[100000000];

        static object locker = new object();
        static void Main(string[] args)
        {
            
            var Generator = new Faker();
            for (int i = 0; i < 100000000; i++)
            {
                array[i] = Generator.Random.Number(0, 100);
            }

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            for (int i = 0; i <array.Length; i++)
            {
                Sum(i);
            }

            Console.WriteLine($"Sum:{sum}");
            avg = sum / 100000000;
            Console.WriteLine($"Avg:{avg}");
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine($"Time of calculating the average: {Convert.ToDecimal(ts.TotalMilliseconds / 100)} ms");

            stopWatch.Reset();

            sum = 0;
            stopWatch.Start();
            
            Parallel.For(0, 12500000, Sum);
            Parallel.For(12500000, 25000000, Sum);
            Parallel.For(25000000, 27500000, Sum);
            Parallel.For(27500000, 40000000, Sum);
            Parallel.For(40000000, 52500000, Sum);
            Parallel.For(52500000, 65000000, Sum);
            Parallel.For(65000000, 77500000, Sum);
            Parallel.For(77500000, 90000000, Sum);
            Parallel.For(90000000, 100000000, Sum);
            Console.WriteLine($"Sum:{sum}");

            avg = sum / 100000000;

            Console.WriteLine($"Avg:{avg}");
            

            stopWatch.Stop();

            ts = stopWatch.Elapsed;
            Console.WriteLine($"Time of calculating the average (with parallel for): {Convert.ToDecimal(ts.TotalMilliseconds / 100)} ms");

            Console.ReadKey();
        }

        public static void Sum(int number)
        {
            lock (locker)
                sum += array[number];
        }

    }
}
