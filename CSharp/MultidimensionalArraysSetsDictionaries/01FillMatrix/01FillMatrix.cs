using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01FillMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintMatrix(FillMatrixA(4));
            PrintMatrix(FillMatrixB(4));
        }

        static int[,] FillMatrixA(int n)
        {
            int[,] matrixA = new int[n, n];
            int counter = 1;

            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    matrixA[col, row] = counter;
                    counter++;
                }
            }
            return matrixA;
        }

        static int[,] FillMatrixB(int n)
        {
            int[,] matrixB = new int[n, n];

            int counterEven = 0;
            int multiplyNBy = 1;
            int counterOdd = n * 2;

            for (int col = 0; col < n; col++)
            {
                if (col % 2 != 0)
                {
                    counterEven = counterOdd;
                }

                for (int row = 0; row < n; row++)
                {
                    if ((col == 0) || (col % 2 == 0))
                    {
                        counterEven++;
                        matrixB[col, row] = counterEven;
                    }
                    else
                    {
                        matrixB[col, row] = counterOdd;
                        counterOdd--;
                    }
                }
                multiplyNBy++;
                counterOdd = n * multiplyNBy;
            }

            return matrixB;
        }

        static void PrintMatrix(int[,] filledMatrix)
        {
            for (int row = 0; row < filledMatrix.GetLength(1); row++)
            {
                for (int col = 0; col < filledMatrix.GetLength(0); col++)
                {
                    Console.Write(filledMatrix[col, row] + " ");
                }
                Console.Write(Environment.NewLine);
            }

            Console.WriteLine();
        }
    }
}
