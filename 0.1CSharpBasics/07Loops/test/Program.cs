using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(Recursion(number));
        }

        public static int Recursion(int num)
        {
            if (num < num + 1)
            {
                return 0;
            }
            return Recursion(num);
        }
    }
}
