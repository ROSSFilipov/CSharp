using CapitalismMainProject.ControlCenter;
using CapitalismMainProject.ControlCenter.ConstantValues;
using CapitalismMainProject.ControlCenter.Exceptions;
using CapitalismMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.Models
{
    public class Company : ICompany
    {
        private string name;
        private ICEO ceo;
        private IList<IDepartment> departments;
        private decimal ceoSalary;

        public Company(string name, ICEO ceo, decimal ceoSalary)
        {
            this.Name = name;
            this.CEO = ceo;
            this.departments = new List<IDepartment>();
            this.CeoSalary = ceoSalary;
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
                        throw new CompanyNameException(CustomMessages.InvalidNameMessage);
                    }
                }

                this.name = value;
            }
        }

        public ICEO CEO
        {
            get
            {
                return this.ceo;
            }
            set
            {
                this.ceo = value;
            }
        }

        public IEnumerable<IDepartment> Departments
        {
            get { return this.departments; }
        }

        public void AddDepartment(IDepartment departmentToBeAdded)
        {
            this.departments.Add(departmentToBeAdded);
        }

        public decimal CeoSalary
        {
            get
            {
                return this.ceoSalary;
            }
            private set
            {
                if (ControlPanel.GlobalSalaryValidation)
                {
                    if (value < EmployeeValues.SalaryMinValue)
                    {
                        throw new SalaryException(CustomMessages.InvalidSalaryMessage);
                    }
                }

                this.ceoSalary = value;
            }
        }
    }
}
