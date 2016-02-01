namespace ExamMainProject
{
    using System;
    using Interfaces;
    using ControlCenter;

    public class ExamMain
    {
        static void Main(string[] args)
        {
            IGameEngine currentEngine = new GameEngine();
            currentEngine.Run();
        }
    }
}
