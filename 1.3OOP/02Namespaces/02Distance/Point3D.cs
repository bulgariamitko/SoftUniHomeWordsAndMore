namespace Euclidian
{
    public class Point3D
    {
        public static readonly Point3D StartingPoint = new Point3D(0, 0, 0);
        private double x;
        private double y;
        private double z;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return string.Format("Cordinate x: {0}, y: {1}, z: {2}", x, y, z);
        }
    }
}
