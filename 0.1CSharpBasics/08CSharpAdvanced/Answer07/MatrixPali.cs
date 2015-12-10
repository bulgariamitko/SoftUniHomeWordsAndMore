using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Answer07
{
    class MatrixPali
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] split = input.Split(new char[0]);
            int r = int.Parse(split[0]);
            int c = int.Parse(split[1]);

            string[,] matrix = new string[r, c];

            for (int row = 0; row < r; row++)
            {
                for (int col = 0; col < c; col++)
                {
                    matrix[row, col] = "" + (char)('a' + row) + (char)('a' + col + row) + (char)('a' + row);
                }
            }

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
