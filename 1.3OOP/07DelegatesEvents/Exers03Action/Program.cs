using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exers03Action
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> collection = new List<int> { 1, 2, 3, 4, 6, 11, 3 };

            collection.ForEach(Console.WriteLine);
        }
    }
}
