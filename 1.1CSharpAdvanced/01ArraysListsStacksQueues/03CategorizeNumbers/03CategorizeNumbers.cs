using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03CategorizeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // please, if the programe dosent work write the numbers with comma
            List<decimal> arr = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();

            List<decimal> decimalArray = new List<decimal>();
            List<int> intArray = new List<int>();

            foreach (var item in arr)
            {
                if (item % 1 == 0)
                {
                    intArray.Add(Convert.ToInt32(item));
                }
                else
                {
                    decimalArray.Add(item);
                }
            }

            Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:F2}", string.Join(", ", decimalArray), decimalArray.Min(), decimalArray.Max(), decimalArray.Sum(), decimalArray.Average());
            Console.WriteLine("[{0}] -> min: {1}, max: {2}, sum: {3}, avg: {4:F2}", string.Join(", ", intArray), intArray.Min(), intArray.Max(), intArray.Sum(), intArray.Average());
        }
    }
}
