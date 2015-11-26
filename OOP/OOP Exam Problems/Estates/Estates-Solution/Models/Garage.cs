using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Models
{
    public class Garage : Estate, IGarage
    {
        private const int GarageWidthMinValue = 0;
        private const int GarageWidthMaxValue = 500;
        private const int GarageHeightMinValue = 0;
        private const int GarageHeightMaxValue = 500;

        private int width;
        private int height;

        public Garage(string name, EstateType type, double area, string location, bool isFurnished, int width, int height)
            : base(name, type, area, location, isFurnished)
        {
            this.Width = width;
            this.Height = height;
        }

        public Garage(EstateType type)
            : base(type)
        {

        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value < GarageWidthMinValue || value > GarageWidthMaxValue)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Garage's width must be in the range [{0}...{1}].",
                        GarageWidthMinValue, GarageWidthMaxValue));
                }

                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value < GarageHeightMinValue || value > GarageHeightMaxValue)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Garage's height must be in the range [{0}...{1}].",
                        GarageHeightMinValue, GarageHeightMaxValue));
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}, Width: {5}, Height: {6}",
                this.GetType().Name, this.Name, this.Area, this.Location, this.IsFurnished ? "Yes" : "No", this.Width, this.Height);

        }
    }
}
