using System;

namespace PetsOOP
{
    public class Cat : Pet
    {
        public Cat() {}

        public override void MakeSound()
        {
            Console.WriteLine("Cat says: \"Meow! Meow!\"");
        }

        public override void Move(int distance)
        {
            Console.WriteLine($"Cat ran {distance} meters");
        }
    }
}
