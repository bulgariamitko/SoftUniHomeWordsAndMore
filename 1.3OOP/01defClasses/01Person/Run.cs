using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Person
{
    class Run
    {
        static void Main(string[] args)
        {
            Person gosho = new Person("Gosho", 55, "gosho@gmail.com");
            Person pesho = new Person("Pesho", 88);
            Person undying = new Person("Ninja", 24);
            Console.WriteLine(gosho.ToString());
            Console.WriteLine(pesho.ToString());
            Console.WriteLine(undying.ToString());
        }
    }
}
