using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06BitArray
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray num = new BitArray(99000);
            num[3] = 1;
            num[89000] = 1;
            Console.WriteLine(num[9900]);

            BitArray someBitArray = new BitArray(1, 1, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1);
            Console.WriteLine(someBitArray[80]);
            Console.WriteLine(someBitArray);

            someBitArray[80] = 0;

            Console.WriteLine(someBitArray[80]);
            Console.WriteLine(someBitArray);
        }
    }
}
