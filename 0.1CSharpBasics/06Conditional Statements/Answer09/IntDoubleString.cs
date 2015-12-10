using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer09
{
    class IntDoubleString
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, choose a type:");
            Console.WriteLine("1 --> int");
            Console.WriteLine("2 --> double");
            Console.WriteLine("3 --> string");

            int n = int.Parse(Console.ReadLine());

            if (n == 1 || n == 2)
            {
                Console.WriteLine("Please enter a int:");
                double n2 = double.Parse(Console.ReadLine());

                Console.WriteLine(n2 + 1);
            }
            else
            {
                Console.WriteLine("Please enter a string:");
                string n3 = Console.ReadLine();

                Console.WriteLine("{0}*", n3);
            }
        }
    }
}
