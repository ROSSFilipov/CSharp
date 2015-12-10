using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapitalismMainProject.Interfaces;

namespace CapitalismMainProject.ControlCenter.Commands
{
    public abstract class Command : ICommand
    {
        private ICompanyManager companyManager;

        protected Command(ICompanyManager companyManager)
        {
            this.CompanyManager = companyManager;
        }

        protected ICompanyManager CompanyManager
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

        public abstract void Execute(string[] commandArguments);
    }
}
