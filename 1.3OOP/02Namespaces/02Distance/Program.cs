using System;

namespace Euclidian
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D pointA = new Point3D(22, -13.5, 54.4);
            Point3D pointB = new Point3D(-0.6, -44.5, 22.2);

            double distance = DistanceCalculator3D.CalculateDistanceBetweenTwoPoints(pointA, pointB);

            Console.WriteLine("{0:F2}", distance);
        }
    }
}
