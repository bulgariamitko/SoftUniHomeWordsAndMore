using System;

namespace Answer06
{
    class QuadraticEquation
    {
        static void Main()
        {
            Console.WriteLine("Pease, use COMMA and not a dot!!!");
            float a = float.Parse(Console.ReadLine());
            float b = float.Parse(Console.ReadLine());
            float c = float.Parse(Console.ReadLine());

            double discriminant = (b * b) - (4 * a * c);
            if (discriminant > 0)
            {
                double x2 = ((-b) + Math.Sqrt(discriminant)) / (2 * a);
                double x1 = ((-b) - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine("x1 = {0}; x2 = {1}", x1, x2);
            }
            else if (discriminant == 0)
            {
                double x1Andx2 = ((-b) + Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine("x1 = x2 = {0}", x1Andx2);
            }
            else if (discriminant < 0)
            {
                Console.WriteLine("No real roots");
            }
        }
    }
}
