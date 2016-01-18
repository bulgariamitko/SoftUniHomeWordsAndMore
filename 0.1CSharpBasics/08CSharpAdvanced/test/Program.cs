using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main()
        {
            List<int> listInts =
                Console.ReadLine()
                    .Split(new[] {' ', ',', '|'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(number => int.Parse(number))
                    .ToList();

            foreach (int i in listInts)
            {
                Console.WriteLine(i);
            }
        }
    }
}
