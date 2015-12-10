using System;

namespace Euclidian
{
    public static class DistanceCalculator3D
    {
        public static double CalculateDistanceBetweenTwoPoints(Point3D point1, Point3D point2)
        {
            double dist = Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2) + Math.Pow(point1.Z - point2.Z, 2));
            return dist;
        }
    }
}