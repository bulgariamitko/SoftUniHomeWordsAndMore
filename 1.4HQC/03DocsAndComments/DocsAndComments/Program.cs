// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="SoftUni">
//   Copyright to SoftUni
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DocsAndComments
{
    using System;
    using System.Linq;

    /// <summary>
    /// The program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] field = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] values = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = values[j];
                }
            }

            string command = Console.ReadLine();
            while (command != "cease fire!")
            {
                var commandArgs = command.Split();
                int row = int.Parse(commandArgs[0]);
                int col = int.Parse(commandArgs[1]);
                int damage = char.Parse(commandArgs[2]);

                DoTheDamege(field, damage, row, col);

                command = Console.ReadLine();
            }

            int destroyCells = CountDestroyedCells(field);
            int totalCells = rows * cols;
            double precentage = (destroyCells / (double) totalCells) * 100;

            Console.WriteLine("Destroyed bunkers: " + destroyCells);
            Console.WriteLine("Damage done: {0:F1} %", precentage);
        }

        /// <summary>
        /// The count destroyed cells.
        /// </summary>
        /// <param name="field">
        /// The field.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private static int CountDestroyedCells(int[,] field)
        {
            int counter = 0;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] <= 0)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        /// <summary>
        /// The do the damege.
        /// </summary>
        /// <param name="field">
        /// The field.
        /// </param>
        /// <param name="damage">
        /// The damage.
        /// </param>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="col">
        /// The col.
        /// </param>
        private static void DoTheDamege(int[,] field, int damage, int row, int col)
        {
            int halfDamage = (int)Math.Ceiling(damage / 2.0);
            int startRow = Math.Max(0, row - 1);
            int endRow = Math.Min(field.GetLength(0) - 1, row + 1);
            int startCol = Math.Max(0, col - 1);
            int endCol = Math.Min(field.GetLength(1) - 1, col + 1);

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j <= endCol; j++)
                {
                    if (i == row && j == col)
                    {
                        field[i, j] -= damage;
                    }
                    else
                    {
                        field[i, j] -= halfDamage;
                    }
                }
            }
        }
    }
}