using CapitalismMainProject.ControlCenter.Exceptions;
using CapitalismMainProject.Interfaces;
using CapitalismMainProject.Models.CompanyDepartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.ControlCenter.Commands
{
    public class CreateDepartmentCommand : Command
    {
        public CreateDepartmentCommand(ICompanyManager companyManager)
            : base(companyManager)
        {
        }

        public override void Execute(string[] commandArguments)
        {
            ICompany currentCompany = this.CompanyManager.Companies.FirstOrDefault(x => x.Name == commandArguments[1]);

            if (currentCompany == null)
            {
                throw new CompanyNullException(CustomMessages.CompanyNullMessage);
            }

            IDepartment currentDepartment = this.CompanyManager.GetDepartmentByName(currentCompany, commandArguments[2]);

            if (currentDepartment != null)
            {
                throw new DepartmentNullException(CustomMessages.DepartmentNullMessage);
            }

            if (commandArguments.Length == 4)
            {
                IDepartment mainDepartment = this.CompanyManager.GetDepartmentByName(currentCompany, commandArguments[3]);

                if (mainDepartment == null)
                {
                    throw new DepartmentNullException(CustomMessages.DepartmentNullMessage);
                }

                mainDepartment.AddSubDepartment(new Department(currentCompany, commandArguments[2]));
            }
            else
            {
                currentCompany.AddDepartment(new Department(currentCompany, commandArguments[2]));
            }
        }
    }
}
