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

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            IStarship currentShip = this.GameEngine.Starships.FirstOrDefault(x => x.Name == commandArgs[1]);

            Console.WriteLine(currentShip.ToString());
        }
    }
}
