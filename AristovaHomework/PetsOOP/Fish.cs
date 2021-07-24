using System;

namespace PetsOOP
{
    class Fish : Pet
    {
        public Fish() {}

        public override void MakeSound()
        {
            Console.WriteLine("Fish don't speak, silly :)");
        }

        public override void Move(int distance)
        {
            Console.WriteLine($"Fish swam {distance} meters");
        }
    }
}
