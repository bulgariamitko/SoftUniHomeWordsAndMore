using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer15
{
    class Joro
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();

            float holidays = float.Parse(Console.ReadLine());

            float hometown = float.Parse(Console.ReadLine());

            float totalWeeks = 52;

            float totalPlays = 0;

            totalPlays = totalPlays + hometown;

            float normalWeeks = (totalWeeks - hometown) * 2 / 3;

            holidays = holidays / 2;

            bool leapLear = year == "t";

            if (leapLear)
            {
                totalPlays = totalPlays + 3;
            }

            totalPlays = totalPlays + normalWeeks + holidays;

            Console.WriteLine(Math.Floor(totalPlays));
        }
    }
}
