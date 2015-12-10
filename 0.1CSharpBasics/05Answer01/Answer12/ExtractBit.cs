using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer12
{
    class ExtractBit
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            var bit = (int)(n >> p) & 1;
            Console.WriteLine(bit);
        }
    }
}
