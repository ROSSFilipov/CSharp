using EmpiresMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.ControlCenter.Commands
{
    public abstract class GameCommand : IGameCommand
    {
        private IEmpireEngine empireEngine;

        public GameCommand(IEmpireEngine empireEngine)
        {
            this.EmpireEngine = empireEngine;
        }

        public IEmpireEngine EmpireEngine
        {
            get
            {
                return this.empireEngine;
            }
            private set
            {
                this.empireEngine = value;
            }
        }

        public abstract void Execute(string[] commandArguments);
    }
}
