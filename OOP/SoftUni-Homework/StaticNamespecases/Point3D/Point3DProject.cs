using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    class Point3DProject
    {
        private static readonly Point3D staringPoint = StartingPoint3D();

        private static Point3D StartingPoint3D()
        {
            return new Point3D(0, 0, 0);
        }

        static void Main(string[] args)
        {
            Point3D one = new Point3D(1, 1, 1);
            Point3D two = new Point3D(2, 4, 8);
            Path3D firstPath = new Path3D();
            firstPath.AddPoint3D(one, two);
            Path3D secondPath = new Path3D(one, two);
            
            Console.WriteLine("{0:F4}", DistanceCalculator.CalculateDistanceBetweenPoints(one, two));

            Console.WriteLine(firstPath);
            Console.WriteLine(secondPath);

            Point3D temp = Point3D.StartingPoint();
        }
    }
}
