using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            SortedDictionary<string, int> wordIt = new SortedDictionary<string, int>();

            using (StreamReader words = new StreamReader(@"..\..\words.txt"))
            {
                using (StreamReader text = new StreamReader(@"..\..\text.txt"))
                {
                    while ((line = words.ReadLine()) != null)
                    {
                        wordIt.Add(line, 0);
                    }

                    while ((line = text.ReadLine()) != null)
                    {
                        string pattern = @"[^\w+]";
                        string[] substrings = Regex.Split(line, pattern).Where(n => !string.IsNullOrEmpty(n)).ToArray();
                        foreach (string match in substrings)
                        {
                            if (wordIt.ContainsKey(match.ToLower()))
                            {
                                int counter = wordIt[match.ToLower()];
                                wordIt[match.ToLower()] = counter + 1;

                                
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, int> item in wordIt.OrderByDescending(key => key.Value))
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value);
            }
        }
    }
}
