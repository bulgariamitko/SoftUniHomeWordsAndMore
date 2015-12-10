using System;

namespace Answer13
{
    class WorkHours
    {
        static void Main()
        {
            decimal h = decimal.Parse(Console.ReadLine());
            decimal d = decimal.Parse(Console.ReadLine());
            decimal p = decimal.Parse(Console.ReadLine());

            decimal procent = d - ((d * 10) / 100);
            decimal week = procent * 12;
            decimal productivity = Math.Floor((week * p) / 100);
            decimal result = productivity - h;

            if (result >= 0)
            {
                Console.Write("Yes\n{0}", result);
            }
            else
            {
                Console.WriteLine("No\n{0}", result);
            }
        }
    }
}
