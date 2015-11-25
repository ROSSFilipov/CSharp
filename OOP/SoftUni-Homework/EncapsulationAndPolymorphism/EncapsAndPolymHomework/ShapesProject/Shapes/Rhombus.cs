using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject.Shapes
{
    public class Rhombus : BasicShape
    {
        public Rhombus(int width, int height)
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
            double result = 4 * this.Width;
            return result;
        }
    }
}
