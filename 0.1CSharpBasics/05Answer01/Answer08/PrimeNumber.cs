using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer08
{
    class PrimeNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your number: ");
            int number = int.Parse(Console.ReadLine());

            if (number == 1 || number <= 0)
            {
                Console.WriteLine("This number is prime = false");
            }
            else
            {
                int primeCount = 0;

                for (int i = 1; i <= number; i++)
                {
                    if (number % i == 0)
                    {
                        primeCount++;
                    }
                }

                bool isPrime = true;

                if (primeCount > 2)
                {
                    isPrime = false;
                }

                Console.WriteLine("This number is prime = " + isPrime);
            }
        }
    }
}
