using System;

namespace Answer11
{
    class NumbersInterval
    {
        static void Main()
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int c = 0;

            if (num1 > 0 && num2 > 0)
            {
                for (int i = num1; i <= num2; i++)
                {
                    if (i % 5 == 0)
                    {
                        Console.Write("{0}, ", i);
                        c++;
                    }
                }
                Console.WriteLine("The number of the numbers is/are: {0}", c);
            }
        }
    }
}
