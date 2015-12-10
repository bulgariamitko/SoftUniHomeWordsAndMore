using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer21
{
    class BitShifting
    {
        static void Main(string[] args)
        {
            ulong bitsSieve = ulong.Parse(Console.ReadLine());
            int numSieves = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 0; i < numSieves; i++)
            {
                ulong number = ulong.Parse(Console.ReadLine());
                for (int j = 0; j < 64; j++)
                {
                    ulong nRightP = bitsSieve >> j;
                    ulong bitSieve = nRightP & 1;
                    nRightP = number >> j;
                    ulong bitNumber = nRightP & 1;
                    bitSieve = bitSieve ^ bitNumber;
                    if (bitSieve == 1 && bitNumber == 0)
                    {
                        ulong mask = (ulong)1 << j;
                        bitsSieve = bitsSieve | mask;
                    }
                    else
                    {
                        ulong mask = ~((ulong)1 << j);
                        bitsSieve = bitsSieve & mask;
                    }
                }
            }
            for (int j = 0; j < 64; j++)
            {
                ulong nRightP = bitsSieve >> j;
                ulong bitSieve = nRightP & 1;
                if (bitSieve == 1)
                {
                    count++;
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine(count);
        }
    }
}
