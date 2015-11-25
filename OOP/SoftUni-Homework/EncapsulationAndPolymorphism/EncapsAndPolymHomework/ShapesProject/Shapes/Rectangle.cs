using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject.Shapes
{
    public class Rectangle : BasicShape
    {
        public Rectangle(int width, int height)
            : base(width, height)
        {

        }

        public override double CalculateArea()
        {
            double result = this.Width * this.Heigh;
            return result;
        }

        public override double CalculatePerimeter()
        {
            double result = 2 * this.Width + 2 * this.Heigh;
            return result;
        }
    }
}
