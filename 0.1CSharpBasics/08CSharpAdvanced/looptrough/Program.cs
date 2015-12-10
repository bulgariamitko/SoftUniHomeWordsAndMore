using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1234
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //top
            int front = n - 1;
            int back = n;
            Console.WriteLine("{0}*{1}", new string('.', front), new string('.', back));

            //top lines
            int stars = 1;
            for (int i = 0; i < n - 1; i++)
            {
                if (i < n / 2)
                {
                    front -= 2;
                    stars += 2;
                }
                else
                {
                    front += 2;
                    stars -= 2;

                }

                Console.WriteLine("{0}{1}{2}", new string('.', front), new string('*', stars), new string('.', back));
            }

            //bottom
            //front += 2;
            //Console.WriteLine("{0}*{1}", new string('.', front), new string('.', back));

            //end
            int frontEnd = 0;
            int mid = n * 2;
            for (int i2 = 0; i2 < n / 2; i2++)
            {
                Console.WriteLine("{0}{1}{0}", new string('.', frontEnd), new string('*', mid));
                mid -= 2;
                frontEnd++;
            }
        }
    }
}
