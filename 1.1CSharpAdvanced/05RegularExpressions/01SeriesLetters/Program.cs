using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01SeriesLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(\w)\1+|(\w)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.Write(match.Groups[1]);
                Console.Write(match.Groups[2]);
                
            }
            Console.WriteLine();
        }
    }
}
