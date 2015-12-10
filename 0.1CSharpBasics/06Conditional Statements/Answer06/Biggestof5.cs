using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer06
{
    class Biggestof5
    {
        static void Main(string[] args)
        {
            float a = float.Parse(Console.ReadLine());
            float b = float.Parse(Console.ReadLine());
            float c = float.Parse(Console.ReadLine());
            float d = float.Parse(Console.ReadLine());
            float e = float.Parse(Console.ReadLine());

            if (a > b && a > c && a > d && a > e)
            {
                Console.WriteLine(a);
            }
            if (b > a && b > c && b > d && b > e)
            {
                Console.WriteLine(b);
            }
            if (c > a && c > b && c > d && c > e)
            {
                Console.WriteLine(c);
            }
            if (d > a && d > b && d > c && d > e)
            {
                Console.WriteLine(d);
            }
            if (e > a && e > b && e > c && e > d)
            {
                Console.WriteLine(e);
            }
        }
    }
}
