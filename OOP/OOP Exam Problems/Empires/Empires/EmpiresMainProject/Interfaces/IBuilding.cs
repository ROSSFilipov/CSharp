using EmpiresMainProject.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.Interfaces
{
    /// <summary>
    /// An interface indicating the main property of a building.
    /// </summary>
    public interface IBuilding
    {
        /// <summary>
        /// The property indicates how many game turns have already passed
        /// and is used to determine if a building is able to produce a
        /// unit or a resource at a given moment.
        /// </summary>
        int CurrentTurn { get; }

        IResource BuildingResource { get; }

        UnitType ProducedUnit { get; }

        /// <summary>
        /// Indicates how many turns does a specific building need
        /// in order to produce a unit.
        /// </summary>
        int UnitProductionTurnRequired { get; }

        /// <summary>
        /// Indicates how many game turns should pass before
        /// the specific building can produce a resourse.
        /// </summary>
        int ResourceProductionTurnRequired { get; }

        IEnumerable<IUnit> Units { get; }

        /// <summary>
        /// The method adds a specific unit depending
        /// on the building type to the building list
        /// of units.
        /// </summary>
        void ProduceUnit();

        /// <summary>
        /// The method adds a quantity of a specific
        /// resource depending on the building type.
        /// </summary>
        void ProduceResource();

        /// <summary>
        /// Upgrades the current building's turn
        /// by increasing it by 1.
        /// </summary>
        void UpdateTurn();

        /// <summary>
        /// Returns a boolean value indicating
        /// if the specified building is currently
        /// able to produce a unit.
        /// </summary>
        /// <returns>Returns boolean.</returns>
        bool CanProduceUnit();

        /// <summary>
        /// Returns a boolean value indicating
        /// if the specified building is currently
        /// able to produce a resource.
        /// </summary>
        /// <returns>Returns boolean.</returns>
        bool CanProduceResource();
    }
}
