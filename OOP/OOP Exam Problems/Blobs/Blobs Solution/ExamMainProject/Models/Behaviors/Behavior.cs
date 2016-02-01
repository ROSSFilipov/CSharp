namespace ExamMainProject.Models.Behaviors
{
    using System;
    using Interfaces;
    using Attributes;

    [BehaviorAttribute]
    public abstract class Behavior : IBehavior
    {
        private bool isActive;

        protected Behavior()
        {
            this.IsActive = true;
        }

        public bool IsActive
        {
            get
            {
                return this.isActive;
            }
            protected set
            {
                this.isActive = value;
            }
        }

        public abstract void Activate(IBlob blobToBeAffected);

        public abstract void ApplySecondaryEffect(IBlob blobToBeAffected);
    }
}
