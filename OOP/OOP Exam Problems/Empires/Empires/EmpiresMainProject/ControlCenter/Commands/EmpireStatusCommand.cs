using EmpiresMainProject.Interfaces;
using EmpiresMainProject.Models.Resources;
using EmpiresMainProject.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.ControlCenter.Commands
{
    public class EmpireStatusCommand : GameCommand
    {
        public EmpireStatusCommand(IEmpireEngine empireEngine)
            : base(empireEngine)
        {
        }

        public override void Execute(string[] commandArguments)
        {
            int goldAmount = this.EmpireEngine
                .Buildings
                .Where(x => x.BuildingResource is Gold)
                .Sum(x => x.BuildingResource.Quantity);

            int steelAmount = this.EmpireEngine
                .Buildings
                .Where(x => x.BuildingResource is Steel)
                .Sum(x => x.BuildingResource.Quantity);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Treasury:");
            sb.AppendLine(string.Format("--Gold: {0}", goldAmount));
            sb.AppendLine(string.Format("--Steel: {0}", steelAmount));
            sb.AppendLine("Buildings:");

            if (this.EmpireEngine.Buildings.Count() != 0)
            {
                foreach (IBuilding currentBuilding in this.EmpireEngine.Buildings)
                {
                    int unitTurnsLeft = currentBuilding.UnitProductionTurnRequired -
                        (currentBuilding.CurrentTurn % currentBuilding.UnitProductionTurnRequired);

                    int resourceTurnsLeft = currentBuilding.ResourceProductionTurnRequired -
                        (currentBuilding.CurrentTurn % currentBuilding.ResourceProductionTurnRequired);

                    sb.AppendLine(string.Format("--{0}: {1} turns ({2} turns until {3}, {4} turns until {5})",
                        currentBuilding.GetType().Name,
                        currentBuilding.CurrentTurn,
                        unitTurnsLeft,
                        currentBuilding.ProducedUnit,
                        resourceTurnsLeft,
                        currentBuilding.BuildingResource.GetType().Name));
                } 
            }
            else
            {
                sb.AppendLine("N/A");
            }

            sb.AppendLine("Units:");

            bool unitFound = false;
            foreach (UnitType currentUnitType in this.EmpireEngine.UnitTypes)
            {
                int currentUnitCount = this.EmpireEngine
                    .Buildings
                    .Where(x => x.ProducedUnit == currentUnitType)
                    .Sum(x => x.Units.Count());

                if (currentUnitCount != 0)
                {
                    unitFound = true;

                    sb.AppendLine(string.Format("--{0}: {1}", currentUnitType, currentUnitCount));
                }
            }

            if (!unitFound)
            {
                sb.AppendLine("N/A");
            }

            Console.Write(sb.ToString());
        }
    }
}
