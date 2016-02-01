namespace ExamMainProject.ControlCenter.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using CustomExceptions;
    using Attributes;

    [CommandAttribute]
    public class AttackCommand : GameCommand
    {
        public AttackCommand(IGameEngine engine)
            : base(engine)
        {
        }

        public override void Execute(string[] commandArguments)
        {
            if (commandArguments[1] == commandArguments[2])
            {
                throw new FriendlyFireException(CustomMessages.FriendlyFireMessage);
            }

            IBlob attackingBlob = this.Engine
                .BlobData
                .FirstOrDefault(b => b.Name == commandArguments[1] && b.Health > ValidationControl.BlobHealthMinValue);

            if (attackingBlob == null)
            {
                throw new BlobNullException(string.Format(CustomMessages.BlobNullMessage,
                    commandArguments[1]));
            }

            IBlob enemyBlob = this.Engine
                .BlobData
                .FirstOrDefault(b => b.Name == commandArguments[2] && b.Health > ValidationControl.BlobHealthMinValue);

            if (enemyBlob == null)
            {
                throw new BlobNullException(string.Format(CustomMessages.BlobNullMessage,
                    commandArguments[2]));
            }

            attackingBlob.Attack(enemyBlob);

            if (enemyBlob.Health == 0 && !this.Engine.KilledBlobs.Contains(enemyBlob.Name))
            {
                this.Engine.ToggledEvents.Add(string.Format(CustomMessages.BlobKilledMessage, enemyBlob.Name));
                this.Engine.KilledBlobs.Add(enemyBlob.Name);
            }
        }
    }
}
