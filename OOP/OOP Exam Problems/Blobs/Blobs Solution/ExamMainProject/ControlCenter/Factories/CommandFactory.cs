namespace ExamMainProject.ControlCenter.Factories
{
    using System;
    using Interfaces;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using ExamMainProject.Attributes;

    public class CommandFactory : ICommandFactory
    {
        private static ICommandFactory factory;
        private static readonly List<Type> assemblyCommandTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(type => type.CustomAttributes.Any(a => a.AttributeType == typeof(CommandAttribute)))
            .ToList();

        private CommandFactory()
        {
        }

        public static ICommandFactory Factory
        {
            get
            {
                if (factory == null)
                {
                    factory = new CommandFactory();
                }

                return factory;
            }
        }

        public IGameCommand CreateCommand(string[] commandArguments, IGameEngine engine)
        {
            string replacedString = commandArguments[0].Replace("-", string.Empty);
            string commandName = replacedString + ValidationControl.CommandStringPostFix;
            Type currentType = assemblyCommandTypes.FirstOrDefault(x => x.Name.ToLower() == commandName);

            IGameCommand currentCommand = Activator.CreateInstance(currentType, engine) as IGameCommand;

            return currentCommand;
        }
    }
}
