using EmpiresMainProject.ControlCenter.Factories;
using EmpiresMainProject.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.Interfaces
{
    public interface IEmpireEngine
    {
        bool IsOperational { get; set; }

        IEnumerable<IBuilding> Buildings { get; }

        HashSet<UnitType> UnitTypes { get; }

        void Run();

        void AddBuilding(IBuilding buildingToBeAdded);
    }
}
