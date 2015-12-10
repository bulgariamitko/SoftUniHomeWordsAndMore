using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Answer15
{
    class ExtractURL
    {
        static void Main(string[] args)
        {
            string namesString = Console.ReadLine();

            MatchCollection urls = Regex.Matches(namesString, @"\b(?:http://|www\.)\S+\b");

            foreach (var url in urls)
            {
                Console.WriteLine(url);
            }
        }
    }
}
