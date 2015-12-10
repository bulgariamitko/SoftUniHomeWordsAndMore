using System;

namespace Answer14
{
    class SumElements
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int[] nums = input.Split(' ').Select(s => Convert.ToInt32(s)).ToArray();

            int maxNum = nums.Max();

            Console.WriteLine(maxNum);
        }
    }
}
