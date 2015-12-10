using System;

namespace _02Animals
{
    public class Cat : Animal, ISoundProducible
    {
        public Cat(string name, int age, char gender) : base(name, age, gender)
        {

        }

        public void ProduceSound()
        {
            Console.WriteLine("Moau!");
        }
    }
}