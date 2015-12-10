using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer04
{
    class PrintDeck
    {
        static void Main(string[] args)
        {
            for (int i = 2; i < 16; i++)
            {
                if (i < 11)
                {
                    Console.Write("{0}♠ {0}♥ {0}♣ {0}♦", i);
                }
                else if (i == 12)
                {
                    Console.Write("J♠ J♥ J♣ J♦");
                }
                else if (i == 13)
                {
                    Console.Write("Q♠ Q♥ Q♣ Q♦");
                }
                else if (i == 14)
                {
                    Console.Write("K♠ K♥ K♣ K♦");
                }
                else if (i == 15)
                {
                    Console.Write("A♠ A♥ A♣ A♦");
                }
                if (i != 11)
                {
                    Console.WriteLine("");    
                }
            }
        }
    }
}
