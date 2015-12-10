using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer04
{
    class Rectangles
    {
        static void Main(string[] args)
        {
            float n1 = float.Parse(Console.ReadLine());
            float n2 = float.Parse(Console.ReadLine());
            
            Console.WriteLine("Parameter is {0}", (n1 * 2) + (n2 * 2));
            Console.WriteLine("Area is {0}", n1 * n2);
        }
    }
}
