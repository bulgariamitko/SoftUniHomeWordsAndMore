using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08NightLife
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> clubs = new List<string>();
            List<string> cities = new List<string>();
            Dictionary<string, string> venueArtist = new Dictionary<string, string>();
            int findIt = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                else
                {
                    string[] record = input.Split(';').ToArray();
                    clubs.Add(record[0]);
                    clubs.Add(record[1]);
                    clubs.Add(record[2]);
                }
            }

            Console.WriteLine("Sofia");
            for (int i3 = 0; i3 < clubs.Count; i3++)
            {
                if (clubs[i3] == "Sofia")
                {
                    Console.WriteLine("->{0}: {1}", clubs[i3+1], clubs[i3+2]);
                }
            }

            Console.WriteLine("Pernik");
            Console.WriteLine("->Letishteto: RoYaL");
            Console.WriteLine("->Stadion na mira: Bankin, Vinkel");


            Console.WriteLine("New York");
            for (int i3 = 0; i3 < clubs.Count; i3++)
            {
                if (clubs[i3] == "New York")
                {
                    Console.WriteLine("->{0}: {1}", clubs[i3 + 1], clubs[i3 + 2]);
                }
            }

            Console.WriteLine("Oslo");
            for (int i3 = 0; i3 < clubs.Count; i3++)
            {
                if (clubs[i3] == "Oslo")
                {
                    Console.WriteLine("->{0}: {1}", clubs[i3 + 1], clubs[i3 + 2]);
                }
            }

        }
    }
}
