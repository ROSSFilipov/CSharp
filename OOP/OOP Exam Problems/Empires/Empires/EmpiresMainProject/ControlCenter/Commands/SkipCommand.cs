using EmpiresMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.ControlCenter.Commands
{
    public class SkipCommand : GameCommand
    {
        public SkipCommand(IEmpireEngine empireEngine)
            : base(empireEngine)
        {
        }

        public override void Execute(string[] commandArguments)
        {
            return;
        }
    }
}
