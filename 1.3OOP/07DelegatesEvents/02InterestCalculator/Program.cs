using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02InterestCalculator
{
    class Program
    {
        private const int N = 12;

        static void Main(string[] args)
        {
            Func<decimal, decimal, int, decimal> simple = GetSimpleInterest;
            Func<decimal, decimal, int, decimal> compound = GetCompoundInterest;

            var interest1 = new Calculator(500m, 5.6m, 10, compound);
            var interest2 = new Calculator(2500m, 7.2m, 15, simple);

            Console.WriteLine(interest1);
            Console.WriteLine(interest2);
        }

        private static decimal GetSimpleInterest(decimal sum, decimal interest, int years)
        {
            return sum*(1 + (interest/100*years));
        }

        private static decimal GetCompoundInterest(decimal sum, decimal interest, int years)
        {
            return sum*(decimal) Math.Pow((double) (1 + (interest/100/N)), years*N);
        }
    }
}
