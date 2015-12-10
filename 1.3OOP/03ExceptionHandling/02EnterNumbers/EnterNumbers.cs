using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02EnterNumbers
{
    class EnterNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Please, enter start number: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("Please, enter end number: ");
            int end = int.Parse(Console.ReadLine());
            Console.Write("Please, enter number of numbers: ");
            int count = int.Parse(Console.ReadLine());
            int[] numbers = new int[count];

            Console.WriteLine("Plese enter {0} numbers: a1, ... a{0}, such that {1} < a1 < ... < a{0} < {2}. ", count, start, end);
            for (int i = 0; i < count; i++)
            {
                Console.Write("Number a{0}: ", i + 1);
                int number = ReadNumber(start, end - count + i + 1);
                numbers[i] = number;
                start = number;
            }
        }

        private static int ReadNumber(int start, int end)
        {
            while (true)
            {
                string input = Console.ReadLine();
                try
                {
                    int number = int.Parse(input);
                    if (number > start && number < end)
                    {
                        return number;
                    }
                    else
                    {
                        Console.Write("The entered number is not in the range [{0}…{1}].\nPlease enter new number: ",
                            start + 1, end - 1);
                    }
                }
                catch (FormatException ex)
                {
                    Console.Error.Write("The entered number is not in valid format.\nPlease enter valid number: ");
                }
                catch (OverflowException ex)
                {
                    Console.Error.Write("The entered number is not in valid format.\nPlease enter valid number: ");
                }
            }
        }
    }
}
