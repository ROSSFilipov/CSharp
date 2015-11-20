using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    public class Path3D
    {
        private List<Point3D> pointList;

        public Path3D()
        {
            this.PointList = new List<Point3D>();
        }

        public Path3D(params Point3D[] points)
        {
            this.PointList = new List<Point3D>();
            foreach (Point3D item in points)
            {
                this.PointList.Add(item);
            }
        }

        public void AddPoint3D(params Point3D[] points)
        {
            foreach (Point3D item in points)
            {
                this.PointList.Add(item);
            }
        }

        public void AddPoint3D(Point3D point)
        {
            this.PointList.Add(point);
        }

        public List<Point3D> PointList
        {
            get
            {
                return this.pointList;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Point3D item in PointList)
            {
                sb.AppendLine(String.Format("[{0}, {1}, {2}]", item.X, item.Y, item.Z));
            }
            return sb.ToString();
        }
    }
}
