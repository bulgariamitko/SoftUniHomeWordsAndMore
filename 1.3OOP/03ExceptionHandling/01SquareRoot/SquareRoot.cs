using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            try
            {
                int number = int.Parse(input);
                if (number < 0)
                {
                    Console.WriteLine("Invalid number");
                    return;
                }
                double result = Math.Sqrt(number);
                Console.WriteLine("Square root of the number {0} is {1}", number, result);
            }
            catch (FormatException ex)
            {
                Console.Error.WriteLine("Invalid number");
            }
            catch (OverflowException ex)
            {
                Console.Error.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
