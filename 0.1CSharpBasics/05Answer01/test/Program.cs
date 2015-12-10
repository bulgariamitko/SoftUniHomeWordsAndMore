using System;
using System.Net;

namespace test
{
    public class Program
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char gemChar = Convert.ToChar(Console.ReadLine());

            int center = size/2;
            int counter1 = 1;
            int counter2 = size/2;

            for (int i = 0; i < size; i++)
            {
                //gorna chast
                if (i < center)
                {
                    Console.Write(new string('-', counter2));
                    Console.Write(new string(gemChar, counter1));
                    Console.WriteLine(new string('-', counter2));
                    counter2--;
                    counter1 += 2;
                    continue;
                }
                // dolna chast
                if (i >= center)
                {
                    Console.Write(new string('-', counter2));
                    Console.Write(new string(gemChar, counter1));
                    Console.WriteLine(new string('-', counter2));
                    counter2++;
                    counter1 -= 2;
                    continue;
                }

                Console.WriteLine(new string('g', -1));
            }

        }
    }
}
