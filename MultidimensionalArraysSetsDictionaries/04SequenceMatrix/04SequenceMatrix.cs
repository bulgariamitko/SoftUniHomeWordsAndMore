using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceInMatrix
{
    class SequenceInMatrix
    {
        static List<string> final = new List<string>();

        static void Main(string[] args)
        {
            Console.Write("Enter number of rows: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter number of cols: ");
            int m = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, m];

            FillMatrix(matrix);
            MatrixHorizontal(matrix);
            MatrixVertical(matrix);
            MatrixDiagonal(matrix);
            Console.WriteLine(String.Join(", ", final));
        }

        private static void MatrixDiagonal(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                List<string> tempList = new List<string>();
                tempList.Add(matrix[0, i]);
                for (int j1 = i + 1, j2 = i + 1; j1 < matrix.GetLength(0); j1++, j2++)
                {
                    if (matrix[j1, j2] == matrix[j1 - 1, j2 - 1])
                    {
                        tempList.Add(matrix[j1, j2]);
                        if (j1 == matrix.GetLength(0) - 1)
                        {
                            if (tempList.Count > final.Count)
                            {
                                final.Clear();
                                foreach (var item in tempList)
                                {
                                    final.Add(item);
                                }
                                tempList.Clear();
                                tempList.Add(matrix[j1, j2]);
                            }
                            else
                            {
                                tempList.Clear();
                                tempList.Add(matrix[j1, j2]);
                            }
                        }
                    }
                    else
                    {
                        if (tempList.Count > final.Count)
                        {
                            final.Clear();
                            foreach (var item in tempList)
                            {
                                final.Add(item);
                            }
                            tempList.Clear();
                            tempList.Add(matrix[j1, j2]);
                        }
                        else
                        {
                            tempList.Clear();
                            tempList.Add(matrix[j1, j2]);
                        }
                    }
                }
            }
        }

        private static void MatrixVertical(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                List<string> tempList = new List<string>();
                tempList.Add(matrix[0, i]);
                for (int j = 1; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] == matrix[j - 1, i])
                    {
                        tempList.Add(matrix[j, i]);
                        if (j == matrix.GetLength(0) - 1)
                        {
                            if (tempList.Count > final.Count)
                            {
                                final.Clear();
                                foreach (var item in tempList)
                                {
                                    final.Add(item);
                                }
                                tempList.Clear();
                                tempList.Add(matrix[j, i]);
                            }
                            else
                            {
                                tempList.Clear();
                                tempList.Add(matrix[j, i]);
                            }
                        }
                    }
                    else
                    {
                        if (tempList.Count > final.Count)
                        {
                            final.Clear();
                            foreach (var item in tempList)
                            {
                                final.Add(item);
                            }
                            tempList.Clear();
                            tempList.Add(matrix[j, i]);
                        }
                        else
                        {
                            tempList.Clear();
                            tempList.Add(matrix[j, i]);
                        }
                    }
                }
            }
        }

        private static void MatrixHorizontal(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                List<string> tempList = new List<string>();
                tempList.Add(matrix[i, 0]);
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == matrix[i, j - 1])
                    {
                        tempList.Add(matrix[i, j]);
                        if (j == matrix.GetLength(1) - 1)
                        {
                            if (tempList.Count > final.Count)
                            {
                                final.Clear();
                                foreach (var item in tempList)
                                {
                                    final.Add(item);
                                }
                                tempList.Clear();
                                tempList.Add(matrix[i, j]);
                            }
                            else
                            {
                                tempList.Clear();
                                tempList.Add(matrix[i, j]);
                            }
                        }
                    }
                    else
                    {
                        if (tempList.Count > final.Count)
                        {
                            final.Clear();
                            foreach (var item in tempList)
                            {
                                final.Add(item);
                            }
                            tempList.Clear();
                            tempList.Add(matrix[i, j]);
                        }
                        else
                        {
                            tempList.Clear();
                            tempList.Add(matrix[i, j]);
                        }
                    }
                }
            }
        }

        private static void FillMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("Enter string value: ");
                    matrix[i, j] = Console.ReadLine();
                }
            }
        }
    }
}