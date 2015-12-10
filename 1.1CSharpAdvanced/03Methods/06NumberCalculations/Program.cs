using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06NumberCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] doubleArr = { 1.1, 2.2, 0.3, 1.4, 6.5, 6.6, 1.7, 8.8, 0.9 };
            int[] intArr = { 1, 2, 31, 4, 15, 6, 17, 18, 9 };
            Console.WriteLine("Min member -> double {0}  integer {1}", GetMin(doubleArr), GetMin(intArr));
            Console.WriteLine("Max member -> double {0}  integer {1}", GetMax(doubleArr), GetMax(intArr));
            Console.WriteLine("Sum of elements -> double {0}  integer {1}", GetSum(doubleArr), GetSum(intArr));
            Console.WriteLine("Products of elements -> double {0}  integer {1}", GetProduct(doubleArr), GetProduct(intArr));
            Console.WriteLine("Avarage -> double {0}  integer {1}", GetAverage(doubleArr), GetAverage(intArr));
        }

        static int GetMin(int[] arr)
        {
            int minValue = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (minValue > arr[i])
                {
                    minValue = arr[i];
                }
            }
            return minValue;
        }
        static double GetMin(double[] arr)
        {
            double minValue = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (minValue > arr[i])
                {
                    minValue = arr[i];
                }
            }
            return minValue;
        }
        static int GetMax(int[] arr)
        {
            int maxValue = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (maxValue < arr[i])
                {
                    maxValue = arr[i];
                }
            }
            return maxValue;
        }
        static double GetMax(double[] arr)
        {
            double maxValue = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (maxValue < arr[i])
                {
                    maxValue = arr[i];
                }
            }
            return maxValue;
        }
        static int GetSum(int[] arr)
        {
            int sum = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
        static double GetSum(double[] arr)
        {
            double sum = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
        static int GetProduct(int[] arr)
        {
            int product = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                product *= arr[i];
            }
            return product;
        }
        static double GetProduct(double[] arr)
        {
            double product = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                product *= arr[i];
            }
            return product;
        }
        static int GetAverage(int[] arr)
        {
            int sum = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            sum = sum / arr.Length;
            return sum;
        }
        static double GetAverage(double[] arr)
        {
            double sum = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            sum = sum / arr.Length;
            return sum;
        }
    }
}
