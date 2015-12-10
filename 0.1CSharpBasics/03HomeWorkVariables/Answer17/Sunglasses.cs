using System;

public class Program
{
    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int newNN = N * 2;
        for (int i = 0; i < N; i++)
        {
            int newN = N - 1;
            if (i == 0 || i == newN)
            {
                for (int ii = 0; ii < newNN; ii++)
                {
                    Console.Write("*");
                }
                for (int iii = 0; iii < N; iii++)
                {
                    Console.Write(" ");
                }
                for (int iiii = 0; iiii < newNN; iiii++)
                {
                    Console.Write("*");
                }
            }
            else
            {
                for (int i2 = 0; i2 < newNN; i2++)
                {
                    int newN2 = newNN - 1;
                    if (i2 == 0 || i2 == newN2)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("/");
                    }
                }
                for (int iii2 = 0; iii2 < N; iii2++)
                {
                    int mid = N / 2;
                    if (i == mid)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                for (int i3 = 0; i3 < newNN; i3++)
                {
                    int newN2 = newNN - 1;
                    if (i3 == 0 || i3 == newN2)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("/");
                    }
                }
            }
            Console.Write("\n");
        }
    }
}