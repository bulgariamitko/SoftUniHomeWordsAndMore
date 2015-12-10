using System;

namespace Answer10
{
    class FibonacciNumbers
    {
        static void Main()
        {
            int num1 = int.Parse(Console.ReadLine());

            int newNum = num1 - 2;

            int fibonacci1 = 0;
            int fibonacci2 = 1;
            int fibonacci3 = 0;
            Console.Write(fibonacci1);
            Console.Write(" {0}", fibonacci2);
            for (int i = 0; i < num1; i++)
            {
                if (i < newNum)
                {
                    fibonacci3 = fibonacci1 + fibonacci2;
                    Console.Write(" {0}", fibonacci3);
                    fibonacci1 = fibonacci2;
                    fibonacci2 = fibonacci3;
                }
            }
        }
    }
}
