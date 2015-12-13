using EmpiresMainProject.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.Interfaces
{
    public interface IBuilding
    {
        int CurrentTurn { get; }

        IResource BuildingResource { get; }

        UnitType ProducedUnit { get; }

        int UnitProductionTurnRequired { get; }

        int ResourceProductionTurnRequired { get; }

        IEnumerable<IUnit> Units { get; }

        void ProduceUnit();

        void ProduceResource();

        void UpdateTurn();

        bool CanProduceUnit();

        bool CanProduceResource();
    }
}
