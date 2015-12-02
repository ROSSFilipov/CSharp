using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Core.Commands;

namespace WinterIsComing.Core
{
    public class UpgradedCommandDispatcher : CommandDispatcher
    {
        public UpgradedCommandDispatcher()
            : base()
        {
        }

        public override void DispatchCommand(string[] commandArgs)
        {
            string commandName = commandArgs[0];
            if (!this.commandsByName.ContainsKey(commandName))
            {
                throw new NotSupportedException(
                    "Command is not supported by engine");
            }

            var command = this.commandsByName[commandName];
            command.Execute(commandArgs);
        }

        public override void SeedCommands()
        {
            this.commandsByName["spawn"] = new SpawnCommand(this.Engine);
            this.commandsByName["fight"] = new FightCommand(this.Engine);
            this.commandsByName["move"] = new MoveCommand(this.Engine);
            this.commandsByName["status"] = new StatusCommand(this.Engine);
            this.commandsByName["winter-came"] = new WinterCameCommand(this.Engine);
            this.commandsByName["toggle-effector"] = new ToggleEffectorCommand(this.Engine);
        }
    }
}
