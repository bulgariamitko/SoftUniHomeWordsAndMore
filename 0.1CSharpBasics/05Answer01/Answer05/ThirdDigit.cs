using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer05
{
    class ThirdDigit
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int n2 = n / 100;
            if (n2 % 10 == 7)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
