using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Models
{
    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private const int BuildingEstateRoomsMinValue = 0;
        private const int BuildingEstateRoomsMaxValue = 20;

        private int rooms;
        private bool hasElevator;

        protected BuildingEstate(string name, EstateType type, double area, string location, bool isFurnished, int rooms, bool hasElevator)
            : base(name, type, area, location, isFurnished)
        {
            this.Rooms = rooms;
            this.HasElevator = hasElevator;
        }

        public BuildingEstate(EstateType type)
            : base(type)
        {

        }

        public int Rooms
        {
            get
            {
                return this.rooms;
            }
            set
            {
                if (value < BuildingEstateRoomsMinValue || value > BuildingEstateRoomsMaxValue)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Number of rooms should be in the range: [{0}...{20}].",
                        BuildingEstateRoomsMinValue, BuildingEstateRoomsMaxValue));
                }

                this.rooms = value;
            }
        }

        public bool HasElevator
        {
            get
            {
                return this.hasElevator;
            }
            set
            {
                this.hasElevator = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}, Rooms: {5}, Elevator: {6}",
                this.GetType().Name, this.Name, this.Area, this.Location, this.IsFurnished ? "Yes" : "No", this.Rooms, this.HasElevator ? "Yes" : "No");
        }
    }
}
