using CapitalismMainProject.Interfaces;
using CapitalismMainProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.ControlCenter.Commands
{
    public class CreateCompanyCommand : Command
    {
        public CreateCompanyCommand(ICompanyManager companyManager)
            : base(companyManager)
        {
        }

        public override void Execute(string[] commandArguments)
        {
            string companyName = commandArguments[1];
            string ceoFirstName = commandArguments[2];
            string ceoLastName = commandArguments[3];
            decimal ceoSalary = decimal.Parse(commandArguments[4]);

            ICEO currentCeo = this.CompanyManager.EmployeeFactory.CreateCeo(ceoFirstName, ceoLastName);
            ICompany currentCompany = new Company(companyName, currentCeo, ceoSalary);

            this.CompanyManager.AddCompany(currentCompany);
        }
    }
}
