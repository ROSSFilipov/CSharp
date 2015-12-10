using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapitalismMainProject.ControlCenter.ConstantValues;
using CapitalismMainProject.Interfaces;
using CapitalismMainProject.Models;
using CapitalismMainProject.Models.CompanyEmployees;
using CapitalismMainProject.ControlCenter.Exceptions;

namespace CapitalismMainProject.ControlCenter.Factories
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public EmployeeFactory()
        {

        }

        public ICEO CreateCeo(string firstName, string lastName)
        {
            return new CEO(firstName, lastName);
        }

        public IEmployee CreateEmployee(string employeeType, string firstName, string lastName)
        {
            switch (employeeType)
            {
                case EmployeeValues.ManagerString: return new Manager(firstName, lastName);
                case EmployeeValues.ChiefTelephoneOfficerString: return new ChiefTelephoneOfficer(firstName, lastName);
                case EmployeeValues.CleaningLadyString: return new CleaningLady(firstName, lastName);
                case EmployeeValues.RegularEmployeeString: return new RegularEmployee(firstName, lastName);
                case EmployeeValues.SalesmanString: return new Salesman(firstName, lastName);
                default:
                    {
                        throw new EmployeeTypeException(CustomMessages.InvalidEmployeeTypeMesage);
                    }
            }
        }
    }
}
