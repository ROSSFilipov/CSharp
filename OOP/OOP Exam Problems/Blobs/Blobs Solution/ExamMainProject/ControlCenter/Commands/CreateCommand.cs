namespace ExamMainProject.ControlCenter.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Factories;
    using CustomExceptions;
    using Attributes;

    [CommandAttribute]
    public class CreateCommand : GameCommand
    {
        public CreateCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArguments)
        {
            if (this.Engine.BlobData.Any(x => x.Name == commandArguments[1]))
            {
                throw new InvalidOperationException(string.Format(CustomMessages.DuplicateBlobMessage,
                    commandArguments[1]));
            }

            IBlob currentBlob = BlobFactory.Factory.CreateBlob(commandArguments);

            this.Engine.AddBlob(currentBlob);
        }
    }
}
