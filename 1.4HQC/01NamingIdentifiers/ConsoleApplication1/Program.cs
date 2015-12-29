using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main()
        {
            var arrayOfNumbers = new double[,] { { 1, 3 }, { 5, 7 } };
            var secondarrayOfNumbers = new double[,] { { 4, 2 }, { 1, 5 } };
            var combinedArrays = CombineTwoArrays(arrayOfNumbers, secondarrayOfNumbers);

            for (int i = 0; i < combinedArrays.GetLength(0); i++)
            {
                for (int j = 0; j < combinedArrays.GetLength(1); j++)
                {
                    Console.Write(combinedArrays[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static double[,] CombineTwoArrays(double[,] array1, double[,] array2)
        {
            if (array1.GetLength(1) != array2.GetLength(0))
            {
                throw new Exception("Error!");
            }

            var arraySize = array1.GetLength(1);
            var newDoubleArray = new double[array1.GetLength(0), array2.GetLength(1)];
            for (int i = 0; i < newDoubleArray.GetLength(0); i++)
                for (int j = 0; j < newDoubleArray.GetLength(1); j++)
                    for (int t = 0; t < arraySize; t++)
                        newDoubleArray[i, j] += array1[i, t] * array2[t, j];
            return newDoubleArray;
        }
    }
}