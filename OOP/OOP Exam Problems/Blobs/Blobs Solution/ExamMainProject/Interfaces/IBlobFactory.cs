namespace ExamMainProject.Interfaces
{
    using System;

    public interface IBlobFactory
    {
        IBlob CreateBlob(string[] commandArguments);
    }
}
