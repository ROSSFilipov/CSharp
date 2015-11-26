using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Models
{
    public class House : Estate, IHouse
    {
        private const int HouseFloorsMinValue = 0;
        private const int HouseFloorsMaxValue = 10;

        private int floors;

        public House(string name, EstateType type, double area, string location, bool isFurnished, int floors)
            : base(name, type, area, location, isFurnished)
        {
            this.Floors = floors;
        }

        public House(EstateType type)
            : base(type)
        {

        }

        public int Floors
        {
            get
            {
                return this.floors;
            }
            set
            {
                if (value < HouseFloorsMinValue || value > HouseFloorsMaxValue)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Number of floors must be in the range [{0}...{1}].", 
                        HouseFloorsMinValue, HouseFloorsMaxValue));
                }

                this.floors = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}, Floors: {5}",
                this.GetType().Name, this.Name, this.Area, this.Location, this.IsFurnished ? "Yes" : "No", this.Floors);
        }
    }
}
