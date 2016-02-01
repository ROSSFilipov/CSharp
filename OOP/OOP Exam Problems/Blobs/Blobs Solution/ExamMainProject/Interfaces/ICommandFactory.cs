namespace ExamMainProject.Interfaces
{
    using System;

    public interface ICommandFactory
    {
        IGameCommand CreateCommand(string[] commandArguments, IGameEngine engine);
    }
}
