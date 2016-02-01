namespace ExamMainProject.ControlCenter.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using UI;
    using Attributes;
    using System.Text;

    [CommandAttribute]
    public class StatusCommand : GameCommand
    {
        public StatusCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArguments)
        {
            StringBuilder sb = new StringBuilder();
            foreach (IBlob currentBlob in this.Engine.BlobData)
            {
                sb.AppendLine(currentBlob.ToString());
                //OutputManager.Manager.WriteLine(currentBlob.ToString());
            }

            this.Engine.AllEvents.AddLast(sb.ToString());
        }
    }
}
