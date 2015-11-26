using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Models
{
    public class Apartment : BuildingEstate, IApartment
    {
        public Apartment(string name, EstateType type, double area, string location, bool isFurnished, int rooms, bool hasElevator)
            : base(name, type, area, location, isFurnished, rooms, hasElevator)
        {

        }

        public Apartment(EstateType type)
            : base(type)
        {

        }
    }
}
