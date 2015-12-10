using System;

namespace _02Animals
{
    public class Dog : Animal, ISoundProducible
    {
        public Dog(string name, int age, char gender) : base(name, age, gender)
        {

        }

        public void ProduceSound()
        {
            Console.WriteLine("Bark! Bark! Bark!");
        }
    }
}