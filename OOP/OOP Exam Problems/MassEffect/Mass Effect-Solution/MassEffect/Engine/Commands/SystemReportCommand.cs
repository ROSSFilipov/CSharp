using MassEffect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.Engine.Commands
{
    public class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            var intactShips = this.GameEngine
                .Starships
                .Where(x =>x.Health > 0 && x.Location.Name == commandArgs[1])
                .OrderByDescending(x => x.Health)
                .ThenByDescending(x => x.Shields);

            var destroyedShips = this.GameEngine
                .Starships
                .Where(x => x.Health <= 0 && x.Location.Name == commandArgs[1])
                .OrderBy(x => x.Name);

            Console.WriteLine("Intact ships:");
            if (intactShips.Count() == 0)
            {
                Console.WriteLine("N/A");
            }
            else
            {
                foreach (IStarship intactShip in intactShips)
                {
                    Console.WriteLine(intactShip);
                } 
            }

            Console.WriteLine("Destroyed ships:");
            if (destroyedShips.Count() == 0)
            {
                Console.WriteLine("N/A");
            }
            else
            {
                foreach (IStarship destroyedShip in destroyedShips)
                {
                    Console.WriteLine(destroyedShip);
                } 
            }
        }
    }
}
