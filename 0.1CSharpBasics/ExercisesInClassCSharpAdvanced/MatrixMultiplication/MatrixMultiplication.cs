using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplication
{
    class MatrixMultiplication
    {
        static void Main(string[] args)
        {
            int[,] matrix1 =
            {
                { 1, 2 },
                { 3, 4 }
            };

            int[,] matrix2 =
            {
                { 3, 1 },
                { 2, 2 }
            };

            // Multiply the first matrix with the second matrix
            int firstRows = matrix1.GetLength(0);
            int firstCols = matrix1.GetLength(1);
            int secondRows = matrix2.GetLength(0);
            int secondCols = matrix2.GetLength(1);

            if (firstCols != secondRows)
            {
                throw new ArgumentException("Invalid dimensions!");
            }

            int[,] newMatrix = new int[firstRows, secondRows];
            for (int row = 0; row < firstRows; row++)
            {
                for (int col = 0; col < secondRows; col++)
                {
                    newMatrix[row, col] = 0;
                    for (int i = 0; i < firstCols; i++)
                    {
                        newMatrix[row, col] += matrix1[row, i] * matrix2[i, col];
                    }
                }
            }
        }
    }
}