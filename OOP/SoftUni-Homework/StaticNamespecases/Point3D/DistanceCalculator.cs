using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    public static class DistanceCalculator
    {
        public static double CalculateDistanceBetweenPoints(Point3D one, Point3D two)
        {
            double result = Math.Sqrt(Math.Pow(one.X - two.X, 2) + Math.Pow(one.Y - two.Y, 2) + Math.Pow(one.Z - two.Z, 2));
            return result;
        }
    }
}
