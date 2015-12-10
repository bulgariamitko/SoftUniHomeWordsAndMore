using System;

namespace Answer04
{
    class NumberComparer
    {
        static void Main()
        {
            Console.WriteLine("Pease, use COMMA and not a dot!!!");
            float num = float.Parse(Console.ReadLine());
            float num2 = float.Parse(Console.ReadLine());

            if (num > num2)
            {
                Console.WriteLine(num);
            }
            else
            {
                Console.WriteLine(num2);
            }
        }
    }
}
