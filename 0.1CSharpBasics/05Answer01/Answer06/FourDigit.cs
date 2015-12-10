using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer06
{
    class FourDigit
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int n1 = n / 1000;
            int n2 = (n / 100) % 10;
            int n3 = (n / 10) % 10;
            int n4 = n % 10;

            Console.WriteLine("Sum is {0}", n1 + n2 + n3 + n4);
            Console.WriteLine("Reversed number is {0}{1}{2}{3}", n4,n3,n2,n1);
            Console.WriteLine("Last digit infront {0}{1}{2}{3}", n4, n1, n2, n3);
            Console.WriteLine("Reversed number is {0}{1}{2}{3}", n1, n3, n2, n4);

        }
    }
}
