using MassEffect.Engine.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.Engine
{
    public class UpgradedCommandManager : CommandManager
    {
        public override void SeedCommands()
        {
            this.commandsByName["create"] = new CreateCommand(this.Engine);
            this.commandsByName["attack"] = new AttackCommand(this.Engine);
            this.commandsByName["status-report"] = new StatusReportCommand(this.Engine);
            this.commandsByName["plot-jump"] = new PlotJumpCommand(this.Engine);
            this.commandsByName["over"] = new OverCommand(this.Engine);
            this.commandsByName["system-report"] = new SystemReportCommand(this.Engine);
        }
    }
}
