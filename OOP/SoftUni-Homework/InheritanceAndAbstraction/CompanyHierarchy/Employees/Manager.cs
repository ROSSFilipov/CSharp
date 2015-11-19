using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy.Employees
{
    public class Manager : Employee, IManager
    {
        private HashSet<Employee> employeeSet;

        public Manager(string firstName, string lastName, long id, string department, decimal salary)
            : base(firstName, lastName, id, department, salary)
        {
            this.EmployeSet = new HashSet<Employee>();
        }

        public Manager(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        {
            this.EmployeSet = new HashSet<Employee>();
        }

        public Manager()
            : base()
        {
            this.EmployeSet = new HashSet<Employee>();
        }

        public HashSet<Employee> EmployeSet
        {
            get
            {
                return this.employeeSet;
            }
            set
            {
                this.employeeSet = new HashSet<Employee>();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("[{0} - {1}, {2}, {3}]", 
                this.GetType().Name, this.FirstName, this.LastName, this.ID));
            foreach (Employee item in this.EmployeSet)
            {
                sb.AppendLine(String.Format("\t{0} - {1}, {2}, Department - {3}, Salary - {4}", 
                    item.GetType().Name, item.FirstName, item.LastName, item.Department, item.Salary));
            }

            return sb.ToString();
        }
    }
}
