using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exers01Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> collection = new List<int> { 1, 2, 3, 4, 6, 11, 6 };

            Console.WriteLine(collection.FirstOrDefault(x => x > 7));
            Console.WriteLine(collection.FirstOrDefault(x => x < 0));
        }
    }
}
