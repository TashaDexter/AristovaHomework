using System;

namespace PetsOOP
{
    public class Dog : Pet
    {
        public Dog() {}

        public override void MakeSound()
        {
            Console.WriteLine("Dog says: \"Woof! Woof!\"");
        }

        public override void Move(int distance)
        {
            Console.WriteLine($"Dog ran {distance} meters");
        }
    }
}
