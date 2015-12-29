using System;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Exers01
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            BigInteger[] arrayOfIntegers = Regex.Split(input, "\\s+").Where(n => n != "").Select(n => BigInteger.Parse(n)).ToArray();
            var readLine = Console.ReadLine();
            long integer = 0;
            while (readLine != "stop")
            {
                var stringWithNums = readLine.Split(' ');
                var number1 = long.Parse(stringWithNums[0]);
                var operators = stringWithNums[1];
                var number2 = long.Parse(stringWithNums[2]);
                number1 = number1 % arrayOfIntegers.Length;
                integer += number1;
                var position = integer % arrayOfIntegers.Length;
                if (position < 0)
                {
                    position += arrayOfIntegers.Length;
                }
                if (position >= arrayOfIntegers.Length)
                {
                    position -= arrayOfIntegers.Length;
                }
                switch (operators)
                {
                    case "+":
                        if ((arrayOfIntegers[position] + number2) < 0)
                        {
                            arrayOfIntegers[position] = 0;
                        }
                        else arrayOfIntegers[position] = arrayOfIntegers[position] + number2;
                        break;
                    case "-":
                        if (arrayOfIntegers[position] < number2)
                        {
                            arrayOfIntegers[position] = 0;
                        }
                        else arrayOfIntegers[position] = arrayOfIntegers[position] - number2;
                        break;
                    case "*":
                        if ((arrayOfIntegers[position] * number2) < 0)
                        {
                            arrayOfIntegers[position] = 0;
                        }
                        else arrayOfIntegers[position] = arrayOfIntegers[position] * number2;
                        break;
                    case "/":
                        if ((arrayOfIntegers[position] / number2) < 0)
                        {
                            arrayOfIntegers[position] = 0;
                        }
                        else arrayOfIntegers[position] = arrayOfIntegers[position] / number2;
                        break;
                    case "&":
                        if ((arrayOfIntegers[position] & number2) < 0)
                        {
                            arrayOfIntegers[position] = 0;
                        }
                        else arrayOfIntegers[position] = arrayOfIntegers[position] & number2;
                        break;
                    case "|":
                        if ((arrayOfIntegers[position] | number2) < 0)
                        {
                            arrayOfIntegers[position] = 0;
                        }
                        else arrayOfIntegers[position] = arrayOfIntegers[position] | number2;
                        break;
                    case "^":
                        if ((arrayOfIntegers[position] ^ number2) < 0)
                        {
                            arrayOfIntegers[position] = 0;
                        }
                        else arrayOfIntegers[position] = arrayOfIntegers[position] ^ number2;
                        break;
                }
                readLine = Console.ReadLine();
            }
            for (int i = 0; i < arrayOfIntegers.Length; i++)
            {
                if (arrayOfIntegers[i] < 0)
                {
                    arrayOfIntegers[i] = 0;
                }
            }
            Console.WriteLine("[" + string.Join(", ", arrayOfIntegers) + "]");
        }
    }
}