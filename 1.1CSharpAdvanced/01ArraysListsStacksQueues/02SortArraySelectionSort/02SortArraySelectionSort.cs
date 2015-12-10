using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02SortArraySelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> array = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            Console.WriteLine("The Array Before Selection Sort is: ");
            Console.WriteLine(string.Join(", ", array));
            int tmp, min_key;

            for (int j = 0; j < array.Count - 1; j++)
            {
                min_key = j;

                for (int k = j + 1; k < array.Count; k++)
                {
                    if (array[k] < array[min_key])
                    {
                        min_key = k;
                    }
                }

                tmp = array[min_key];
                array[min_key] = array[j];
                array[j] = tmp;
            }

            Console.WriteLine("The Array After Selection Sort is: ");
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
