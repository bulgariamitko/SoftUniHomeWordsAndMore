using System;

namespace Answer01
{
    class DeclareVariables
    {
        static void Main(string[] args)
        {
            int num1 = 0;
            sbyte num2 = -115;
            int num3 = 4825923;
            byte num4 = 97;
            short num5 = -10000;
            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}", num4, num2, num1, num3, num5);

   
            

            sbyte num10 = -100;
            byte num11 = 128;
            short num12 = -3540;
            ushort num13 = 64876;
            uint num14 = 2147483648;
            int num15 = -1141583228;
            long num16 = -1223372036854775808;

            string text = "Software University";

            char raztoyanie = ' ';

            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
            }

            int numMax = int.MaxValue;
            int newMax = numMax + 2;

            char numm3 = '\u0011';
            Console.WriteLine(numm3);

            int? num333 = null;
            string text22 = "";
            string text222 = null;
            Console.WriteLine("Text22: {0}", text22);
            Console.WriteLine("Text222: {0}", text222);
            Console.WriteLine("Text: " + text222 + "END");
            Console.WriteLine("Num333: {0}", num333);

            //long cast = (long)num1;
            int? num3333 = null;
            num3333 = 5;
            num3333 += 5;
            Console.WriteLine("Num3333: {0}", num3333);

            int[] num43434343 = {5, 5, 34, 4};

            Console.WriteLine(String.Join(", ", num43434343));

            int num111 = 0;
            num111 += 5;
            num111 = num111 + 5;
            Console.WriteLine(num111);
            num111++;
            Console.WriteLine(num111);

            double sum1 = 1.33d;
            double sum2 = 0.33d;
            Console.WriteLine(sum1 + sum2);

            float num22 = 1.60217657f;
            Console.WriteLine(num22);


        }
    }
}
