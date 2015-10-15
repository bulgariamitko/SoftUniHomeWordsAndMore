using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nAndM = Console.ReadLine().Split(' ').Select(p => int.Parse(p)).ToArray();
            int[,] matrix = new int[nAndM[0], nAndM[1]];

            List<int> lineOne = Console.ReadLine().Split(' ').Select(p => int.Parse(p)).ToList();
            List<int> lineTwo = Console.ReadLine().Split(' ').Select(p => int.Parse(p)).ToList();
            List<int> lineThree = Console.ReadLine().Split(' ').Select(p => int.Parse(p)).ToList();
            List<int> lineFour = Console.ReadLine().Split(' ').Select(p => int.Parse(p)).ToList();

            // only for checking...
            // List<int> lineOne = new List<int>() { 1, 5, 5, 2, 4 };
            // List<int> lineTwo = new List<int>() { 2, 1, 4, 14, 3 };
            // List<int> lineThree = new List<int>() { 3, 7, 11, 2, 8 };
            // List<int> lineFour = new List<int>() { 4, 8, 12, 16, 4 };

            List<int> allNumbers = new List<int>();
            allNumbers.AddRange(lineOne);
            allNumbers.AddRange(lineTwo);
            allNumbers.AddRange(lineThree);
            allNumbers.AddRange(lineFour);

            int i = 0;

            for (int cols = 0; cols < matrix.GetLength(0); cols++)
            {
                for (int rows = 0; rows < matrix.GetLength(1); rows++)
                {
                    matrix[cols, rows] = allNumbers[i];
                    i++;
                }
            }
            Console.WriteLine("\n");
            PrintMatrix(matrix);

            Console.WriteLine();
            CalMatrixPlatform(matrix);
        }

        static void PrintMatrix(int[,] filledMatrix)
        {
            for (int row = 0; row < filledMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < filledMatrix.GetLength(1); col++)
                {
                    Console.Write(filledMatrix[row, col] + " ");
                }
                Console.Write(Environment.NewLine);
            }

            Console.WriteLine();
        }

        static void CalMatrixPlatform(int[,] filledMatrix, int calRows = 3, int calCols = 3)
        {
            // Find the maximal sum platform of size 2 x 2
            int bestSum = int.MinValue;
            int bestRow = 0;
            int bestCol = 0;
            for (int row = 0; row < filledMatrix.GetLength(0) - calRows + 1; row++)
            {
                for (int col = 0; col < filledMatrix.GetLength(1) - calCols + 1; col++)
                {
                    int sum = filledMatrix[row, col] + filledMatrix[row, col + 1] + filledMatrix[row + 1, col] + filledMatrix[row, col + 2] + filledMatrix[row + 2, col] + filledMatrix[row + 2, col + 1] + filledMatrix[row + 1, col + 2] + filledMatrix[row + 1, col + 1] + filledMatrix[row + 2, col + 2];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            // Print the result
            Console.WriteLine("The maximal sum is: {0}", bestSum);
            Console.WriteLine("  {0} {1} {2}", filledMatrix[bestRow, bestCol], filledMatrix[bestRow, bestCol + 1], filledMatrix[bestRow, bestCol + 2]);
            Console.WriteLine("  {0} {1} {2}", filledMatrix[bestRow + 1, bestCol], filledMatrix[bestRow + 1, bestCol + 1], filledMatrix[bestRow + 1, bestCol + 2]);
            Console.WriteLine("  {0} {1} {2}", filledMatrix[bestRow + 2, bestCol], filledMatrix[bestRow + 2, bestCol + 1], filledMatrix[bestRow + 2, bestCol + 2]);
            
        }
    }
}
