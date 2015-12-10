using CapitalismMainProject.ControlCenter.ConstantValues;
using CapitalismMainProject.ControlCenter.Exceptions;
using CapitalismMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.ControlCenter.Commands
{
    public class ShowEmployeesCommand : Command
    {
        public ShowEmployeesCommand(ICompanyManager companyManager)
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

            Console.WriteLine(currentCompany.CEO);
            foreach (IDepartment currentDepartment in currentCompany.Departments)
            {
                DFSEmployees(currentDepartment, CommandValues.ShowEmployeesSpaceIndex);
            }
        }

        private void DFSEmployees(IDepartment currentDepartment, int spaceIndex)
        {
            if (currentDepartment.Manager != null)
            {
                Console.WriteLine("{0}{1}", new string(' ', spaceIndex), currentDepartment.Manager.ToString());
            }

            foreach (IEmployee employee in currentDepartment.Employees)
            {
                if (!(employee is IManager))
                {
                    Console.WriteLine("{0}{1}", new string(' ', spaceIndex + CommandValues.ShowEmployeesSpaceIndex), employee.ToString()); 
                }
            }

            foreach (IDepartment subDepartment in currentDepartment.SubDepartments)
            {
                DFSEmployees(subDepartment, 2 * spaceIndex);
            }
        }
    }
}
