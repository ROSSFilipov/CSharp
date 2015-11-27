namespace MassEffect.Engine.Commands
{
    using MassEffect.GameObjects.Ships;
    using MassEffect.Interfaces;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using MassEffect.Exceptions;
    using MassEffect.GameObjects.Locations;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            IStarship currentShip = this.GameEngine.Starships.FirstOrDefault(x => x.Name == commandArgs[1]);

            if (currentShip.Health <= 0)
            {
                throw new ShipException(Messages.ShipAlreadyDestroyed);
            }

            if (currentShip.Location.Name == commandArgs[2])
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, commandArgs[2]));
            }

            StarSystem oldDestination = currentShip.Location;
            StarSystem newDestination = this.GameEngine.Galaxy.GetStarSystemByName(commandArgs[2]);

            this.GameEngine.Galaxy.TravelTo(currentShip, newDestination);

            Console.WriteLine(Messages.ShipTraveled, currentShip.Name, oldDestination.Name, newDestination.Name);
        }
    }
}
