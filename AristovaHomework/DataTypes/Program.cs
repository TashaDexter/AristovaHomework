using System;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Вычисление площади произвольного правильного многоугольника\n");

            Console.Write("Ввведите количество граней: n=");
            int n=Int32.Parse(Console.ReadLine());
            Console.Write("Введите длину грани: a=");
            int a = Int32.Parse(Console.ReadLine());

            FigureClass figureClass = new FigureClass (){ SidesNumber = n, SideLength = a };
            Console.WriteLine($"\nКласс--------------------------------\n");
            Console.WriteLine($"Первый метод\nПлощадь фигуры равна:{SquareClass(figureClass).Square}");
            Console.WriteLine($"Свойство Square:{figureClass.Square}");
            Console.WriteLine($"\nВторой метод\nПлощадь фигуры равна:{ChangeSquareClass(figureClass).Square}");
            Console.WriteLine($"Свойство Square:{figureClass.Square}");

            FigureStruct figureStruct = new FigureStruct() { SidesNumber = n, SideLength = a };
            Console.WriteLine($"\nСтруктура----------------------------\n");
            Console.WriteLine($"Первый метод\nПлощадь фигуры равна:{SquareStruct(figureStruct).Square}");
            Console.WriteLine($"Свойство Square:{figureStruct.Square}");
            Console.WriteLine($"\nВторой метод\nПлощадь фигуры равна:{ChangeSquareStruct(figureStruct).Square}");
            Console.WriteLine($"Свойство Square:{figureStruct.Square}");

            Console.ReadLine();
        }

        public static FigureClass SquareClass(FigureClass figure)
        {
            double Square = (figure.SidesNumber *Math.Pow(figure.SideLength,2))/ (4 * Math.Tan((Math.PI/figure.SidesNumber)));
            figure = new FigureClass() { SideLength = figure.SideLength, SidesNumber = figure.SidesNumber, Square = Square };
            return figure;
        }

        public static FigureClass ChangeSquareClass(FigureClass figure)
        {
            double Square = (figure.SidesNumber * Math.Pow(figure.SideLength, 2)) / (4 * Math.Tan((Math.PI / figure.SidesNumber)));
            figure.Square=Square;
            return figure;
        }

        public static FigureStruct SquareStruct(FigureStruct figure)
        {
            double Square = (figure.SidesNumber * Math.Pow(figure.SideLength, 2)) / (4 * Math.Tan((Math.PI / figure.SidesNumber)));
            figure = new FigureStruct() { SideLength = figure.SideLength, SidesNumber = figure.SidesNumber, Square = Square };
            return figure;
        }

        public static FigureStruct ChangeSquareStruct(FigureStruct figure)
        {
            double Square = (figure.SidesNumber * Math.Pow(figure.SideLength, 2)) / (4 * Math.Tan((Math.PI / figure.SidesNumber)));
            figure.Square = Square;
            return figure;
        }
    }
}
