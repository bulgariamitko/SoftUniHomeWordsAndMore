using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03AsynchronousTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncTimer asyncTimer = new AsyncTimer(PrintDateTimeMilliseconds, 10, 30);
            asyncTimer.Run();
        }

        private static void PrintDateTimeMilliseconds(DateTime nowDateTime)
        {
            Console.WriteLine("{0}:{1}:{2}.{3}", nowDateTime.Hour, nowDateTime.Minute, nowDateTime.Second, nowDateTime.Millisecond);
        }
    }
}
