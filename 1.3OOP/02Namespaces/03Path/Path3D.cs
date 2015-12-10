using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclidian
{
    public class Path3D
    {
        private List<Point3D> path = new List<Point3D>();

        public List<Point3D> Path
        {
            get { return path; }
            set { path = value; }
        }

        public Path3D(params Point3D[] points)
        {
            if (points != null && points.Length > 0)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    this.Path.Add(points[i]);
                }
            }
        }

        public void AddPoint(Point3D point)
        {
            this.path.Add(point);
        }
    }
}
