using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog unnamed = new Dog(); // object
            Dog sharo = new Dog("Sharo", "Melez");

            unnamed.Breed = "German Shepherd";

            unnamed.Bark();
            sharo.Bark();

            sharo.Name = "Sharinko";
            sharo.Bark();

            Dog[] dogs = new Dog[2];
            dogs[0] = unnamed;
            dogs[1] = sharo;

            foreach (Dog kuche in dogs)
            {
                kuche.Bark();
            }

            Console.WriteLine(sharo.Breed);
        }
    }
}
