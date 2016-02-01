namespace ExamMainProject.Models.Behaviors
{
    using System;
    using Interfaces;
    using ControlCenter;
    using Attributes;

    [BehaviorAttribute]
    public class AggressiveBehavior : Behavior
    {
        public override void Activate(IBlob blobToBeAffected)
        {
            blobToBeAffected.Damage *= ValidationControl.AggressiveBehaviorDamageMultiplyIndex;
            this.IsActive = false;
        }

        public override void ApplySecondaryEffect(IBlob blobToBeAffected)
        {
            blobToBeAffected.Damage -= ValidationControl.AggressiveBehaviorDamageDecrease;
        }
    }
}
