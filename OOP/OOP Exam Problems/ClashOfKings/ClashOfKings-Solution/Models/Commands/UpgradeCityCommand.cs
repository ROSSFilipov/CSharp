using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfKings.Models.Commands
{
    using ClashOfKings.Attributes;
    using ClashOfKings.Contracts;

    [Command]
    public class UpgradeCityCommand : Command
    {
        public UpgradeCityCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(params string[] commandParams)
        {
            ICity currentCity = this.Engine.Continent.GetCityByName(commandParams[0]);

            if (currentCity == null)
            {
                throw new InvalidOperationException();
            }

            if ((currentCity.ControllingHouse.TreasuryAmount < currentCity.UpgradeCost) && !(currentCity.ControllingHouse is GreatHouse))
            {
                throw new InvalidOperationException(string.Format("House {0} has insufficient funds to upgrade {1}",
                    currentCity.ControllingHouse.Name, currentCity.Name));
            }

            if (currentCity.CityType == CityType.Capital)
            {
                throw new InvalidOperationException(string.Format("City {0} is at the maximum level and cannot be upgraded further",
                    currentCity.Name));
            }

            CityType type = currentCity.CityType;
            currentCity.Upgrade();
            currentCity.ControllingHouse.TreasuryAmount -= currentCity.UpgradeCost;

            Console.WriteLine("City {0} successfully upgraded to {1}",
                currentCity.Name, type + 1);
        }
    }
}
