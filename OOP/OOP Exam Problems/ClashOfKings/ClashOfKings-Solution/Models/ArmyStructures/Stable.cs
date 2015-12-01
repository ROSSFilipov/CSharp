using ClashOfKings.Models.Armies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfKings.Models.ArmyStructures
{
    public class Stable : ArmyStructure
    {
        private const CityType StableRequiredCityType = CityType.FortifiedCity;
        private const decimal StableBuildCost = 75000;
        private const int StableCapacity = 2500;
        private const UnitType StableUnitType = UnitType.Cavalry;

        public Stable()
            : base(
            StableRequiredCityType,
            StableBuildCost,
            StableCapacity,
            StableUnitType)
        {
        }
    }
}
