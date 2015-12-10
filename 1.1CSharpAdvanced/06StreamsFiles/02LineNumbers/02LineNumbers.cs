using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            int cnt = 0;
            using (StreamReader reader = new StreamReader(@"..\..\input.txt"))
            {
                using (StreamWriter writer = new StreamWriter(@"..\..\output.txt"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        {
                            writer.WriteLine(cnt + " " + line);
                            cnt++;
                        }
                    }
                }
            }
        }
    }
}
