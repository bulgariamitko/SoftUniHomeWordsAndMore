using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer02
{
    class BonusScore
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n > 0 && n < 10)
            {
                if (n < 4)
                {
                    Console.WriteLine(n * 10);
                }
                else if (n < 7)
                {
                    Console.WriteLine(n * 100);
                }
                else if (n < 10)
                {
                    Console.WriteLine(n * 1000);
                }
            }
            else
            {
                Console.WriteLine("invalid score");
            }
        }
    }
}
