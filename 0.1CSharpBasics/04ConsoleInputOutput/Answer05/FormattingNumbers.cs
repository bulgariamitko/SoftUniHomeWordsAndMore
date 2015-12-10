using System;

namespace Answer05
{
    class FormattingNumbers
    {
        static void Main()
        {
            Console.WriteLine("Pease, use COMMA and not a dot!!!");
            int num = int.Parse(Console.ReadLine());
            float num2 = float.Parse(Console.ReadLine());
            float num3 = float.Parse(Console.ReadLine());

            string hexValue = num.ToString("X");

            Console.WriteLine(String.Format("|{0,-8}|{1,8}|{2,8:F2}|{3,-8:F3}|", hexValue, Convert.ToString(num, 2).PadLeft(10, '0'), num2, num3));

            

        }
    }
}
