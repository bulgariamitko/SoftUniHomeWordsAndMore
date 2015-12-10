// working state


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace exam01
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> singersData = new Dictionary<string, long>();

            StringBuilder vanueIt = new StringBuilder();
            long totalPrice;

            string input = Console.ReadLine();

            while (input != "End")
            {

                List<string> data = input.Trim().Split('@').ToList();

                Console.WriteLine("data0: |{0}|", data[0]);
                Console.WriteLine("data1: |{0}|", data[1]);


                string pattern2 = @"[\D+]";
                MatchCollection vanue = Regex.Matches(data[1], pattern2);
                foreach (Match match in vanue)
                {
                    vanueIt.Append(match);
                }

                //Console.WriteLine("|{0}|", data[0].Trim());
                //Console.WriteLine("|{0}|", vanueIt.ToString().Trim());

                string pattern = @"([0-9]+) ([0-9]+)";
                var rgx = new Regex(pattern);
                MatchCollection price = rgx.Matches(data[1]);

                foreach (Match match in price)
                {
                    long tickets = long.Parse(match.Groups[1].ToString().Trim());
                    long priceIt = long.Parse(match.Groups[2].ToString().Trim());
                    totalPrice = tickets * priceIt;

                    string createKey = vanueIt.ToString().Trim() + " " + data[0].Trim();

                    if (!singersData.ContainsKey(createKey))
                    {
                        singersData.Add(createKey, totalPrice);
                    }
                    else
                    {
                        singersData[createKey] += totalPrice;
                    }
                    

                    //singersData[vanueIt.ToString().Trim()][data[0].Trim()] 


                    //if (vanuePrice.FindIndex(p => p.KeyValuePair(data[0].Trim())))
                    //{
                    //    singersData[vanueIt.ToString().Trim()][data[0].Trim()] += totalPrice;
                    //}

                }

                vanueIt.Clear();
                input = Console.ReadLine();
            }

            var sorted = singersData.OrderByDescending(c => c.Value);

            foreach (var pair in sorted)
            {
                //string[] extractData = pair.Key.Split
                Console.WriteLine("{0} {1}", pair.Key, pair.Value);
                //foreach (var innerPair in pair.Value.OrderByDescending(c => c.Value))
                //{
                //    Console.WriteLine("#  {0} -> {1}", innerPair.Key, innerPair.Value);
                //}
            }


        }
    }
}
