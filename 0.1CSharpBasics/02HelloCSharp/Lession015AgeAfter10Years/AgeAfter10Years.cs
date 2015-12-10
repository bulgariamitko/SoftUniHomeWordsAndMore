using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lession015AgeAfter10Years
{
    class AgeAfter10Years
    {
        static void Main(string[] args)
        {
            int CurrentYear = DateTime.Now.Year;
            int MyBirthday = 1984;
            int MyAge = CurrentYear - MyBirthday;
            Console.WriteLine("The current year is: {0}", CurrentYear);
            Console.WriteLine("My birthday year is: {0}", MyBirthday);
            Console.WriteLine("Current year - my birthday = {0}", MyAge);
            Console.WriteLine("After 10 years my age will be: {0}", MyAge + 10);
        }
    }
}
