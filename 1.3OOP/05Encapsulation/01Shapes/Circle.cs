using System;
using _01Shapes.Interfaces;

namespace _01Shapes
{
    public class Circle : IShape
    {
        private double radius;

        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI*Radius*Radius;
        }

        public double CalculatePerimeter()
        {
            return 2*Math.PI*Radius;
        }
    }
}