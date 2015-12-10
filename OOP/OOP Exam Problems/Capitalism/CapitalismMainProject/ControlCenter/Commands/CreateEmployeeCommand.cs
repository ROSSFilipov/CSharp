using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapitalismMainProject.ControlCenter.ConstantValues;
using CapitalismMainProject.ControlCenter.Exceptions;
using CapitalismMainProject.Interfaces;
using CapitalismMainProject.Models.CompanyEmployees;

namespace CapitalismMainProject.ControlCenter.Commands
{
    public class CreateEmployeeCommand : Command
    {
        public CreateEmployeeCommand(ICompanyManager companyManager)
            : base(companyManager)
        {
        }

        public override void Execute(string[] commandArguments)
        {
            ICompany currentCompany = this.CompanyManager.Companies.FirstOrDefault(x => x.Name == commandArguments[4]);

            if (currentCompany == null)
            {
                throw new CompanyNullException(CustomMessages.CompanyNullMessage);
            }

            IDepartment currentDepartment = this.CompanyManager.GetDepartmentByName(currentCompany, commandArguments[5]);

            if (currentDepartment == null)
            {
                throw new DepartmentNullException(CustomMessages.DepartmentNullMessage);
            }

            IEmployee currentEmployee = this.CompanyManager.GetEmployeeByName(currentCompany, commandArguments[1], commandArguments[2]);

            if (currentEmployee == null)
            {
                switch (commandArguments[3])
                {
                    case EmployeeValues.ManagerString:
                        IManager managerEmployee = new Manager(commandArguments[1], commandArguments[2]);
                        managerEmployee.Department = currentDepartment;
                        currentDepartment.Manager = managerEmployee;
                        currentDepartment.AddEmployee(managerEmployee);
                        return;
                    case EmployeeValues.RegularEmployeeString:
                        IRegularEmployee regEmployee = new RegularEmployee(commandArguments[1], commandArguments[2]);
                        regEmployee.Department = currentDepartment;
                        currentDepartment.AddEmployee(regEmployee);
                        return;
                    case EmployeeValues.ChiefTelephoneOfficerString:
                        IChiefTelephoneOfficer chiefOfficer = new ChiefTelephoneOfficer(commandArguments[1], commandArguments[2]);
                        chiefOfficer.Department = currentDepartment;
                        currentDepartment.AddEmployee(chiefOfficer);
                        return;
                    case EmployeeValues.CleaningLadyString:
                        ICleaningLady cleaningLady = new CleaningLady(commandArguments[1], commandArguments[2]);
                        cleaningLady.Department = currentDepartment;
                        currentDepartment.AddEmployee(cleaningLady);
                        return;
                    case EmployeeValues.SalesmanString:
                        ISalesman salesMan = new Salesman(commandArguments[1], commandArguments[2]);
                        salesMan.Department = currentDepartment;
                        currentDepartment.AddEmployee(salesMan);
                        return;
                    default:
                        {
                            throw new InvalidOperationException();
                        }
                }
            }

            if (currentEmployee.Department == currentDepartment)
            {
                return;
            }

            currentEmployee.Department.RemoveEmployee(currentEmployee);
            currentEmployee.Department = currentDepartment;

            switch (commandArguments[3])
            {
                case EmployeeValues.ManagerString:
                    currentDepartment.AddEmployee(currentEmployee as Manager);
                    return;
                case EmployeeValues.RegularEmployeeString:
                    currentDepartment.AddEmployee(currentEmployee as RegularEmployee);
                    return;
                case EmployeeValues.ChiefTelephoneOfficerString:
                    currentDepartment.AddEmployee(currentEmployee as ChiefTelephoneOfficer);
                    return;
                case EmployeeValues.CleaningLadyString:
                    currentDepartment.AddEmployee(currentEmployee as CleaningLady);
                    return;
                default:
                    {
                        throw new InvalidOperationException();
                    }
            }
        }
    }
}
