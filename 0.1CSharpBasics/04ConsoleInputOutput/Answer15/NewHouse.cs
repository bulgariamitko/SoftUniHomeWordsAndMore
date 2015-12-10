using System;

namespace Answer15
{
    class NewHouse
    {
        static void Main()
        {
            int h = int.Parse(Console.ReadLine());
            int incr = 1;
            int newnum = h / 2;

            for (int t = 0; t < incr; t++)
            {
                if (t == h - 1)
                {
                    for (int e = 0; e < h; e++)
                    {
                        Console.Write("*");
                    }
                    Console.Write("");
                }
                else if (incr < h) 
                {
                    for (int q = 0; q < newnum; q++)
                    {
                        Console.Write("-");
                    }
                    for (int r = 0; r < incr; r++)
                    {
                        Console.Write("*");
                    }
                    for (int q = 0; q < newnum; q++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine("");
                }
                if (incr < h)
                {
                    incr = incr + 2;
                    newnum = newnum - 1;
                }
            }
            Console.WriteLine("");
            
            for (int i = 0; i < h; i++)
            {
                Console.Write("|");
                for (int r = 0; r < (h - 2); r++)
                {
                    Console.Write("*");
                }
                Console.Write("|");
                Console.WriteLine("");
            }
        }
    }
}
