using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06SubsetSums
{
    class Program
    {
        static List<List<int>> subsets = new List<List<int>>();
        static int[] numbers;
        static int N;
        static bool solution = false;

        static void Main()
        {
            N = int.Parse(Console.ReadLine());
            numbers = Console.ReadLine().Split(' ').Select(int.Parse).Distinct().ToArray();
            Array.Sort(numbers);
            List<int> subset = new List<int>();
            MakeSubset(0, subset);
            var sorted = subsets.OrderBy(x => x.Count);
            foreach (var item in sorted)
            {
                Console.WriteLine(" {0} = {1}", string.Join(" + ", item), N);
            }
            if (!solution)// if no sum matches N
                Console.WriteLine("No matching subsets.");
        }

        static void MakeSubset(int index, List<int> subset)
        {
            if (subset.Sum() == N && subset.Count > 0) // if subset sum = N, print it on the console
            {
                subsets.Add(new List<int>(subset));
                solution = true; // set solution to true, and we will not be printing that there is no solution
            }
            for (int i = index; i < numbers.Length; i++)
            {
                subset.Add(numbers[i]);
                MakeSubset(i + 1, subset); // call MakeSubset recursively, every time starting from the previous index + 1
                subset.RemoveAt(subset.Count - 1); // remove last element
            }
        }
    }
}