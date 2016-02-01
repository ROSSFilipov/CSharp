namespace ExamMainProject.ControlCenter.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Attributes;
    using ExamMainProject.UI;
    using System.Text;

    [CommandAttribute]
    public class ReportEventsCommand : GameCommand
    {
        public ReportEventsCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArguments)
        {
            this.Engine.MustPrintToggledEvents = true;
        }
    }
}
