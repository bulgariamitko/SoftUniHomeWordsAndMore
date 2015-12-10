using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer16
{
    class BitExchangeAdvanced
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a number: ");
            var n = long.Parse(Console.ReadLine());

            Console.Write("Please enter \"p\": ");
            var p = sbyte.Parse(Console.ReadLine());

            Console.Write("Please enter \"q\": ");
            var q = sbyte.Parse(Console.ReadLine());

            Console.Write("Please enter \"k\": ");
            var k = sbyte.Parse(Console.ReadLine());

            var mask = 0;

            if (Math.Max(p, q) + k > 32)
            {
                Console.WriteLine("Out of range");
            }
            else if (Math.Min(p, q) + k > Math.Max(p, q))
            {
                Console.WriteLine("Overlapping");
            }
            else
            {
                while (k > 0)
                {
                    k--;
                    mask += (int)Math.Pow(2, k);
                }

                long firstBits = mask << p;
                long secondBits = mask << q;
                long checkFirst = n & firstBits;
                long checkSecond = n & secondBits;
                long change = (n & ~firstBits) & ~secondBits;
                long changeFirstBits = (checkFirst >> p) << q;
                long changeSecondBits = (checkSecond >> q) << p;
                long result = (change | changeFirstBits) | changeSecondBits;

                Console.WriteLine("Binary representation of n: {0}", Convert.ToString(n, 2).PadLeft(32, '0'));
                Console.WriteLine("Binary result:              {0}", Convert.ToString(result, 2).PadLeft(32, '0'));
                Console.WriteLine("Result:                     {0}", result);

                Console.WriteLine("\n\n");
            }
        }
    }
}
