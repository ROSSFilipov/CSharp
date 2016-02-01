namespace ExamMainProject.Interfaces
{
    using System;

    public interface IBehaviorFactory
    {
        IBehavior CreateBehavior(string behaviorName);
    }
}
