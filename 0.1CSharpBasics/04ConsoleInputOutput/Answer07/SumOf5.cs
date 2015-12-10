using System;

namespace Answer07
{
    class SumOf5
    {
        static void Main()
        {
            Console.WriteLine("Pease, use COMMA and not a dot!!!");
            float num1 = float.Parse(Console.ReadLine());
            float num2 = float.Parse(Console.ReadLine());
            float num3 = float.Parse(Console.ReadLine());
            float num4 = float.Parse(Console.ReadLine());
            float num5 = float.Parse(Console.ReadLine());

            float cal = num1 + num2 + num3 + num4 + num5;

            Console.WriteLine(cal);
        }
    }
}
