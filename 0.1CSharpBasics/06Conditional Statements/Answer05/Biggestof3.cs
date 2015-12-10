using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer05
{
    class Biggestof3
    {
        static void Main(string[] args)
        {
            float a = float.Parse(Console.ReadLine());
            float b = float.Parse(Console.ReadLine());
            float c = float.Parse(Console.ReadLine());

            if (a > b)
            {
                if (a > c)
                {
                    Console.WriteLine(a);
                }
            }
            if (b > a)
            {
                if (b > c)
                {
                    Console.WriteLine(b);
                }
            }
            if (c > a)
            {
                if (c > b)
                {
                    Console.WriteLine(c);
                }
            }
        }
    }
}
