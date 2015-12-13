using EmpiresMainProject.ControlCenter.CustomExceptions;
using EmpiresMainProject.Interfaces;
using EmpiresMainProject.Models.Resources;
using EmpiresMainProject.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.Models.Buildings
{
    public class Archery : Building
    {
        public Archery()
        {
            this.BuildingResource = new Gold(0);
            this.ProducedUnit = UnitType.Archer;
            this.UnitProductionTurnRequired = BuildingValues.ArcheryUnitGameTurnRequired;
            this.ResourceProductionTurnRequired = BuildingValues.ArcheryResourceGameTurnRequired;
        }

        public override void ProduceUnit()
        {
            int turnsPassed = this.UnitProductionTurnRequired - (this.CurrentTurn % this.UnitProductionTurnRequired);

            if (turnsPassed != this.UnitProductionTurnRequired)
            {
                throw new BuildingProductionException(string.Format(CustomMessages.BuildingProductionException,
                    turnsPassed, this.GetType().Name, this.ProducedUnit, this.UnitProductionTurnRequired));
            }

            for (int i = 0; i < BuildingValues.ArcheryUnitProduction; i++)
            {
                this.units.Add(new Archer());
            }
        }

        public override void ProduceResource()
        {
            int turnsPassed = this.ResourceProductionTurnRequired - (this.CurrentTurn % this.ResourceProductionTurnRequired);

            if (turnsPassed != this.ResourceProductionTurnRequired)
            {
                throw new BuildingProductionException(string.Format(CustomMessages.BuildingProductionException,
                    turnsPassed, this.GetType().Name, ResourceType.Gold, this.ResourceProductionTurnRequired));
            }

            this.BuildingResource.Quantity += BuildingValues.ArcheryResourceProduction;
        }

        public override bool CanProduceUnit()
        {
            return this.CurrentTurn % BuildingValues.ArcheryUnitGameTurnRequired == 0 &&
                this.CurrentTurn != 0;
        }

        public override bool CanProduceResource()
        {
            return this.CurrentTurn % BuildingValues.ArcheryResourceGameTurnRequired == 0 &&
                this.CurrentTurn != 0;
        }
    }
}
