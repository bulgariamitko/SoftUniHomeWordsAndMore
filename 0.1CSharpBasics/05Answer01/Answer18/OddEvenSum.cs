using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer18
{
    class OddEvenSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 0; i < n*2; i++)
            {
                if (i % 2 == 0)
                {
                    int even = int.Parse(Console.ReadLine());
                    sumEven = sumEven + even;
                }
                else
                {
                    int odd = int.Parse(Console.ReadLine());
                    sumOdd = sumOdd + odd;
                }
            }
            if (sumEven == sumOdd)
            {
                Console.WriteLine("Yes, sum={0}", sumOdd);
            }
            else
            {
                Console.WriteLine("No, diff={0}", (int)Math.Abs(sumEven - sumOdd));
            }
        }
    }
}
