using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer03
{
    class PlayCard
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();

            if (n == "2" || n == "3" || n == "4" || n == "5" || n == "6" || n == "7" || n == "8" || n == "9" || n == "10" || n == "J" || n == "Q" || n == "K" || n == "A")
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
