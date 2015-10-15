using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();
            char[] arr = words.ToCharArray();
            Array.Sort(arr);
            int counter = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                counter++;
                if (arr[i] != arr[i + 1])
                {
                    Console.WriteLine("{0}: {1} time/s", arr[i], counter);
                    counter = 0;
                }

                if (i == arr.Length - 2)
                {
                    Console.WriteLine("{0}: {1} time/s", arr[i + 1], ++counter);
                }
            }
        }
    }
}
