using EmpiresMainProject.Interfaces;
using EmpiresMainProject.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.Models.Buildings
{
    public abstract class Building : IBuilding
    {
        private int currentTurn;
        protected List<IUnit> units;
        private IResource buildingResource;
        private UnitType producedUnit;
        private int unitProductionTurnRequired;
        private int resourceProductionTurnRequired;

        public Building()
        {
            this.CurrentTurn = -1;
            this.units = new List<IUnit>();
        }

        public int CurrentTurn
        {
            get
            {
                return this.currentTurn;
            }
            private set
            {
                this.currentTurn = value;
            }
        }

        public IResource BuildingResource
        {
            get { return this.buildingResource; }
            protected set
            {
                this.buildingResource = value;
            }
        }

        public UnitType ProducedUnit
        {
            get
            {
                return this.producedUnit;
            }
            protected set
            {
                this.producedUnit = value;
            }
        }

        public int UnitProductionTurnRequired
        {
            get { return this.unitProductionTurnRequired; }
            protected set
            {
                this.unitProductionTurnRequired = value;
            }
        }

        public IEnumerable<IUnit> Units
        {
            get
            {
                return this.units;
            }
        }

        public int ResourceProductionTurnRequired
        {
            get { return this.resourceProductionTurnRequired; }
            protected set
            {
                this.resourceProductionTurnRequired = value;
            }
        }

        public void UpdateTurn()
        {
            this.CurrentTurn++;
        }

        protected virtual void AddUnit(IUnit unitToBeAdded)
        {
            this.units.Add(unitToBeAdded);
        }

        public abstract void ProduceUnit();

        public abstract void ProduceResource();

        public abstract bool CanProduceUnit();

        public abstract bool CanProduceResource();
    }
}
