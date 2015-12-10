using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer16
{
    class MagicDates
    {
        static void Main(string[] args)
        {
            int bigginYear = int.Parse(Console.ReadLine());
            int endYear = int.Parse(Console.ReadLine());
            int result = int.Parse(Console.ReadLine());

            int diff = endYear - bigginYear;
            int daysInYear = diff + 1;
            int weGotIt = 0;

            //int january = 31;
            //int february = 28;
            //int march = 31;
            //int april = 30;
            //int may = 31;
            //int june = 30;
            //int July = 31;
            //int august = 31;
            //int september = 30;
            //int october = 31;
            //int november = 30;
            //int December = 31;
            
            int months = 1;
            int days = 1;
            int newNumber = 0;
            int result2 = 0;

            for (int i = 0; i < daysInYear * 365 + 365; i++)
            {
                if (days == 32 && months < 13)
                {
                    days = 1;
                    months = months + 1;
                }
                newNumber = int.Parse(days.ToString() + months.ToString() + bigginYear.ToString());
                

                int num1 = newNumber / 10000000;
                int num2 = newNumber / 1000000 % 10;
                int num3 = newNumber / 100000 % 10;
                int num4 = newNumber / 10000 % 10;
                int num5 = newNumber / 1000 % 10;
                int num6 = newNumber / 100 % 10;
                int num7 = newNumber / 10 % 10;
                int num8 = newNumber % 10;

                result2 = num1 * num2 + num1 * num3 + num1 * num4 + num1 * num5 + num1 * num6 + num1 * num7 + num1 * num8 + num2 * num3 + num2 * num4 + num2 * num5 + num2 * num6 + num2 * num7 + num2 * num8 + num3 * num4 + num3 * num5 + num3 * num6 + num3 * num7 + num3 * num8 + num4 * num5 + num4 * num6 + num4 * num7 + num4 * num8 + num5 * num6 + num5 * num7 + num5 * num8 + num6 * num7 + num6 * num8 + num7 * num8;
                if (result2 == result)
                {
                    //Console.WriteLine("{0}-{1}-{3}", days, months, bigginYear);
                    Console.Write("{0:00}", days);
                    Console.Write("-");
                    Console.Write("{0:00}", months);
                    Console.Write("-");
                    Console.Write(bigginYear);
                    Console.WriteLine("");

                    weGotIt = 1;
                }

                if (diff > 0 && months == 12 && days == 31)
                {
                    days = 1;
                    months = 1;
                    bigginYear = bigginYear + 1;
                }

                if (bigginYear > endYear)
                {
                    break;
                }

                days++;
                if (months > 12)
                {
                    break;
                }
            }
            if (weGotIt < 1)
            {
                Console.WriteLine("No");
            }
        }
    }
}
