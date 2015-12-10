using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer11
{
    class ExtractBit
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int p = 3;
            var bit = (int)(num >> p) & 1;

            Console.WriteLine(bit);
        }
    }
}
