using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo123
{
    class Looping
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            string leftRight = new string('/', 1);
            string rightLeft = new string('\\', 1);
            string stars = new string('*', input - 2);
            string dots = new string('.', 1);

            int startStarts = input - 2;
            int counter1 = 1;
            int counter2 = 2;
            Console.WriteLine("\\{0}/", stars);
            for (int i = 0; i < input / 2 - 2; i++)
            {
                Console.WriteLine("{0}\\{1}/{0}", new string('.', counter1), new string('*', (startStarts - counter2)));
                counter1++;
                counter2 = counter2 + 2;
            }
            Console.WriteLine("{0}\\/{0}", new string('.', counter1));

            if (input >= 12)
            {
                for (int i2 = 0; i2 < input / 2 - 2; i2++)
                {
                    Console.WriteLine("{0}||{0}", new string('.', counter1));
                }
                Console.WriteLine("{0}", new string('-', input));
                Console.WriteLine("{0}", new string('-', input));
            }
            else
            {
                for (int i2 = 0; i2 < input / 2 - 1; i2++)
                {
                    Console.WriteLine("{0}||{0}", new string('.', counter1));
                }
                Console.WriteLine("{0}", new string('-', input));
            }
            
        }
    }
}
