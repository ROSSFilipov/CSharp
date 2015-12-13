using EmpiresMainProject.Interfaces;
using EmpiresMainProject.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiresMainProject.ControlCenter.CustomExceptions;
using EmpiresMainProject.Models.Resources;

namespace EmpiresMainProject.Models.Buildings
{
    public class Barracks : Building
    {
        public Barracks()
            : base()
        {
            this.BuildingResource = new Steel(0);
            this.ProducedUnit = UnitType.Swordsman;
            this.UnitProductionTurnRequired = BuildingValues.BarracksUnitGameTurnRequired;
            this.ResourceProductionTurnRequired = BuildingValues.BarracksResourceGameTurnRequired;
        }

        public override void ProduceUnit()
        {
            int turnsPassed = this.UnitProductionTurnRequired - (this.CurrentTurn % this.UnitProductionTurnRequired);

            if (turnsPassed != this.UnitProductionTurnRequired)
            {
                throw new BuildingProductionException(string.Format(CustomMessages.BuildingProductionException,
                    turnsPassed, this.GetType().Name, this.ProducedUnit, this.UnitProductionTurnRequired));
            }

            for (int i = 0; i < BuildingValues.BarracksUnitProduction; i++)
            {
                this.units.Add(new Swordsman());
            }
        }

        public override void ProduceResource()
        {
            int turnsPassed = this.ResourceProductionTurnRequired - (this.CurrentTurn % this.ResourceProductionTurnRequired);

            if (turnsPassed != this.ResourceProductionTurnRequired)
            {
                throw new BuildingProductionException(string.Format(CustomMessages.BuildingProductionException,
                    turnsPassed, this.GetType().Name, ResourceType.Steel, this.ResourceProductionTurnRequired));
            }

            this.BuildingResource.Quantity += BuildingValues.BarracksResourceProduction;
        }

        public override bool CanProduceUnit()
        {
            return this.CurrentTurn % BuildingValues.BarracksUnitGameTurnRequired == 0 &&
                this.CurrentTurn != 0;
        }

        public override bool CanProduceResource()
        {
            return this.CurrentTurn % BuildingValues.BarracksResourceGameTurnRequired == 0 &&
                this.CurrentTurn != 0;
        }
    }
}
