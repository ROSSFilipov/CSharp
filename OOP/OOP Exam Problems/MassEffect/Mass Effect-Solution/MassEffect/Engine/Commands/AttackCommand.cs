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

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            IStarship attacker = this.GameEngine.Starships.FirstOrDefault(x => x.Name == commandArgs[1]);
            IStarship defender = this.GameEngine.Starships.FirstOrDefault(x => x.Name == commandArgs[2]);

            if (attacker.Health <= 0 || defender.Health <= 0)
            {
                throw new ShipException(Messages.ShipAlreadyDestroyed);
            }

            if (attacker.Location != defender.Location)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }

            defender.RespondToAttack(attacker.ProduceAttack());

            Console.WriteLine(Messages.ShipAttacked, attacker.Name, defender.Name);

            if (defender.Health <= 0)
            {
                Console.WriteLine(Messages.ShipDestroyed, defender.Name);
            }
        }
    }
}
