using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer09
{
    class MatrixNum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int n2 = 1;

            if (1 <= n && n <= 20)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int i2 = 0; i2 < n; i2++)
                    {
                        Console.Write("{0} ", n2);
                        if (i2 == n - 1)
                        {
                            n2 = 1;
                            n2 += i + 1;
                        }
                        else
                        {
                            n2++;
                        }
                    }
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Number is out of range!");
            }
        }
    }
}
