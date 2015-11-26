using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Models
{
    public abstract class Estate : IEstate
    {
        private const double AreaMinValue = 0;
        private const double AreaMaxValue = 10000;

        private string name;
        private EstateType type;
        private double area;
        private string location;
        private bool isFurnished;

        protected Estate(string name, EstateType type, double area, string location, bool isFurnished)
        {
            this.Name = name;
            this.Type = type;
            this.Area = area;
            this.Location = location;
            this.IsFurnished = isFurnished;
        }

        protected Estate(EstateType type)
        {
            this.Type = type;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name!");
                }

                this.name = value;
            }
        }

        public EstateType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public double Area
        {
            get
            {
                return this.area;
            }
            set
            {
                if (value < AreaMinValue || value > AreaMaxValue)
                {
                    throw new ArgumentOutOfRangeException("Area cannot be negative!");
                }

                this.area = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid location!");
                }

                this.location = value;
            }
        }

        public bool IsFurnished
        {
            get
            {
                return this.isFurnished;
            }
            set
            {
                this.isFurnished = value;
            }
        }
    }
}
