using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10PythagoreanNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> nums = new List<int>();
            bool noOutput = true;

            for (int i = 0; i < n; i++)
            {
                nums.Add(int.Parse(Console.ReadLine()));
            }

            for (int y = 0; y < n; y++)
            {
                for (int y2 = 0; y2 < n; y2++)
                {
                    for (int y3 = 0; y3 < n; y3++)
                    {
                        if (nums[y] <= nums[y2])
                        {
                            if ((nums[y] * nums[y]) + (nums[y2] * nums[y2]) == nums[y3] * nums[y3])
                            {
                                Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", nums[y], nums[y2], nums[y3]);
                                noOutput = false;
                            }
                        }
                    }
                }
            }

            if (noOutput)
            {
                Console.WriteLine("No");
            }
        }
    }
}
