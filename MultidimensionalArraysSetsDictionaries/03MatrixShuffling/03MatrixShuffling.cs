using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixRows = int.Parse(Console.ReadLine());
            int matrixCols = int.Parse(Console.ReadLine());

            string[,] matrix = new string[matrixRows, matrixCols];

            for (int rows = 0; rows < matrixRows; rows++)
            {
                for (int cols = 0; cols < matrixCols; cols++)
                {
                    matrix[rows, cols] = Console.ReadLine();
                }
            }

            while (true)
            {
                List<string> input = Console.ReadLine().Split(' ').ToList();
                if (input[0] == "swap")
                {
                    if ((int.Parse(input[1]) < matrixRows && int.Parse(input[3]) < matrixRows) && (int.Parse(input[2]) < matrixCols && int.Parse(input[4]) < matrixCols))
                    {
                        string swapFrom = matrix[int.Parse(input[1]), int.Parse(input[2])];
                        string swapTo = matrix[int.Parse(input[3]), int.Parse(input[4])];
                        // swaping
                        matrix[int.Parse(input[1]), int.Parse(input[2])] = swapTo;
                        matrix[int.Parse(input[3]), int.Parse(input[4])] = swapFrom;

                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                if (input[0] == "END")
                {
                    break;
                }
            }
        }

        static void PrintMatrix(string[,] filledMatrix)
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
    }
}
