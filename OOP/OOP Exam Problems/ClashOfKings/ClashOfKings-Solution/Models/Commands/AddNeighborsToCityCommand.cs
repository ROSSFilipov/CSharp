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
    public class AddNeighborsToCityCommand : Command
    {
        public AddNeighborsToCityCommand(IGameEngine engine)
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

            for (int i = 1; i < commandParams.Length; i += 2)
            {
                ICity currentNeightbor = this.Engine.Continent.GetCityByName(commandParams[i]);
                if (currentNeightbor == null)
                {
                    throw new InvalidOperationException("Specified neighbor does not exist");
                }

                double distance = double.Parse(commandParams[i + 1]);

                if (distance < 0)
                {
                    throw new ArgumentOutOfRangeException("The distance between cities cannot be negative");
                }

                this.Engine.Continent.CityNeighborsAndDistances[currentCity].Add(currentNeightbor, distance);
                this.Engine.Continent.CityNeighborsAndDistances[currentNeightbor].Add(currentCity, distance);
            }

            Console.WriteLine("All valid neighbor records added for city {0}", currentCity.Name);
        }
    }
}
