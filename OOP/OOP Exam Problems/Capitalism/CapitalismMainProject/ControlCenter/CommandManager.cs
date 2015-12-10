using CapitalismMainProject.ControlCenter.ConstantValues;
using CapitalismMainProject.ControlCenter.Factories;
using CapitalismMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.ControlCenter
{
    public class CommandManager : ICommandManager
    {
        private IList<ICommand> commandList;

        private ICommandFactory commandFactory;

        private ICompanyManager companyManager;

        private HashSet<string> templateCommands;

        public CommandManager(ICompanyManager companyManager)
        {
            this.CompanyManager = companyManager;
            this.commandList = new List<ICommand>();
            this.CommandFactory = new CommandFactory(companyManager);
            this.InitilizeTemplateCommands();
        }

        public IEnumerable<ICommand> CommandList
        {
            get
            {
                return this.commandList;
            }
        }

        public ICompanyManager CompanyManager
        {
            get
            {
                return this.companyManager;
            }
            private set
            {
                this.companyManager = value;
            }
        }

        public ICommandFactory CommandFactory
        {
            get
            {
                return this.commandFactory;
            }
            private set
            {
                this.commandFactory = value;
            }
        }

        public void ExecuteCommand(string currentLine)
        {
            string[] commandArguments = currentLine.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            ICommand currentCommand = this.CommandFactory.CreateCommand(commandArguments[0]);
            currentCommand.Execute(commandArguments);
        }

        protected virtual void InitilizeTemplateCommands()
        {
            this.templateCommands = new HashSet<string>();
            this.templateCommands.Add(CommandValues.CreateCompanyCommandString);
            this.templateCommands.Add(CommandValues.CreateDepartmentCommandString);
            this.templateCommands.Add(CommandValues.CreateEmployeeCommandString);
            this.templateCommands.Add(CommandValues.PaySalaryCommandString);
            this.templateCommands.Add(CommandValues.ShowEmployeesCommandString);
        }
    }
}
