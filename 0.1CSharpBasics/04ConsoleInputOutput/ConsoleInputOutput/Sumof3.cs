using System;

namespace Answer01
{
    class Sumof3
    {
        static void Main()
        {
            Console.WriteLine("When you are entering the numbers, please, use COMMA!!!");
            float n = float.Parse(Console.ReadLine());
            float n2 = float.Parse(Console.ReadLine());
            float n3 = float.Parse(Console.ReadLine());
            float sum = n + n2 + n3;

            Console.WriteLine(sum);
        }
    }
}
