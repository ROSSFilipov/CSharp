using EmpiresMainProject.ControlCenter.Factories;
using EmpiresMainProject.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.Interfaces
{
    /// <summary>
    /// The interface holds the main game engine
    /// specifications.
    /// </summary>
    public interface IEmpireEngine
    {
        bool IsOperational { get; set; }

        IEnumerable<IBuilding> Buildings { get; }

        HashSet<UnitType> UnitTypes { get; }

        /// <summary>
        /// The main game engine method which
        /// indicates if the engine is currently running.
        /// </summary>
        void Run();

        void AddBuilding(IBuilding buildingToBeAdded);
    }
}
