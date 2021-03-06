﻿using EmpiresMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.ControlCenter.Commands
{
    public class ArmisticeCommand : GameCommand
    {
        public ArmisticeCommand(IEmpireEngine empireEngine)
            : base(empireEngine)
        {
        }

        public override void Execute(string[] commandArguments)
        {
            this.EmpireEngine.IsOperational = false;
        }
    }
}
