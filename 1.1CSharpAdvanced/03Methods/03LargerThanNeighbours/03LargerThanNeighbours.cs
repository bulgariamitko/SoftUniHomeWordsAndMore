using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03LargerThanNeighbours
{
    class Program
    {
        static int[] arr;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers separeted by comma (without space)");
            string inputArray = Console.ReadLine();
            arr = inputArray.Split(',').Select(int.Parse).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(CheckIfGreater(i));
            }
        }

        static bool CheckIfGreater(int idx)
        {
            bool isGreater;
            if (idx == 0)
            {
                isGreater = arr[idx] > arr[idx + 1];
            }
            else if (idx == arr.Length - 1)
            {
                isGreater = arr[idx] > arr[idx - 1];
            }
            else
            {
                isGreater = arr[idx] > arr[idx - 1] && arr[idx] > arr[idx + 1];
            }
            return isGreater;
        }
    }
}
