using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace exam02
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> doubles = new List<string>();
            List<string> ints = new List<string>();

            while (input != "//END_OF_CODE")
            {

                string pattern = @"(\w+) (\w+)";
                var rgx = new Regex(pattern);
                MatchCollection matches = rgx.Matches(input);

                foreach (Match match in matches)
                {
                    if (match.Groups[1].ToString() == "double")
                    {
                        doubles.Add(match.Groups[2].ToString());
                    }
                    if (match.Groups[1].ToString() == "int")
                    {
                        ints.Add(match.Groups[2].ToString());
                    }
                }
               
                input = Console.ReadLine();
            }

            doubles.Sort();
            bool isEmpty = !doubles.Any();

            if (isEmpty)
            {
                Console.WriteLine("Doubles: None");
            }
            else
            {
                Console.WriteLine("Doubles: {0}", string.Join(", ", doubles));
            }

            ints.Sort();
            bool isEmptyInts = !ints.Any();
            if (isEmptyInts)
            {
                Console.WriteLine("Ints: None");
            }
            else
            {
                Console.WriteLine("Ints: {0}", string.Join(", ", ints));
            }

            
        }
    }
}
