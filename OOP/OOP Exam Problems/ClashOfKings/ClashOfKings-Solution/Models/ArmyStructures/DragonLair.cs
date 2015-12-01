using ClashOfKings.Models.Armies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfKings.Models.ArmyStructures
{
    public class DragonLair : ArmyStructure
    {
        private const CityType DragonLairRequiredCityType = CityType.Capital;
        private const decimal DragonLairBuildCost = 200000m;
        private const int DragonLairCapacity = 3;
        private const UnitType DragonLairUnitType = UnitType.AirForce;

        public DragonLair()
            : base(
            DragonLairRequiredCityType,
            DragonLairBuildCost,
            DragonLairCapacity,
            DragonLairUnitType)
        {
        }
    }
}
