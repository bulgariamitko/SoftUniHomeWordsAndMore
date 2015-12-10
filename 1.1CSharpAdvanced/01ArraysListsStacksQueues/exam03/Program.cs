using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> field = Console.ReadLine().Trim().Split().Select(p => int.Parse(p)).ToList();
            int rows = field[0];
            int cols = field[1];

            StringBuilder fillIt = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                string line = Console.ReadLine();
                for (int i2 = 0; i2 < line.Length; i2++)
                {
                    fillIt.Append(line[i2]);
                }
                fillIt.Append("\n");
            }

            Console.WriteLine(fillIt);

            string commands = Console.ReadLine();

            for (int i3 = 0; i3 < commands.Length; i3++)
            {
                for (int i4 = 0; i4 < fillIt.Length; i4++)
                {
                    if (fillIt[i4] == 'B')
                    {
                        Console.WriteLine("Rabit");
                    }
                }
            }

        }
    }
}
