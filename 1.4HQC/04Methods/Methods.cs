using System;
using System.Collections.Generic;

namespace Methods
{
    class Methods
    {
        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToDigit(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumberInGivenFormat(1.3, "f");
            PrintAsNumberInGivenFormat(0.75, "%");
            PrintAsNumberInGivenFormat(2.30, "r");

            bool horizontal = IsVertical(3, -1, 3, 2.5);
            bool vertical = isHorizontal(3, -1, 3, 2.5);
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.Age = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.Age = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }

        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new AggregateException("Sides should be positive.");
            }
            double sqrt = (a + b + c) / 2;
            double area = Math.Sqrt(sqrt * (sqrt - a) * (sqrt - b) * (sqrt - c));
            return area;
        }

        public static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    throw new ArgumentException("Invalid number!");
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new AggregateException("The value cannot be null or 0");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }
            return elements[0];
        }

        public static void PrintAsNumberInGivenFormat(double number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }


        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static bool IsVertical(double x1, double y1, double x2, double y2)
        {
            bool isVertical = (x1 == x2);

            return isVertical;
        }

        public static bool isHorizontal(double x1, double y1, double x2, double y2)
        {
            bool isHorizontal = (y1 == y2);

            return isHorizontal;
        }
    }
}
