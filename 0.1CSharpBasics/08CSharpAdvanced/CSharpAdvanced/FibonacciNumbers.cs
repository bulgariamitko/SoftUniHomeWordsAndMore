using System;
using System.Diagnostics;
using System.Net;

namespace CSharpAdvanced
{
    class FibonacciNumbers
    {
        public static int Fibonacci(int n)
        {
            int a = 1;
            int b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Fibonacci(n));
        }
    }
}
