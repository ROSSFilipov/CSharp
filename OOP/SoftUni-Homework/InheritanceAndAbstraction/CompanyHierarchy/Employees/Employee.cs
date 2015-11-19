using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyHierarchy.Interfaces;
using System.Text.RegularExpressions;

namespace CompanyHierarchy.Employees
{
    public abstract class Employee : Person, IEmployee
    {
        private const decimal BASE_SALARY = 100m;
        private const string BASE_DEPARTMENT = "Sales";

        private string department;

        private decimal salary;

        protected Employee(string firstName, string lastName, long id, string department, decimal salary)
            : base(firstName, lastName, id)
        {
            this.Department = department;
            this.Salary = salary;
        }

        protected Employee(string firstName, string lastName, long id)
            : base(firstName, lastName, id)
        {
            this.Department = BASE_DEPARTMENT;
            this.Salary = BASE_SALARY;
        }

        protected Employee()
            : base()
        {
            this.Department = BASE_DEPARTMENT;
            this.Salary = BASE_SALARY;
        }

        public string Department
        {
            get
            {
                return this.department;
            }
            set
            {
                Regex pattern = new Regex("Production|Accounting|Sales|Marketing");
                if (!pattern.IsMatch(value))
                {
                    throw new ArgumentOutOfRangeException();
                }

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
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.salary = value;
            }
        }

        public override string ToString()
        {
            return String.Format("[{0} - {1}, {2}, {3}, {4}, {5}]", 
                this.GetType().Name, this.FirstName, this.LastName, this.ID, this.Department, this.Salary);
        }
    }
}
