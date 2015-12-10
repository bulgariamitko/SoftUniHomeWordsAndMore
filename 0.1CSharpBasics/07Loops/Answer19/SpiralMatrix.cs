using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer19
{
    class SpiralMatrix
    {
        static void Main(string[] args)
        {
            System.Console.SetWindowSize(100, 30);
            int n = int.Parse(Console.ReadLine());
            Console.Clear();
            int[,] matrix = new int[n, n];
            int row = 0;
            int col = 0;
            int value = 1;

            if (1 <= n && n <= 20)
            {
                while (value <= n * n)
                {
                    while (col < matrix.GetLength(0) && matrix[col, row] == 0)
                    {
                        matrix[row, col++] = value;
                        value++;
                    }
                    col--;
                    row++;
                    while (row < matrix.GetLength(1) && matrix[row, col] == 0)
                    {
                        matrix[row++, col] = value;
                        value++;
                    }
                    row--;
                    col--;
                    while (col >= 0 && matrix[row, col] == 0)
                    {
                        matrix[row, col--] = value;
                        value++;
                    }
                    col++;
                    row--;
                    while (row >= 0 && matrix[row, col] == 0)
                    {
                        matrix[row--, col] = value;
                        value++;
                    }
                    col++;
                    row++;
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.SetCursorPosition(j * 5, i * 2);
                        Console.Write(matrix[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("The number is out of range!");
            }
        }
    }
}
