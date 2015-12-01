using ClashOfKings.Models.Armies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfKings.Models.ArmyStructures
{
    public class Barracks : ArmyStructure
    {
        private const CityType BarraksRequiredCityType = CityType.Keep;
        private const decimal BarraksBuildCost = 15000m;
        private const int BarraksCapacity = 5000;
        private const UnitType BarraksUnitType = UnitType.Infantry;

        public Barracks()
            : base(
            BarraksRequiredCityType,
            BarraksBuildCost,
            BarraksCapacity,
            BarraksUnitType)
        {
        }
    }
}
