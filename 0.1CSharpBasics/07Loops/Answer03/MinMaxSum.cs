using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer03
{
    class MinMaxSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();

            for (int i = 1; i < n + 1; i++)
            {
                int n2 = int.Parse(Console.ReadLine());
                list.Add(n2);
            }

            int[] array = list.ToArray();

            Console.WriteLine("min = {0}", array.Min());
            Console.WriteLine("max = {0}", array.Max());
            Console.WriteLine("sum = {0}", array.Sum());
            Console.WriteLine("avg = {0,00}", array.Average().ToString("#.##"));
        }
    }
}
