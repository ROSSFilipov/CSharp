using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapitalismMainProject.ControlCenter;
using CapitalismMainProject.ControlCenter.ConstantValues;
using CapitalismMainProject.ControlCenter.Exceptions;
using CapitalismMainProject.Models.CompanyEmployees;
using CapitalismMainProject.Interfaces;

namespace CapitalismMainProject.Models.CompanyDepartments
{
    public class Department : IDepartment
    {
        private string name;
        private ICompany company;
        private IManager manager;
        private IList<IEmployee> employees;
        private IList<IDepartment> subDepartments;
        private bool isCleaned;

        public Department(ICompany company, string name)
        {
            this.Company = company;
            this.Name = name;
            this.employees = new List<IEmployee>();
            this.subDepartments = new List<IDepartment>();
            this.IsCleaned = false;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (ControlPanel.GlobalNameValidation)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new EmployeeNameException(CustomMessages.InvalidNameMessage);
                    }
                }

                this.name = value;
            }
        }

        public IEnumerable<IEmployee> Employees
        {
            get
            {
                return this.employees;
            }
        }

        public ICompany Company
        {
            get
            {
                return this.company;
            }
            set
            {
                this.company = value;
            }
        }

        public bool IsCleaned
        {
            get
            {
                return this.isCleaned;
            }
            set
            {
                this.isCleaned = value;
            }
        }

        public IManager Manager
        {
            get
            {
                return this.manager;
            }
            set
            {
                this.manager = value;
            }
        }

        public void AddEmployee(IEmployee employeeToBeAdded)
        {
            this.employees.Add(employeeToBeAdded);
        }

        public IEnumerable<IDepartment> SubDepartments
        {
            get { return this.subDepartments; }
        }

        public void AddSubDepartment(IDepartment departmentToBeAdded)
        {
            this.subDepartments.Add(departmentToBeAdded);
        }

        public void RemoveEmployee(IEmployee employeeToBeRemoved)
        {
            this.employees.Remove(employeeToBeRemoved);
        }
    }
}
