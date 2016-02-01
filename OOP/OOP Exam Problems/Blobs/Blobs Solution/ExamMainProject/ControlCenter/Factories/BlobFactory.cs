namespace ExamMainProject.ControlCenter.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using CustomExceptions;
    using ExamMainProject.Models;

    public class BlobFactory : IBlobFactory
    {
        private static IBlobFactory factory;

        private BlobFactory()
        {
        }

        public static IBlobFactory Factory
        {
            get
            {
                if (factory == null)
                {
                    factory = new BlobFactory();
                }

                return factory;
            }
        }

        public IBlob CreateBlob(string[] commandArguments)
        {
            string blobName = commandArguments[1];

            int blobHealth;
            if (!int.TryParse(commandArguments[2], out blobHealth))
            {
                throw new BlobHealthException(string.Format(CustomMessages.BlobHealthMessage, 
                    ValidationControl.BlobHealthMinValue));
            }

            blobHealth = int.Parse(commandArguments[2]);

            int blobDamage;

            if (!int.TryParse(commandArguments[3], out blobDamage))
            {
                throw new BlobDamageException(string.Format(CustomMessages.BlobDamageMessage,
                    ValidationControl.BlobDamageMinValue));
            }

            blobDamage = int.Parse(commandArguments[3]);
            string behaviorName = commandArguments[4];
            IBehavior currentBehavior = BehaviorFactory.Factory.CreateBehavior(behaviorName);

            string spellName = commandArguments[5];
            ISpell currentSpell = SpellFactory.Factory.CreateSpell(spellName);

            IBlob currentBlob = new Blob(blobName, blobHealth, blobDamage, currentBehavior, currentSpell);

            return currentBlob;
        }
    }
}
