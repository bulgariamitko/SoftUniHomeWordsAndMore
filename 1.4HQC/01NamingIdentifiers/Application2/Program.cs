using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Minesweeper
    {
        private static void Main()
        {
            const int Max = 35;

            string command;
            char[,] field = CreateField();
            char[,] mines = BombPlacing();
            int score = 0;
            bool die = false;
            List<Scoring> championship = new List<Scoring>(6);
            int row = 0;
            int col = 0;
            bool flag = true;
            bool flag2 = false;
            string message =
                "Let's play Minesweeper. Try to find the fields without mines. If you write 'top' you will see the scoring, 'restart' will resent and start a new game and 'exit' will exit the game!";

            do
            {
                if (flag)
                {
                    Console.WriteLine(message);
                    CreateTheBoard(field);
                    flag = false;
                }

                Console.Write("Enter row and colon: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col)
                        && row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Scoreboard(championship);
                        break;
                    case "restart":
                        field = CreateField();
                        mines = BombPlacing();
                        CreateTheBoard(field);
                        break;
                    case "exit":
                        Console.WriteLine("exiting...");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                ATurn(field, mines, row, col);
                                score++;
                            }

                            if (Max == score)
                            {
                                flag2 = true;
                            }
                            else
                            {
                                CreateTheBoard(field);
                            }
                        }
                        else
                        {
                            die = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Unknow command\n");
                        break;
                }

                if (die)
                {
                    CreateTheBoard(mines);
                    Console.Write("\nHrrrrrr! You are dead with a score of {0} points. Write your nickname: ", score);
                    string nickname = Console.ReadLine();
                    Scoring finalScore = new Scoring(nickname, score);
                    if (championship.Count < 5)
                    {
                        championship.Add(finalScore);
                    }
                    else
                    {
                        for (int i = 0; i < championship.Count; i++)
                        {
                            if (championship[i].Score < finalScore.Score)
                            {
                                championship.Insert(i, finalScore);
                                championship.RemoveAt(championship.Count - 1);
                                break;
                            }
                        }
                    }

                    championship.Sort((Scoring scoring1, Scoring scoring2) => string.Compare(scoring2.Name, scoring1.Name, StringComparison.Ordinal));
                    championship.Sort((Scoring scoring1, Scoring scoring2) => scoring2.Score.CompareTo(scoring1.Score));
                    Scoreboard(championship);

                    field = CreateField();
                    mines = BombPlacing();
                    score = 0;
                    die = false;
                    flag = true;
                }

                if (flag2)
                {
                    Console.WriteLine("\nYOU WON! You have found all 35 fields without a mine.");
                    CreateTheBoard(mines);
                    Console.WriteLine("Write your nickname: ");
                    string nickname = Console.ReadLine();
                    Scoring finalScore = new Scoring(nickname, score);
                    championship.Add(finalScore);
                    Scoreboard(championship);
                    field = CreateField();
                    mines = BombPlacing();
                    score = 0;
                    flag2 = false;
                    flag = true;
                }
            }
            while (command != "exit");
            Console.Read();
        }

        private static void Scoreboard(List<Scoring> scoring)
        {
            Console.WriteLine("Score:");
            if (scoring.Count > 0)
            {
                for (int i = 0; i < scoring.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} fields", i + 1, scoring[i].Name, scoring[i].Score);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No entry, yet!\n");
            }
        }

        private static void ATurn(char[,] field, char[,] mines, int row, int col)
        {
            char minesCount = MinesCount(mines, row, col);
            mines[row, col] = minesCount;
            field[row, col] = minesCount;
        }

        private static void CreateTheBoard(char[,] board)
        {
            int lengthRows = board.GetLength(0);
            int lengthCols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < lengthRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < lengthCols; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] BombPlacing()
        {
            int rows = 5;
            int cols = 10;
            char[,] playField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playField[i, j] = '-';
                }
            }

            List<int> listOfIntegers = new List<int>();
            while (listOfIntegers.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!listOfIntegers.Contains(randomNumber))
                {
                    listOfIntegers.Add(randomNumber);
                }
            }

            foreach (int i in listOfIntegers)
            {
                int colons = i / cols;
                int rowling = i % cols;
                if (rowling == 0 && i != 0)
                {
                    colons--;
                    rowling = cols;
                }
                else
                {
                    rowling++;
                }

                playField[colons, rowling - 1] = '*';
            }

            return playField;
        }

//        private static void smetki(char[,] pole)
//        {
//            int kol = pole.GetLength(0);
//            int red = pole.GetLength(1);
//
//            for (int i = 0; i < kol; i++)
//            {
//                for (int j = 0; j < red; j++)
//                {
//                    if (pole[i, j] != '*')
//                    {
//                        char kolkoo = kolko(pole, i, j);
//                        pole[i, j] = kolkoo;
//                    }
//                }
//            }
//        }

        private static char MinesCount(char[,] r, int num1, int num2)
        {
            int count = 0;
            int lengthRows = r.GetLength(0);
            int lengthCols = r.GetLength(1);

            if (num1 - 1 >= 0)
            {
                if (r[num1 - 1, num2] == '*')
                {
                    count++;
                }
            }

            if (num1 + 1 < lengthRows)
            {
                if (r[num1 + 1, num2] == '*')
                {
                    count++;
                }
            }

            if (num2 - 1 >= 0)
            {
                if (r[num1, num2 - 1] == '*')
                {
                    count++;
                }
            }

            if (num2 + 1 < lengthCols)
            {
                if (r[num1, num2 + 1] == '*')
                {
                    count++;
                }
            }

            if ((num1 - 1 >= 0) && (num2 - 1 >= 0))
            {
                if (r[num1 - 1, num2 - 1] == '*')
                {
                    count++;
                }
            }

            if ((num1 - 1 >= 0) && (num2 + 1 < lengthCols))
            {
                if (r[num1 - 1, num2 + 1] == '*')
                {
                    count++;
                }
            }

            if ((num1 + 1 < lengthRows) && (num2 - 1 >= 0))
            {
                if (r[num1 + 1, num2 - 1] == '*')
                {
                    count++;
                }
            }

            if ((num1 + 1 < lengthRows) && (num2 + 1 < lengthCols))
            {
                if (r[num1 + 1, num2 + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}