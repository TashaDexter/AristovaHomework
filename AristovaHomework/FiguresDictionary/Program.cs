using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FiguresDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many figures do you want to add?");
            int number = Convert.ToInt32(Console.ReadLine());
            
            //список фигур
            List <Figure> figureList= new List<Figure>();
            //справочник хранит фигуры и количество сторон
            Dictionary<Figure, int> figureDictionary = new Dictionary<Figure, int>();

            Random rnd = new Random();

            int index = 0;
            while(index<number)
            { 
                var figure = new Figure() { SideLength = rnd.Next(1, 100), SideNumber = rnd.Next(1, 100) };
                if (!figureList.Contains(figure))
                {
                    figureList.Add(figure);
                    figureDictionary.Add(figure, figure.SideNumber);
                    index++;
                }
            }

            Stopwatch stopWatch = new Stopwatch();

            Figure testFigure = new Figure() { SideNumber = 12, SideLength = 50 };

            Console.WriteLine("------figureList------\n");
            foreach (var f in figureList)
            {
                Console.WriteLine($"SideNumber={f.SideNumber}, SideLength={f.SideLength}");
            }

            Console.WriteLine("------figureDictionary------\n");
            foreach (var f in figureDictionary)
            {
                Console.WriteLine($"SideNumber={f.Key.SideNumber}, SideLength={f.Key.SideLength}");
            }

            stopWatch.Start();
            bool hasFigure=figureList.Contains(testFigure);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine($"FigureList contains testFigure: {hasFigure}, search time={ts.TotalMilliseconds}ms");

            stopWatch.Reset();

            stopWatch.Start();
            hasFigure = figureDictionary.ContainsKey(testFigure);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine($"FigureDictionary contains testFigure: {hasFigure}, search time={ts.TotalMilliseconds}ms");

            Console.ReadKey();
        }
    }
}
