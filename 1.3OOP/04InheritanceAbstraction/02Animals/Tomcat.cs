using System;

namespace _02Animals
{
    public class Tomcat : Cat, ISoundProducible
    {
        public Tomcat(string name, int age) : base(name, age, 'm')
        {

        }

        public void ProduceSound()
        {
            Console.WriteLine("tommycaaatty!");
        }
    }
}