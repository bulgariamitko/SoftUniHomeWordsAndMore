using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveName
{
    class RemoveName
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> listIt = input.Split(' ').ToList();
            string input2 = Console.ReadLine();
            List<string> listIt2 = input2.Split(' ').ToList();

            for (int i = 0; i < listIt2.Count; i++)
            {
                for (int j = 0; j < listIt.Count; j++)
                {
                    if (listIt2[i] == listIt[j])
                    {
                        listIt.RemoveAt(j);
                        if (j == listIt.Count)
                        {
                            break;
                        }
                        if (listIt2[i] == listIt[j])
                        {
                            listIt.RemoveAt(j);
                            j--;
                            continue;
                        }
                    }
                }
            }

            foreach (var i in listIt)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("");
        }
    }
}
