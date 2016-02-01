namespace ExamMainProject.Models.Behaviors
{
    using System;
    using Interfaces;
    using ControlCenter;
    using Attributes;

    [BehaviorAttribute]
    public class InflatedBehavior : Behavior
    {
        public override void Activate(IBlob blobToBeAffected)
        {
            blobToBeAffected.Health += ValidationControl.InflatedBehaviorHealthIncrease;
            this.IsActive = false;
        }

        public override void ApplySecondaryEffect(IBlob blobToBeAffected)
        {
            blobToBeAffected.Health -= ValidationControl.InflatedBehaviorHealthDecrease;
        }
    }
}
