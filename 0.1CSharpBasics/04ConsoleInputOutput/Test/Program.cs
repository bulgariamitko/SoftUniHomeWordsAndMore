using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
//            //int num22 = Convert.ToString(num22, 2);
//            string num23 = "23";
//            Console.WriteLine(num23 + 55); //2355
//
//            string num44 = "44";
//            string num55 = "55";
//            Console.WriteLine(num44 + num55); //4455
//
//            int num32 = 32;
//            Console.WriteLine(num32 + 55); //87
//
//            string num24 = "24";
//            Console.WriteLine(55 + num24); //5524
//
//            int i = 0;
//            Console.WriteLine(i++); //0
//            Console.WriteLine(++i); //2
//            Console.WriteLine(i += 1); //3
//            Console.WriteLine(i = i + 1); //4
//
//            // char sym = "r"; ERROR!!!
//            char sym2 = 'R';
//
//            string larvaLab = "varnaLab";
//            string[] arrayString = { "varna lab", "softuni" };

            int[] array = Console.ReadLine().Split(' ').Select(x1 => int.Parse(x1)).ToArray();

            int sum = 0;

            foreach (int x2 in array)
            {
                sum = sum + 2;
            }

//            Console.WriteLine(sum);

            for (int i2 = 0; i2 < array.Length; i2++)
            {
                sum += 2;
            }

            Console.WriteLine(sum);

            int[] nums = {6, 5, 4, 3, 2, 1};

            Console.WriteLine(nums[5]);

        }
    }
}
