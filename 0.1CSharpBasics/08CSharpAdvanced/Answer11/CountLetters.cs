using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer11
{
    class CountLetters
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<string> nums = input.OfType<string>().ToList();
            List<string> abc = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            nums.Sort();

            int counter = 0;
            int count = 0;
            for (int i = 0; i < abc.Count; i++)
            {
                for (int j = 0; j < nums.Count; j++)
                {
                    if (abc[i] == nums[j])
                    {
                        counter++;
                        if (nums.Count == 1)
                        {
                            Console.WriteLine("{0} --> {1}", abc[i], counter);
                            return;
                        }
                        nums.RemoveAt(count);
                        j--;

                    }
                    else if (counter == 0)
                    {
                        break;
                    }
                    else if (abc[i] != nums[j] && counter != 0)
                    {
                        Console.WriteLine("{0} --> {1}", abc[i], counter);
                        break;
                    }
                }
                counter = 0;
            }
        }
    }
}
