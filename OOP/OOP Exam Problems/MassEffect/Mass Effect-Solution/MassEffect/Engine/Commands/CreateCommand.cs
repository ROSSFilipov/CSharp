namespace MassEffect.Engine.Commands
{
    using MassEffect.Exceptions;
    using MassEffect.GameObjects.Enhancements;
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Ships;
    using MassEffect.Interfaces;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            if (ShipExists(commandArgs[2]))
            {
                throw new ShipException(Messages.DuplicateShipName);
            }

            StarshipType shipType = GetShipType(commandArgs[1]);
            string shipName = commandArgs[2];
            StarSystem starSystem = this.GameEngine.Galaxy.GetStarSystemByName(commandArgs[3]);

            IStarship currentShip = this.GameEngine.ShipFactory.CreateShip(shipType, shipName, starSystem);

            LoadEnhancements(currentShip, commandArgs);

            this.GameEngine.Starships.Add(currentShip);

            Console.WriteLine(Messages.CreatedShip, currentShip.GetType().Name, currentShip.Name);
        }

        private bool ShipExists(string name)
        {
            return this.GameEngine.Starships.Any(x => x.Name == name);
        }

        private void LoadEnhancements(IStarship currentShip, string[] commandArgs)
        {
            for (int i = 4; i < commandArgs.Length; i++)
            {
                EnhancementType currentType = GetEnhancementType(commandArgs[i]);
                currentShip.AddEnhancement(this.GameEngine.EnhancementFactory.Create(currentType));
            }
        }

        private EnhancementType GetEnhancementType(string type)
        {
            switch (type)
            {
                case "ThanixCannon":
                    return EnhancementType.ThanixCannon;
                case "KineticBarrier":
                    return EnhancementType.KineticBarrier;
                case "ExtendedFuelCells":
                    return EnhancementType.ExtendedFuelCells;
                default:
                    throw new NotImplementedException();
            }
        }

        private StarshipType GetShipType(string type)
        {
            switch (type)
            {
                case "Frigate":
                    return StarshipType.Frigate;
                case "Cruiser":
                    return StarshipType.Cruiser;
                case "Dreadnought":
                    return StarshipType.Dreadnought;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
