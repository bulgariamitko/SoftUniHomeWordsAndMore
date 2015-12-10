using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer19
{
    class TheExplorer
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int pos = 1;
            int pos2 = 2;
            int count = 0;
            int count2 = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == 0 || i == n - 1)
                {
                    for (int r = 0; r < (n / 2); r++)
                    {
                        Console.Write("_");
                    }
                    Console.Write("*");
                    for (int r = 0; r < (n / 2); r++)
                    {
                        Console.Write("_");
                    }
                }
                else
                {
                    for (int u = 0; u < ((n - pos2 - pos) / 2); u++)
                    {
                        Console.Write("_");
                        count = count + 1;
                    }
                    for (int y = 0; y < 1; y++)
                    {
                        Console.Write("*");
                    }
                    for (int t = 0; t < pos; t++)
                    {
                        Console.Write("_");
                        count2 = count2 + 1;
                    }
                    for (int e = 0; e < 1; e++)
                    {
                        Console.Write("*");
                    }
                    for (int r = 0; r < count; r++)
                    {
                        Console.Write("_");
                    }
                    if (i < (n/2))
                    {
                        pos = pos + 2;
                    }
                    else
                    {
                        pos = pos - 2;
                    }
                    count = 0;
                }
                
                Console.WriteLine("");
            }
        }
    }
}
