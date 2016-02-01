namespace ExamMainProject.Interfaces
{
    using System;

    public interface IBehavior
    {
        bool IsActive { get; }

        void Activate(IBlob blobToBeAffected);

        void ApplySecondaryEffect(IBlob blobToBeAffected);
    }
}
