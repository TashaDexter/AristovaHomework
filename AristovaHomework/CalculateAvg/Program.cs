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
        static void Main(string[] args)
        {

            var Generator = new Faker();
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            int[] array1 = new int[10000000];
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = Generator.Random.Number(0,100);
            }

            int[] array2 = new int[100000000];
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = Generator.Random.Number(0, 100);
            }
            
            Console.WriteLine(array1.Average().ToString());
            Console.WriteLine(array2.Average().ToString());
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine($"Time of calculating the average: {Convert.ToDecimal(ts.TotalMilliseconds / 100)} ms");

            stopWatch.Reset();
            stopWatch.Start();

            Parallel.Invoke(
                () =>
                {
                    int[] array3 = new int[10000000];
                    for (int i = 0; i < array3.Length; i++)
                    {
                        array3[i] = Generator.Random.Number(0, 100);
                    }
                    Console.WriteLine(array3.Average().ToString());
                },
                () =>
                {
                    int[] array4 = new int[100000000];
                    for (int i = 0; i < array4.Length; i++)
                    {
                        array4[i] = Generator.Random.Number(0, 100);
                    }
                    Console.WriteLine(array4.Average().ToString());
                });

            stopWatch.Stop();

            ts = stopWatch.Elapsed;
            Console.WriteLine($"Time of calculating the average (in parallel): {Convert.ToDecimal(ts.TotalMilliseconds / 100)} ms");

            Console.ReadKey();
        }

    }
}
