using System;

namespace _02Animals
{
    public class Kitten : Cat, ISoundProducible
    {
        public Kitten(string name, int age) : base(name, age, 'f')
        {

        }

        public void ProduceSound()
        {
            Console.WriteLine("Miiiious!");
        }
    }
}