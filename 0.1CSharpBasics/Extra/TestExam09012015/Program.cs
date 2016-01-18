using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExam09012015
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = 0.1239;

            Console.WriteLine("{0:F3}", num);
            Console.WriteLine("{0:F3}", Math.Round(num, 3));
            Console.WriteLine("{0:0.000}", num);
            Console.WriteLine("{0:#.###}", num);
        }
    }
}
