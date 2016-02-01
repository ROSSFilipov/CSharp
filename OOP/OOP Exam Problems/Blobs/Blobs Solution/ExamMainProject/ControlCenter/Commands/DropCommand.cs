namespace ExamMainProject.ControlCenter.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Attributes;

    [CommandAttribute]
    public class DropCommand : GameCommand
    {
        public DropCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArguments)
        {
            this.Engine.Stop();
        }
    }
}
