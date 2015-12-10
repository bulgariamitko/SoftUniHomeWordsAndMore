using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class judge
{
    static void Main()
    {
        string line = Console.ReadLine();
        Dictionary<string, Dictionary<string, long>> countryData = new Dictionary<string, Dictionary<string, long>>();

        while (line != "report")
        {
            string[] lineArgs = line.Split('|');
            string city = lineArgs[0];
            string country = lineArgs[1];
            long population = long.Parse(lineArgs[2]);

            if (!countryData.ContainsKey(country))
            {
                countryData.Add(country, new Dictionary<string, long>());
            }

            countryData[country][city] = population;

            line = Console.ReadLine();
        }

        var sorted = countryData.OrderByDescending(c => c.Value.Sum(s => s.Value));

        foreach (var pair in sorted)
        {
            Console.WriteLine("{0} (total population: {1})", pair.Key, pair.Value.Sum(s => s.Value));
            foreach (var innerPair in pair.Value.OrderByDescending(c => c.Value))
            {
                Console.WriteLine("=>{0}: {1}", innerPair.Key, innerPair.Value);
            }
        }
    }
}