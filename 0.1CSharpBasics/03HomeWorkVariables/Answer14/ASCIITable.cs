using System;
using System.Text;

namespace Answer14
{
    class ASCIITable
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;


            for (byte counter = 0; counter < 255; counter++)
            {
                Console.Write((char)counter + ", ");
            }
        }
    }
}
