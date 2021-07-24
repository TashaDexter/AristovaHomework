namespace PetsOOP
{
    public abstract class Pet
    {
        public string Name { get; set; }
        public abstract void MakeSound();

        public abstract void Move(int distance);
    }
}
