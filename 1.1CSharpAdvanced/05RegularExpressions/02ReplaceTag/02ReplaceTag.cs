using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02ReplaceTag
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder newString = new StringBuilder();

            while (true)
            {
                string input = Console.ReadLine();
                int leng = input.Length;

                string pattern = @"<a\s+href=([^>]+)>([^<]+)</a>";
                Regex regex = new Regex(pattern);
                string replacement = "[URL href=$1]$2[/URL]";
                string result = Regex.Replace(input, pattern, replacement);

                if (result != "")
                {
                    newString.Append(result + "\n");
                }
                else
                {
                    newString.Append(input + "\n");
                }

                if (input[leng - 1] == '"')
                {
                    break;
                }

            }
            newString.Remove(0, 1);
            newString.Remove(newString.Length - 2, 1);
            Console.WriteLine(newString);
        }
    }
}
