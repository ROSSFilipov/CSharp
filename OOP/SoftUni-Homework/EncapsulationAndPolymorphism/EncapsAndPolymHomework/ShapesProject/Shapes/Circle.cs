using ShapesProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject.Shapes
{
    public class Circle : IShape
    {
        private int radius;

        public Circle(int radius)
        {
            this.Radius = radius;
        }

        public int Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Radius cannot be negative!");
                }

                this.radius = value;
            }
        }

        public double CalculateArea()
        {
            double result = Math.PI * this.Radius * this.Radius;
            return result;
        }

        public double CalculatePerimeter()
        {
            double result = 2 * Math.PI * this.Radius;
            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}, radius: {1}, area: {2:F2}, perimeter: {3:F2}",
                this.GetType().Name, this.Radius, this.CalculateArea(), this.CalculatePerimeter());
        }
    }
}
