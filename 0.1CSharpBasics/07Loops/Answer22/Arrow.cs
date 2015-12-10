using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer22
{
    class Arrow
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int half = n - 1;
            int lines = half + n;
            int count = n - 1;
            int mid = lines - 4;

            for (int i = 1; i < lines + 1; i++)
            {
                if (i == 1)
                {
                    for (int i2 = 0; i2 < half / 2; i2++)
                    {
                        Console.Write(".");
                    }
                    for (int i3 = 0; i3 < n; i3++)
                    {
                        Console.Write("#");
                    }
                    for (int i4 = 0; i4 < half / 2; i4++)
                    {
                        Console.Write(".");
                    }
                }
                else if (i < half + 1)
                {
                    for (int i5 = 0; i5 < half / 2; i5++)
                    {
                        Console.Write(".");
                    }
                    for (int i6 = 0; i6 < 1; i6++)
                    {
                        Console.Write("#");
                    }
                    for (int i7 = 0; i7 < n - 2; i7++)
                    {
                        Console.Write(".");
                    }
                    for (int i8 = 0; i8 < 1; i8++)
                    {
                        Console.Write("#");
                    }
                    for (int i9 = 0; i9 < half / 2; i9++)
                    {
                        Console.Write(".");
                    }
                }
                else if (i == n)
                {
                    for (int i10 = 0; i10 < (half / 2) + 1; i10++)
                    {
                        Console.Write("#");
                    }
                    for (int i11 = 0; i11 < n - 2; i11++)
                    {
                        Console.Write(".");
                    }
                    for (int i12 = 0; i12 < (half / 2) + 1; i12++)
                    {
                        Console.Write("#");
                    }
                }
                else if (i == n + half)
                {
                    for (int i18 = 0; i18 < n - 1; i18++)
                    {
                        Console.Write(".");
                    }
                    for (int i19 = 0; i19 < 1; i19++)
                    {
                        Console.Write("#");
                    }
                    for (int i20 = 0; i20 < n - 1; i20++)
                    {
                        Console.Write(".");
                    }
                }
                else
                {
                    for (int i13 = 0; i13 < n - count; i13++)
                    {
                        Console.Write(".");

                    }
                    for (int i14 = 0; i14 < 1; i14++)
                    {
                        Console.Write("#");
                    }
                    for (int i15 = 0; i15 < mid; i15++)
                    {
                        Console.Write(".");
                    }
                    for (int i16 = 0; i16 < 1; i16++)
                    {
                        Console.Write("#");
                    }
                    for (int i17 = 0; i17 < n - count; i17++)
                    {
                        Console.Write(".");
                    }
                    count--;
                    mid -= 2;
                }
                Console.WriteLine("");
            }
        }
    }
}
