using System;
using System.Threading;

namespace Euclidian
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Console.WriteLine(Point3D.StartingPoint);

            Point3D pd = new Point3D(1.2, 4.4, -5.5);
            Console.WriteLine(pd.ToString());
        }
    }
}
