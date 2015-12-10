using System;
using System.Globalization;

namespace Answer13
{
    class ComparingFloats
    {
        static void Main()
        {
            // take second number with , separation
            Console.Write("Enter the first number (PLEASE, USE COMMA): ");
            decimal firstNumber = decimal.Parse(Console.ReadLine());

            // take second number with , separation
            Console.Write("Enter the second number (PLEASE, USE COMMA): ");
            decimal secondNumber = decimal.Parse(Console.ReadLine());

            // compare them
            bool comparing = (Math.Abs(firstNumber - secondNumber) < 0.000001m);
            Console.WriteLine(comparing);
        }

    }
}
