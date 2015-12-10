using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclidian
{
    class Program
    {
        static void Main(string[] args)
        {
            Path3D myPath3D = new Path3D(new Point3D(-5, 55, 444), new Point3D(44, -5, 77), new Point3D(10, 20, 30), new Point3D(47, 74, -4));

            myPath3D.AddPoint(new Point3D(21, 45, -4));
            myPath3D.AddPoint(new Point3D(-5, -7, -55));
            myPath3D.AddPoint(new Point3D(45, 54, 77));

            Storage.SavePath(myPath3D);

            Path3D newPath3D = Storage.LoadPath3D("ExistPath.txt");
        }
    }
}
