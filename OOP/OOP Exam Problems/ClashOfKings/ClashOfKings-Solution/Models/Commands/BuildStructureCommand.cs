using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfKings.Models.Commands
{
    using ClashOfKings.Attributes;
    using ClashOfKings.Contracts;
    using ClashOfKings.Models.ArmyStructures;

    [Command]
    public class BuildStructureCommand : Command
    {
        public BuildStructureCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            ICity currentCity = this.Engine.Continent.GetCityByName(commandParams[1]);

            if (currentCity == null)
            {
                throw new InvalidOperationException();
            }

            IArmyStructure currentStructure = this.GetArmyStructure(commandParams[0]);

            if (currentCity.CityType < currentStructure.RequiredCityType)
            {
                throw new InvalidOperationException("Structure requires a more advanced city");
            }

            if (currentCity.ControllingHouse.TreasuryAmount < currentStructure.BuildCost)
            {
                throw new InvalidOperationException(string.Format("House {0} doesn't have sufficient funds to build {1}",
                    currentCity.ControllingHouse.Name, commandParams[0]));
            }

            currentCity.AddArmyStructure(currentStructure);
            currentCity.ControllingHouse.TreasuryAmount -= currentStructure.BuildCost;

            Console.WriteLine("Successfully built {0} in {1}",
                commandParams[0], currentCity.Name);
        }

        private IArmyStructure GetArmyStructure(string structureName)
        {
            switch (structureName)
            {
                case "Barracks": return new Barracks();
                case "DragonLair": return new DragonLair();
                case "Stable": return new Stable();
                default:
                    {
                        throw new InvalidOperationException();
                    }
            }
        }
    }
}
