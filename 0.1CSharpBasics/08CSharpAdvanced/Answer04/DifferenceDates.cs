using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer04
{
    class DifferenceDates
    {
        static void Main(string[] args)
        {
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            TimeSpan diff = endDate - startDate;
            double days = diff.TotalDays;
            Console.WriteLine(days);
        }
    }
}
