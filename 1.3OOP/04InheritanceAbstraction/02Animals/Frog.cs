using System;

namespace _02Animals
{
    public class Frog : Animal, ISoundProducible
    {
        public Frog(string name, int age, char gender) : base(name, age, gender)
        {

        }

        public void ProduceSound()
        {
            Console.WriteLine("Froogin frooogin froooing!");
        }
    }
}