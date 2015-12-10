using CapitalismMainProject.ControlCenter.Exceptions;
using CapitalismMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.ControlCenter.Commands
{
    public class PaySalaryCommand : Command
    {
        public PaySalaryCommand(ICompanyManager companyManager)
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

            currentCompany.CEO.Salary += currentCompany.CeoSalary;
            decimal ceoSalary = currentCompany.CEO.Salary;

            foreach (IDepartment currentDepartment in currentCompany.Departments)
            {
                this.DistributeSalaries(currentDepartment, ceoSalary, 15);
            }
        }

        private void DistributeSalaries(IDepartment currentDepartment, decimal salary, int decreaseIndex)
        {
            decimal currentManagerSalary = salary * (decreaseIndex) / 100;

            foreach (IEmployee currentEmployee in currentDepartment.Employees)
            {
                if (currentEmployee is IManager)
                {
                    currentEmployee.Salary = currentManagerSalary;
                }
                else if (currentEmployee is ICleaningLady || currentEmployee is IChiefTelephoneOfficer)
                {
                    decimal currentCleaningLadySalary = salary * (decreaseIndex - 3) / 100;
                    currentEmployee.Salary = currentCleaningLadySalary;
                }
                else if (currentEmployee is ISalesman)
                {
                    decimal currentSalesmanSalary = salary * (decreaseIndex + 1.5m - 1) / 100;
                    currentEmployee.Salary = currentSalesmanSalary;
                }
                else
                {
                    decimal currentRegularSalary = salary * (decreaseIndex - 1) / 100;
                    currentEmployee.Salary = currentRegularSalary;
                }
            }

            foreach (IDepartment subDepartment in currentDepartment.SubDepartments)
            {
                DistributeSalaries(subDepartment, salary, decreaseIndex - 1);
            }
        }
    }
}
