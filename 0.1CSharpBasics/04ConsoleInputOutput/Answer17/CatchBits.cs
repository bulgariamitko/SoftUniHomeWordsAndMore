using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer17
{
    class CatchBits
    {
        static void Main(string[] args)
        {
            ulong bits = ulong.Parse(Console.ReadLine());
            int sieves = int.Parse(Console.ReadLine());

            for (int i = 0; i < sieves; ++i)
            {
                ulong sieve = ulong.Parse(Console.ReadLine());
                bits = bits & (~sieve);
            }

            // Now count the bits
            ulong bitsCount = 0;
            while (bits > 0)
            {
                bitsCount += (bits & 1);
                bits = bits >> 1;
            }

            Console.WriteLine(bitsCount);
        }
    }
}
