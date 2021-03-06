﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namespaces.Geometry.Geometry3D
{
    public class Point3D
    {
        private int x;

        private int y;

        private int z;

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public int Z
        {
            get
            {
                return this.z;
            }
            set
            {
                this.z = value;
            }
        }

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Point3D() : this(0, 0, 0)
        {

        }

        public override string ToString()
        {
            return String.Format("[{0}, {1}, {2}]", this.X, this.Y, this.Z);
        }
    }
}
