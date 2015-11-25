using ShapesProject.Interfaces;
using ShapesProject.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesProject
{
    class ShapesProject
    {
        static void Main(string[] args)
        {
            List<IShape> shapesData = new List<IShape>();
            shapesData.Add(new Rhombus(8, 9));
            shapesData.Add(new Rectangle(2, 5));
            shapesData.Add(new Circle(7));

            foreach (IShape currentShape in shapesData)
            {
                Console.WriteLine(currentShape);
                Console.WriteLine();
            }
        }
    }
}
