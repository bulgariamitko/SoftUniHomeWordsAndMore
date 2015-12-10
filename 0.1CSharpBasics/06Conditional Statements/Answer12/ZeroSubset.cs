using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer12
{
    class ZeroSubset
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            bool isThere = false;

            if (a == 0 && b == 0 && c == 0 && d == 0 && e == 0)
            {
                Console.WriteLine("{0} + {1} + {2} + {3} + {4} = 0", a, b, c, d, e);
                Environment.Exit(0);
            }

            if (a + b == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} = 0", a, b);
            }
            if (a + c == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} = 0", a, c);
            }
            if (a + d == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} = 0", a, d);
            }
            if (a + e == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} = 0", a, e);
            }
            if (b + c == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} = 0", b, c);
            }
            if (b + d == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} = 0", b, d);
            }
            if (b + e == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} = 0", b, e);
            }
            if (c + d == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} = 0", c, d);
            }
            if (a + b + c == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} + {2} = 0", a, b, c);
            }
            if (a + b + d == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} + {2} = 0", a, b, d);
            }
            if (a + b + e == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} + {2} = 0", a, b, e);
            }
            if (a + c + d == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} + {2} = 0", a, c, d);
            }
            if (a + c + e == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} + {2} = 0", a, c, e);
            }
            if (a + d + e == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} + {2} = 0", a, d, e);
            }
            if (b + c == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} = 0", b, c);
            }
            if (b + d == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} = 0", b, d);
            }
            if (b + e == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} = 0", b, e);
            }
            if (b + c + d == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} + {2} = 0", b, c, d);
            }
            if (b + c + e == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} + {2} = 0", b, c, e);
            }
            if (b + d + e == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} + {2} = 0", b, d, e);
            }
            if (c + d == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} = 0", c, d);
            }
            if (c + e == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} = 0", c, e);
            }
            if (c + d + e == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} + {2} = 0", c, d, e);
            }
            if (d + e == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} = 0", d, e);
            }
            if (a + b + c + d == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, b, c, d);
            }
            if (a + b + c + e == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, b, c, e);
            }
            if (a + b + d + e == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, b, d, e);
            }
            if (a + c + d + e == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, c, d, e);
            }
            if (b + c + d + e == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} + {2} + {3} = 0", b, c, d, e);
            }
            if (a + b + c + d + e == 0)
            {
                isThere = true;
                Console.WriteLine("{0} + {1} + {2} + {3} + {4} = 0", a, b, c, d, e);
            }
            if (!isThere)
            {
                Console.WriteLine("no zero subset");
            }
        }
    }
}
