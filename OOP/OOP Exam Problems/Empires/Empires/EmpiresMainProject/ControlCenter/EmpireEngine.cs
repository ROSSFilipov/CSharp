using EmpiresMainProject.ControlCenter.Commands;
using EmpiresMainProject.ControlCenter.Factories;
using EmpiresMainProject.Interfaces;
using EmpiresMainProject.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.ControlCenter
{
    public class EmpireEngine : IEmpireEngine
    {
        private bool isOperational;
        private List<IBuilding> buildings;
        private HashSet<UnitType> unitTypes;

        public EmpireEngine()
        {
            this.buildings = new List<IBuilding>();
            this.unitTypes = new HashSet<UnitType>();
            this.IsOperational = true;
        }

        public bool IsOperational
        {
            get
            {
                return this.isOperational;
            }
            set
            {
                this.isOperational = value;
            }
        }

        public IEnumerable<IBuilding> Buildings
        {
            get { return this.buildings; }
        }

        public HashSet<UnitType> UnitTypes
        {
            get
            {
                return this.unitTypes;
            }
        }

        public virtual void Run()
        {
            while (this.IsOperational)
            {
                string[] currentLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                IGameCommand currentCommand = this.GetCommand(currentLine[0]);
                currentCommand.Execute(currentLine);

                foreach (IBuilding currentBuilding in this.Buildings)
                {
                    currentBuilding.UpdateTurn();
                }

                foreach (IBuilding currentBuilding in this.Buildings)
                {
                    if (currentBuilding.CanProduceResource())
                    {
                        currentBuilding.ProduceResource();
                    }

                    if (currentBuilding.CanProduceUnit())
                    {
                        currentBuilding.ProduceUnit();
                        if (!this.UnitTypes.Contains(currentBuilding.ProducedUnit))
                        {
                            this.UnitTypes.Add(currentBuilding.ProducedUnit);
                        }
                    }
                }
            }
        }

        protected virtual IGameCommand GetCommand(string commandType)
        {
            switch (commandType)
            {
                case CommandValues.EndCommandString: return new EndCommand(this);
                case CommandValues.BuildCommandString: return new BuildCommand(this);
                case CommandValues.SkipCommandString: return new SkipCommand(this);
                case CommandValues.StatusCommandString: return new EmpireStatusCommand(this);
                default:
                    {
                        throw new InvalidOperationException();
                    }
            }
        }

        public void AddBuilding(IBuilding buildingToBeAdded)
        {
            this.buildings.Add(buildingToBeAdded);
        }
    }
}
