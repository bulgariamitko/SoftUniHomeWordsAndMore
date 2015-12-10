using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer12
{
    class RandomizeN
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[] array = new int[num];
            for (int index = 0; index < num; index++)
            {
                array[index] = index + 1;
            }

            Random random = new Random();
            foreach (int index in array)
            {
                int randNum = random.Next(0, num);
                int temp = array[randNum];
                array[randNum] = array[0];
                array[0] = temp;
            }
            Console.WriteLine(String.Join(" ", array));
        }

    }
}
