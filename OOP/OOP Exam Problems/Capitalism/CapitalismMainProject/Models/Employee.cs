using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapitalismMainProject.ControlCenter;
using CapitalismMainProject.ControlCenter.ConstantValues;
using CapitalismMainProject.ControlCenter.Exceptions;
using CapitalismMainProject.Interfaces;

namespace CapitalismMainProject.Models
{
    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;
        private IDepartment department;

        public Employee(string firstName, string lastName, decimal salary)
            : base(firstName, lastName)
        {
            this.Salary = salary;
        }

        public Employee(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public IDepartment Department
        {
            get
            {
                return this.department;
            }
            set
            {
                this.department = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                if (ControlPanel.GlobalSalaryValidation)
                {
                    if (value < EmployeeValues.SalaryMinValue)
                    {
                        throw new SalaryException(CustomMessages.InvalidSalaryMessage);
                    }
                }

                this.salary = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} ({2:F2})",
                this.FirstName, this.LastName, this.Salary);
        }
    }
}
