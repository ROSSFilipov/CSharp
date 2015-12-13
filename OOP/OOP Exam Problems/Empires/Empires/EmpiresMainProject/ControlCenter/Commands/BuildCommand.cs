using EmpiresMainProject.ControlCenter.Factories;
using EmpiresMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.ControlCenter.Commands
{
    public class BuildCommand : GameCommand
    {
        public BuildCommand(IEmpireEngine empireEngine)
            : base(empireEngine)
        {
        }

        public override void Execute(string[] commandArguments)
        {
            string buildingType = commandArguments[1];
            IBuilding currentBuilding = BuildingFactory.Instance.ProduceBuilding(buildingType);
            this.EmpireEngine.AddBuilding(currentBuilding);
        }
    }
}
