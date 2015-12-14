using EmpiresMainProject.ControlCenter.Commands;
using EmpiresMainProject.ControlCenter.Factories;
using EmpiresMainProject.Interfaces;
using EmpiresMainProject.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmpiresMainProject.ControlCenter
{
    public class EmpireEngine : IEmpireEngine
    {
        private bool isOperational;
        private List<IBuilding> buildings;
        private HashSet<UnitType> unitTypes;
        private static List<Type> commandTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(x => CommandValues.commandMatchPattern.IsMatch(x.Name))
            .ToList();

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
                //IGameCommand currentCommand = this.GetCommand(currentLine[0]); //Non reflection
                IGameCommand currentCommand = this.CommandParser(currentLine[0]); //Reflection
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

        protected virtual IGameCommand CommandParser(string commandName)
        {
            string fixedName = commandName.Replace("-", "");
            Type usedType = commandTypes
                .FirstOrDefault(x =>
                {
                    Match currentCommand = CommandValues.commandMatchPattern.Match(x.Name);
                    return currentCommand.Groups[1].Value.ToLower() == fixedName;
                }
                );

            return Activator.CreateInstance(usedType, this) as IGameCommand;
        }

        protected virtual IGameCommand GetCommand(string commandType)
        {
            switch (commandType)
            {
                case CommandValues.EndCommandString: return new ArmisticeCommand(this);
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
