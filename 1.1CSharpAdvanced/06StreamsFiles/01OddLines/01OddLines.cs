using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string line;
            int lineCounter = 0;

            System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\App.config");
            while ((line = file.ReadLine()) != null)
            {
                if (lineCounter % 2 != 0)
                {
                    System.Console.WriteLine(line);
                    counter++;
                }
                lineCounter++;
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
        }
    }
}
