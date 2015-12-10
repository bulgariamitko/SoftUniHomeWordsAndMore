using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer10
{
    class BeerTime
    {
        static void Main(string[] args)
        {
            Console.Write("Enter hours in format hh:");
            int hh = int.Parse(Console.ReadLine());
            Console.Write("Enter minutes in format mm:");
            int mm = int.Parse(Console.ReadLine());
            Console.Write("Enter AM or PM:");
            string tt = Console.ReadLine();

            if ((tt == "AM" && hh < 3 && hh >= 0) || (tt == "PM" && hh >= 1 && hh < 13))
            {
                if (mm < 60)
                {
                    Console.WriteLine("beer time");
                }
                else
                {
                    Console.WriteLine("non-beer time");
                }
            }
            else
            {
                Console.WriteLine("non-beer time");
            }
        }
    }
}
