using System;

namespace Answer16
{
    class HalfSum
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int count1 = 0;
            int newCount1 = 0;
            for (int i = 0; i < n; i++)
            {
                count1 = int.Parse(Console.ReadLine());
                newCount1 = newCount1 + count1;
            }

            int count2 = 0;
            int newCount2 = 0;
            for (int i = 0; i < n; i++)
            {
                count2 = int.Parse(Console.ReadLine());
                newCount2 = newCount2 + count2;
            }

            if (newCount1 == newCount2)
            {
                Console.WriteLine("Yes, sum={0}", newCount1);
            }
            else
            {
                int diff = Math.Abs(newCount1 - newCount2);
                Console.WriteLine("No, diff={0}", diff);
            }
        }

    }
}
