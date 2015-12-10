using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading; 

namespace Answer13
{
    class Triangle
    {
        static void Main(string[] args)
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            int ax = int.Parse(Console.ReadLine());
            int ay = int.Parse(Console.ReadLine());
            int bx = int.Parse(Console.ReadLine());
            int by = int.Parse(Console.ReadLine());
            int cx = int.Parse(Console.ReadLine());
            int cy = int.Parse(Console.ReadLine());

            double a = Math.Sqrt(((bx - ax) * (bx - ax)) + ((by - ay) * (by - ay)));
            double b = Math.Sqrt(((cx - bx) * (cx - bx)) + ((cy - by) * (cy - by)));
            double c = Math.Sqrt(((cx - ax) * (cx - ax)) + ((cy - ay) * (cy - ay)));

            if (a + b > c && b + c > a && a + c > b)
            {
                Console.WriteLine("Yes");
                double p = (a + b + c) / 2;
                double area = Math.Round(Math.Sqrt(p*(p - a)* (p - b) * (p - c)), 2);
                Console.WriteLine("{0:F2}", area);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("{0:F2}", a);
            }
        }
    }
}
