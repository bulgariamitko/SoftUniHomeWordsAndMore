using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer10
{
    class OddEven
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            string[] nums = numbers.Split(new char[0]);

            int odd = 1;
            int even = 1;
            int count = 1;

            foreach (var item in nums)
            {
                int item2 = int.Parse(item);
                if (count % 2 == 0)
                {
                    odd *= item2;
                }
                else
                {
                    even *= item2;
                }
                count++;
            }

            if (odd == even)
            {
                Console.WriteLine("yes");
                Console.WriteLine("product = " + odd);
            }
            else
            {
                Console.WriteLine("no");
                Console.WriteLine("odd_product = " + odd);
                Console.WriteLine("even_product = " + even);
            }
        }
    }
}
