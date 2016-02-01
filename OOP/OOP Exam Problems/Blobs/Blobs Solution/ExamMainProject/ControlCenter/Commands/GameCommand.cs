namespace ExamMainProject.ControlCenter.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using Attributes;

    /// <summary>
    /// The project's functionality can be easily extended by adding more commands.
    /// As the command factory is reflection based in order for you to add an additional
    /// command you just need to use the [CommandAttribute] and "Command" postfix in the
    /// class name.
    /// </summary>
    [CommandAttribute]
    public abstract class GameCommand : IGameCommand
    {
        private IGameEngine engine;

        protected GameCommand(IGameEngine engine)
        {
            this.Engine = engine;
        }

        public IGameEngine Engine
        {
            get { return this.engine; }
            private set
            {
                this.engine = value;
            }
        }

        public abstract void Execute(string[] commandArguments);
    }
}
