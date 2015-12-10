using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05ReverseNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());
            double reversed = GetReversedNumber(input);
            Console.WriteLine(reversed);
        }

        static double GetReversedNumber(double num)
        {
            string number = num.ToString();
            char[] reverse = number.ToCharArray();
            Array.Reverse(reverse);
            string revNum = new string(reverse);
            double newNum = double.Parse(revNum);

            return newNum;
        }
    }
}
