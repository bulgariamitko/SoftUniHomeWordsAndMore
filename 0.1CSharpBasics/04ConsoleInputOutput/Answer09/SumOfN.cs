using System;

namespace Answer09
{
    class SumOfN
    {
        static void Main()
        {
            Console.WriteLine("Pease, use COMMA and not a dot!!!");
            float num1 = float.Parse(Console.ReadLine());

            float cal = 0;
            for (int i = 0; i < num1; i++)
            {
                float num2 = float.Parse(Console.ReadLine());
                cal = cal + num2;
            }
            Console.WriteLine(cal);
        }
    }
}
