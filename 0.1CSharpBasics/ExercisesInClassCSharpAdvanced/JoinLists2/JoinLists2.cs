using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinLists2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] arr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<int> list = new List<int>();

            foreach (var item in arr)
            {
                if (list.Exists(p => p.Equals(item)))
                {
                    continue;
                }
                else
                {
                    list.Add(item);
                }
            }

            foreach (var item2 in arr2)
            {
                if (list.Exists(p => p.Equals(item2)))
                {
                    continue;
                }
                else
                {
                    list.Add(item2);
                }
            }

            list.Sort();

            foreach (var item3 in list)
            {
                Console.Write("{0} ", item3);
            }

            Console.WriteLine("");

        }
    }
}
