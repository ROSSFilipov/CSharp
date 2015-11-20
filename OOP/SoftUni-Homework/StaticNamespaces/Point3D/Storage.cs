using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    public static class Storage
    {
        public static Path3D LoadPath(string fileName)
        {
            Path3D data = new Path3D();
            StreamReader reader = new StreamReader(fileName);

            using (reader)
            {
                string currentLine = reader.ReadLine();

                while (currentLine != null)
                {
                    string[] currentPoint = currentLine.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                    Point3D point = new Point3D(int.Parse(currentPoint[0]), int.Parse(currentPoint[1]), int.Parse(currentPoint[2]));
                    data.AddPoint3D(point);
                    currentLine = reader.ReadLine();
                }
            }

            return data;
        }

        public static void SavePath(string fileName, Path3D currentPath)
        {
            StreamWriter writer = new StreamWriter(fileName);

            using (writer)
            {
                foreach (Point3D point in currentPath.PointList)
                {
                    writer.WriteLine(point.X + " " + point.Y + " " + point.Z);
                }
            }
        }
    }
}
