using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 100;
            for (int i = 1; i <= 9999; i++)
            {
                if (counter == 110)
                {
                    break;
                }
                Console.Write(" i: " + i);
                Console.Write(" counter: " + counter);
                counter++;
            }
        }
    }
}
