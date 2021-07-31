using System;

namespace Equivalence
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person() { PassportID = 124, FirstName = "Olivia", LastName="Smith", DateOfBirth = Convert.ToDateTime("25.04.98"), PlaceOfBirth = "New York" };
            Person person2 = new Person() { PassportID = 124, FirstName = "Olivia", LastName = "Smith", DateOfBirth = Convert.ToDateTime("25.04.98"), PlaceOfBirth = "New York" };
            
            Console.WriteLine("Compare person1 and person2:");
            Console.WriteLine($"Equals: {person1.Equals(person2)}");
            Console.WriteLine($"GetHashCode: person1={person1.GetHashCode()}, person2={person2.GetHashCode()}");
            Console.WriteLine($"Comparison with == :" + (person1 == person2));

            Console.WriteLine("\nLet's change the property for the object 'person2'\n");
            person2.PlaceOfBirth = "Tiraspol";

            Console.WriteLine("Compare person1 and person2:");
            Console.WriteLine($"Equals: {person1.Equals(person2)}");
            Console.WriteLine($"GetHashCode: person1={person1.GetHashCode()}, person2={person2.GetHashCode()}");
            Console.WriteLine($"Comparison with == :" + (person1 == person2));

            Console.ReadKey();
        }
    }
}
