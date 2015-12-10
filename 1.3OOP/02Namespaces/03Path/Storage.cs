using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclidian
{
    public static class Storage
    {
        public static Path3D LoadPath3D(string fileName)
        {
            Path3D path = new Path3D();
            string fileNamePath = string.Format("{0}{1}", "../../", fileName);

            if (File.Exists(fileNamePath))
            {
                using (var reader = new StreamReader(fileNamePath))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        double[] coordinates =
                            line.Split(new char[] {'{', '}', ',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                                .Select(double.Parse)
                                .ToArray();
                        path.AddPoint(new Point3D(coordinates[0], coordinates[1], coordinates[2]));
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("The source file not found.");
                path = null;
            }
            return path;
        }

        public static void SavePath(Path3D path)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            using (var writer = new StreamWriter("../../NewPath.txt"))
            {
                foreach (var point in path.Path)
                {
                    writer.WriteLine(point);
                }
            }
        }
    }
}
