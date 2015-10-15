using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05CollectCoins
{
    class Program
    {
        // only for testing
        // static string lineOne = "Sj0u$hbc";
        // static string lineTwo = "$87yihc87";
        // static string lineThree = "Ewg3444";
        // static string lineFour = "$4$$";

        static string lineOne = Console.ReadLine();
        static char[] arrayZero = lineOne.ToCharArray();
        static string lineTwo = Console.ReadLine();
        static char[] arrayOne = lineTwo.ToCharArray();
        static string lineThree = Console.ReadLine();
        static char[] arrayTwo = lineThree.ToCharArray();
        static string lineFour = Console.ReadLine();
        static char[] arrayThree = lineFour.ToCharArray();

        static int walls = 0;
        static int coins = 0;

        static void Main(string[] args)
        {
            
            string instructions = Console.ReadLine();
            char[] arrayInstructions = instructions.ToCharArray();

            int row = 0;
            int col = 0;

            foreach (var item in arrayInstructions)
            {
                if (item == 'V')
                {
                    // Console.Write("Go down: ");
                    row++;
                    Position(row, col);
                    if (row < 0)
                    {
                        // Console.Write("You hit a wall! (Up or down)");
                        row = 0;
                        walls++;
                    }
                    else if (row > 3)
                    {
                        // Console.Write("You hit a wall! (Up or down)");
                        row = 3;
                        walls++;
                    }
                }
                else if (item == '>')
                {
                    // Console.Write("Go right: ");
                    col++;
                    Position(row, col);
                    if (row < 0)
                    {
                        // Console.Write("You hit a wall! (Up or down)");
                        row = 0;
                        walls++;
                    }
                    else if (row > 3)
                    {
                        // Console.Write("You hit a wall! (Up or down)");
                        row = 3;
                        walls++;
                    }
                }
                else if (item == '<')
                {
                    // Console.Write("Go left: ");
                    col--;
                    Position(row, col);
                    if (row < 0)
                    {
                        // Console.Write("You hit a wall! (Up or down)");
                        row = 0;
                        walls++;
                    }
                    else if (row > 3)
                    {
                        // Console.Write("You hit a wall! (Up or down)");
                        row = 3;
                        walls++;
                    }
                }
                else if (item == '^')
                {
                    // Console.Write("Go up: ");
                    row--;
                    Position(row, col);
                    if (row < 0)
                    {
                        // Console.Write("You hit a wall! (Up or down)");
                        row = 0;
                        walls++;
                    }
                    else if (row > 3)
                    {
                        // Console.Write("You hit a wall! (Up or down)");
                        row = 3;
                        walls++;
                    }
                }
                else
                {
                    Console.WriteLine("Something went wrong! Error 333!");
                }
            }

            Console.WriteLine("Coins collected: {0}", coins);
            Console.WriteLine("Walls hit: {0}", walls);
        }

        static void Position(int row, int col)
        {
            if (row < 0)
            {
                row = 0;
            }
            else if (row > 3)
            {
                row = 3;
            }

            if (row == 0)
            {
                if (col > arrayZero.Length)
                {
                    row = 0;
                    walls++;
                }
                // Console.Write(" Row: " + row + " Symbol: ");
                // Console.Write(arrayZero[col]);
                // Console.WriteLine();
                if (arrayZero[col] == '$')
                {
                    coins++;
                }
            }
            else if (row == 1)
            {
                if (col > arrayOne.Length)
                {
                    row = 0;
                    walls++;
                }
                // Console.Write(" Row: " + row + " Symbol: ");
                // Console.Write(arrayOne[col]);
                // Console.WriteLine();
                if (arrayZero[col] == '$')
                {
                    coins++;
                }
            }
            else if (row == 2)
            {
                if (col > arrayTwo.Length)
                {
                    row = 0;
                    walls++;
                }
                // Console.Write(" Row: " + row + " Symbol: ");
                // Console.Write(arrayTwo[col]);
                // Console.WriteLine();
                if (arrayZero[col] == '$')
                {
                    coins++;
                }
            }
            else if (row == 3)
            {
                if (col > arrayThree.Length)
                {
                    row = 0;
                    walls++;
                }
                // Console.Write(" Row: " + row + " Symbol: ");
                // Console.Write(arrayThree[col]);
                // Console.WriteLine();
                if (arrayZero[col] == '$')
                {
                    coins++;
                }
            }
            else
            {
                Console.Write("Something went wrong! Error 545!");
            }
        }
    }
}
