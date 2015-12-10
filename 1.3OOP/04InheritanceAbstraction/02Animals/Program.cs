using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>()
            {
                new Dog("Shapko", 5, 'm'),
               new Frog("Hurbit", 1, 'm'),
               new Kitten("Kitty", 1),
               new Tomcat("Tomcaten", 2),
               new Dog("Lester", 4, 'm'),
                new Frog("Hurbit2", 4, 'm'),
               new Kitten("Kitty2", 6),
               new Tomcat("Tomcaten2", 3),
               new Dog("Lester2", 1, 'm')
            };

            foreach (var animal in animals.GroupBy(x => x.GetType().Name))
            {
                double aveAge = animal.Select(x => x.Age).Average();

                Console.WriteLine("Animal: {0}, Average age is {1:F2}", animal.Key, aveAge);
            }
        }
    }
}
