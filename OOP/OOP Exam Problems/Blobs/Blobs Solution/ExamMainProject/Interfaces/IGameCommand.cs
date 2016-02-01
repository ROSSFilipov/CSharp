namespace ExamMainProject.Interfaces
{
    using System;

    public interface IGameCommand
    {
        IGameEngine Engine { get; }

        void Execute(string[] commandArguments);
    }
}
