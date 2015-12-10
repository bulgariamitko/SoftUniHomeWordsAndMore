using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            if (1 < k && k < n && n < 100)
            {
                int factN = 1;
                int factK = 1;
                int count = 1;
                int result = 0;

                for (int i = n - k + 1; i <= n; i++)
                {
                    factN *= i;
                    if (count <= k)
                    {
                        factK *= count;
                        count++;
                    }
                }
                result = factN / factK;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
