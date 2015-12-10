using System;
using _01Shapes.Interfaces;

namespace _01Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapes =
            {
                new Circle(4.55),
                new Rectangle(1.5, 5.7),
                new Rhombus(2.4, 4.4)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("Shape: {0}, Area: {1:F2}, Perimeter: {2:F2}", shape.GetType().Name, shape.CalculateArea(), shape.CalculatePerimeter());
            }
        }
    }
}
