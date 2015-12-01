namespace ClashOfKings.Models.ArmyStructures
{
    using ClashOfKings.Contracts;
    using ClashOfKings.Models.Armies;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class ArmyStructure : IArmyStructure
    {
        private const string NegativeBuildCost = "Build cost cannot be negative";
        private const string NegativeCapacity = "Capacity cannot be negative";

        private CityType requiredCityType;
        private decimal buildCost;
        private int capacity;
        private UnitType unitType;

        protected ArmyStructure(CityType requiredCityType, decimal buildCost, int capacity, UnitType unitType)
        {
            this.RequiredCityType = requiredCityType;
            this.BuildCost = buildCost;
            this.Capacity = capacity;
            this.UnitType = unitType;
        }

        public CityType RequiredCityType
        {
            get { return this.requiredCityType; }
            private set
            {
                this.requiredCityType = value;
            }
        }

        public decimal BuildCost
        {
            get { return this.buildCost; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(NegativeBuildCost);
                }

                this.buildCost = value;
            }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(NegativeCapacity);
                }

                this.capacity = value;
            }
        }

        public UnitType UnitType
        {
            get { return this.unitType; }
            private set
            {
                this.unitType = value;
            }
        }
    }
}
