using System;
using System.Linq;

namespace Answer14
{
    class SumElements
    {
        static void Main()
        {
            string input = Console.ReadLine();
            long[] nums = input.Split(' ').Select(s => Convert.ToInt64(s)).ToArray();
            long maxNum = nums.Max();
            long sumArray = nums.Sum();
            long newSum = sumArray - maxNum;

            if (maxNum == newSum)
            {
                Console.WriteLine("Yes, sum={0}", maxNum);
            }
            else
            {
                long result = newSum - maxNum;
                if (result < 0)
                {
                    Console.WriteLine("No, diff={0}", result*(-1));
                }
                else
                {
                    Console.WriteLine("No, diff={0}", result);
                }
                
            }
        }
    }
}
