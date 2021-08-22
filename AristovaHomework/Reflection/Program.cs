using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //подключаем сборку используя относительный путь
            Assembly asm = Assembly.LoadFrom(Directory.GetCurrentDirectory() + "\\..\\..\\..\\Figure\\Figure\\bin\\Debug\\Figure.exe");
            Console.WriteLine($"Assembly fullname: {asm.FullName}");

            Type myType = asm.GetType("Figure.Figure", false, true);

            Console.WriteLine("\nCreating an instance of the Figure class: ");
            //создать экзмепляр класса myType=Figure.Box
            object obj = Activator.CreateInstance(myType);

            var properties = myType.GetProperties();
            foreach (var prop in properties)
            {
                Console.Write($"SetValue: {prop.Name} = ");
                prop.SetValue(obj, Convert.ToInt32(Console.ReadLine()));
            }

            Console.WriteLine("\nObj properties:");
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Name} = {property.GetValue(obj)}");
            }

            Console.WriteLine("\nFigure private properties:");
            var privateProperties = myType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var privateProp in privateProperties)
            {
                Console.WriteLine($"{privateProp.Name} = {privateProp.GetValue(obj)}");
            }

            //вызвать метод CalculateSquare            
            MethodInfo method = myType.GetMethod("CalculateSquare");
            Console.WriteLine("\nFigure.CalculateSquare:");
            Console.Write("SideCount = ");
            int sideCount = Convert.ToInt32(Console.ReadLine());
            Console.Write("SideLength = ");
            int sideLength = Convert.ToInt32(Console.ReadLine());

            // вызываем метод, передаем ему значения для параметров и получаем результат
            method.Invoke(obj, new object[] { sideCount, sideLength });

            Console.Read();
        }
    }
}
