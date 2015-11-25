using ShapesProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject.Shapes
{
    public abstract class BasicShape : IShape
    {
        private int width;
        private int height;

        protected BasicShape(int width, int height)
        {
            this.Width = width;
            this.Heigh = height;
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Shape's width cannot be negative!");
                }

                this.width = value;
            }
        }

        public int Heigh
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Shape's height cannot be negative!");
                }

                this.height = value;
            }
        }

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();

        public override string ToString()
        {
            return string.Format("{0}, width: {1}, height: {2}, area: {3}, perimeter: {4}", 
                this.GetType().Name, this.Width, this.Heigh, this.CalculateArea(), this.CalculatePerimeter());
        }
    }
}
