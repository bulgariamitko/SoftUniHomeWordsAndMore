namespace FallingRocks
{
    using System;
    using System.Threading;
    public class FallingRocks
    {
        static ulong score;
        static int lives = 3;
        static int[,] field = new int[40, 40];
        static char[] lastLine = new char[field.GetLength(1)];
        static int curPos = 20;
        public static void Draw(int[,] field, char[] lastLine)
        {
            for (int i = 1; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    switch (field[i, j])
                    {
                        case 0: Console.ForegroundColor = ConsoleColor.White; Console.Write(" "); break;
                        case 1: Console.ForegroundColor = ConsoleColor.White; Console.Write("("); break;
                        case 2: Console.ForegroundColor = ConsoleColor.White; Console.Write("0"); break;
                        case 3: Console.ForegroundColor = ConsoleColor.White; Console.Write(")"); break;
                        case 4: Console.ForegroundColor = ConsoleColor.Blue; Console.Write("^"); break;
                        case 5: Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write("@"); break;
                        case 6: Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("*"); break;
                        case 7: Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("&"); break;
                        case 8: Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("+"); break;
                        case 9: Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write("%"); break;
                        case 10: Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("$"); break;
                        case 11: Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write("#"); break;
                        case 12: Console.ForegroundColor = ConsoleColor.Red; Console.Write("!"); break;
                        case 13: Console.ForegroundColor = ConsoleColor.Cyan; Console.Write("."); break;
                        case 14: Console.ForegroundColor = ConsoleColor.Cyan; Console.Write(";"); break;
                        case 15: Console.ForegroundColor = ConsoleColor.Red; Console.Write("-"); break;
                    }
                }
                Console.WriteLine();
            }
            for (int i = 0; i < lastLine.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(lastLine[i]);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (score > 40) Console.WriteLine("                 SCORE: {0}", score - 40);
            else
            {
                Console.WriteLine("                 SCORE: {0}", 0);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                 LIVES: {0}", lives);
        }
        public static void Move(ConsoleKeyInfo? info, char[] lastLine, ref int curPos)
        {
            if (info != null)
            {

                switch (info.Value.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (curPos - 2 >= 0)
                        {
                            lastLine[curPos - 1] = ' ';
                            lastLine[curPos] = ' ';
                            if (curPos + 1 < field.GetLength(1)) lastLine[curPos + 1] = ' ';
                            lastLine[curPos - 2] = '(';
                            lastLine[curPos - 1] = '0';
                            lastLine[curPos] = ')';
                            curPos--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (curPos + 2 < lastLine.Length)
                        {
                            if (curPos - 1 >= 0) lastLine[curPos - 1] = ' ';
                            if (curPos - 2 >= 0) lastLine[curPos - 2] = ' ';
                            lastLine[curPos] = ' ';
                            lastLine[curPos] = '(';
                            lastLine[curPos + 1] = '0';
                            lastLine[curPos + 2] = ')';
                            curPos++;

                        }
                        break;
                    default: break;
                }
            }
        }
        public static void GenerateLine(int[,] field)
        {
            Random r = new Random();
            int numberOfRocks = r.Next(3, 6);
            for (int i = 1; i <= numberOfRocks; i++)
            {
                int numberofRocks = r.Next(1, 3);
                int symbol = r.Next(4, 14);
                if (numberOfRocks == 1) field[0, r.Next(0, field.GetLength(1) - 1)] = symbol;
                else if (numberofRocks == 2)
                {
                    int pos = r.Next(0, field.GetLength(1) - 1);
                    field[0, pos] = symbol;
                    field[0, pos + 1] = symbol;
                }
            }
        }
        public static void FallDown(int[,] field, ref int curPos)
        {
            int[,] copy = new int[field.GetLength(0), field.GetLength(1)];

            for (int i = 1; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    copy[i, j] = field[i - 1, j];
                }
            }
            GenerateLine(copy);
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {

                    field[i, j] = 0;
                }
            }

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = copy[i, j];
                }
            }
        }
        public void TimerProc(object state)
        {
            Timer t = (Timer)state;
            t.Dispose();
            ConsoleKeyInfo? info = Console.ReadKey();
            if (info != null)
            {
                Move(info, lastLine, ref curPos);
            }
        }
        public void StartTimer(int dueTime)
        {
            Timer t = new Timer(new TimerCallback(TimerProc));
            t.Change(dueTime, 0);
        }
        public static void CheckCollision(int[] lastLineOfMatrix, int curPos)
        {
            bool flag = false;
            for (int i = 0; i < lastLineOfMatrix.Length; i++)
            {
                if (lastLineOfMatrix[i] != 0 && (i == curPos - 1 || i == curPos || i == curPos + 1))
                {
                    flag = true; break;
                }
            }
            if (flag)
            {
                if (lives > 0)
                {
                    lives--;
                }
            }
            else
            {
                score++;
            }
        }
        public static void Main()
        {
            FallingRocks inst = new FallingRocks();
            Console.SetWindowSize(35, 35);
            Console.SetBufferSize(35, 35);
            lastLine[curPos - 2] = '(';
            lastLine[curPos - 1] = '0';
            lastLine[curPos] = ')';
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = 0;
                }
            }

            while (lives > 0)
            {
                Console.Clear();
                int[] lastFalling = new int[field.GetLength(1)];
                for (int i = 0; i < field.GetLength(1); i++)
                {
                    lastFalling[i] = field[field.GetLength(0) - 1, i];
                }
                CheckCollision(lastFalling, curPos);
                FallDown(field, ref curPos);
                Draw(field, lastLine);
                inst.StartTimer(50);
                Thread.Sleep(150);
            }
            Console.WriteLine("                 GAME OVER!");
            Thread.Sleep(10000);
        }
    }
}