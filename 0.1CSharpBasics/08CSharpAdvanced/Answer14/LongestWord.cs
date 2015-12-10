using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer14
{
    class LongestWord
    {
        static void Main(string[] args)
        {
            string namesString = Console.ReadLine();
            string[] allNames = namesString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> words = allNames.ToList<string>();

            //Put this in your class so that it is persisted
            string largestword = "";

            //Put this right before your for loop
            largestword = words[0];

            for (int i = 0; i < words.Count(); i++)
            {
                if (largestword.Length < words[i].Length)
                {
                    largestword = words[i];
                }
            }
            Console.WriteLine(largestword);
        }
    }
}
