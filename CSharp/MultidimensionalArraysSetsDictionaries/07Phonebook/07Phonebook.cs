using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contacts = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "search")
                {
                    break;
                }
                else
                {
                    List<string> contact = input.Split('-').ToList();
                    contacts.Add(contact[0], contact[1]);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                string output;
                if (contacts.TryGetValue(input, out output))
                {
                    Console.WriteLine(input + " -> " + output);
                }
                else
                {
                    Console.WriteLine("Contact " + input + " does not exits.");
                }
            }
        }
    }
}
