using System;

namespace Answer08
{
    class NumbersFrom1
    {
        static void Main()
        {
            float num1 = float.Parse(Console.ReadLine());

            for (int i = 1; i <= num1; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
