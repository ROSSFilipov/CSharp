namespace ExamMainProject.ControlCenter.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Attributes;

    [CommandAttribute]
    public class PassCommand : GameCommand
    {
        public PassCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArguments)
        {
            return;
        }
    }
}
