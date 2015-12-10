using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer02
{
    class PrimeChecker
    {
        public static bool IsPrime(long n) {
             int i;
            for (i = 2; i <= n - 1; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            if (i == n)
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Console.WriteLine(IsPrime(n));
        }
    }
}
