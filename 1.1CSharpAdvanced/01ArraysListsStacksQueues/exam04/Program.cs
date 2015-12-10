using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Trim().Split().Select(p => int.Parse(p)).ToList();
            string input = Console.ReadLine();

            while (input != "end")
            {
                List<string> commands = input.Trim().Split().ToList();
                if (commands[0] == "exchange")
                {
                    list = Exchange(list, int.Parse(commands[1]));
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", list));

        }

        static List<int> Exchange(List<int> list, int index)
        {
            List<int> transformList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == index)
                {
                    transformList.Add(list[i]);
                }
            }

            for (int i2 = 0; i2 < list.Count; i2++)
            {
                if (list[i2] != index)
                {
                    transformList.Add(list[i2]);
                }
            }

            return transformList;
        }

    }
}
