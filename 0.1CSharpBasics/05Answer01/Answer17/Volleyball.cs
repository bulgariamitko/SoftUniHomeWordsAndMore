using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer17
{
    class Volleyball
    {
        static void Main(string[] args)
        {
            string leap = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            int totalWeeks = 48;
            int normalWeeks = totalWeeks - h;
            double plays = normalWeeks * (3.0 / 4.0);
            double plays2 = p * (2.0 / 3.0);
            int totalPlays = 0;

            if (leap == "leap")
            {
                double addIt = (plays + plays2 + h) * 0.15;
                totalPlays = (int)Math.Floor(plays + plays2 + addIt + h);
            }
            else
            {
                totalPlays = (int)Math.Floor(plays + plays2 + h);
            }
            Console.WriteLine(totalPlays);
        }
    }
}
