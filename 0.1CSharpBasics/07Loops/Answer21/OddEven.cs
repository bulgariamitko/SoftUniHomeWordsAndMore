using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer21
{
    class OddEven
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            string[] nums = numbers.Split(new char[0]);
            var odd = new List<decimal>();
            var even = new List<decimal>();
            int count = 0;

            if (numbers == "")
            {
                Console.Write("OddSum=No, OddMin=No, OddMax=No, EvenSum=No, EvenMin=No, EvenMax=No");
            }
            else
            {
                foreach (var item in nums)
                {
                    decimal item2 = decimal.Parse(item);
                    if (count % 2 == 0)
                    {
                        odd.Add(item2);
                    }
                    else
                    {
                        even.Add(item2);
                    }
                    count++;
                }
                int oddCount = odd.Count;
                int evenCount = even.Count;
                if (oddCount > 0)
                {
                    Console.Write("OddSum={0}, OddMin={1}, OddMax={2}, ", (double)odd.Sum(), (double)odd.Min(), (double)odd.Max());
                }
                else
                {
                    Console.Write("OddSum=No, OddMin=No, OddMax=No, ");
                }
                if (evenCount > 0)
                {
                    Console.Write("EvenSum={0}, EvenMin={1}, EvenMax={2}", (double)even.Sum(), (double)even.Min(), (double)even.Max());
                }
                else
                {
                    Console.Write("EvenSum=No, EvenMin=No, EvenMax=No");
                }
            }
        }
    }
}