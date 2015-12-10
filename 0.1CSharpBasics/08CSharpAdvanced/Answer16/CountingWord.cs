using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Answer16
{
    class CountingWord
    {
        static void Main(string[] args)
        {
            string wordToSearch = Console.ReadLine();
            string text = Console.ReadLine();
            foreach (var symbol in text)
            {
                if (!Char.IsLetter(symbol))
                {
                    text = text.Replace(symbol, ' ');
                }
            }
            string[] list = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string wordToSearchToLower = wordToSearch.ToLower();
            int count = list.Count(w => w.ToLower() == wordToSearchToLower);
            Console.WriteLine(count);
        }
    }
}
