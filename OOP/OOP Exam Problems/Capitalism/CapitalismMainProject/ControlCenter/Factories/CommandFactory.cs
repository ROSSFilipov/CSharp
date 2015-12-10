using CapitalismMainProject.ControlCenter.Commands;
using CapitalismMainProject.ControlCenter.ConstantValues;
using CapitalismMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.ControlCenter.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private ICompanyManager companyManager;

        public CommandFactory(ICompanyManager companyManager)
        {
            this.CompanyManager = companyManager;
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

        public ICommand CreateCommand(string commandName)
        {
            switch (commandName)
            {
                case CommandValues.CreateCompanyCommandString: return new CreateCompanyCommand(companyManager);
                case CommandValues.CreateDepartmentCommandString: return new CreateDepartmentCommand(companyManager);
                case CommandValues.CreateEmployeeCommandString: return new CreateEmployeeCommand(companyManager);
                case CommandValues.PaySalaryCommandString: return new PaySalaryCommand(companyManager);
                case CommandValues.ShowEmployeesCommandString: return new ShowEmployeesCommand(companyManager);
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }
    }
}
