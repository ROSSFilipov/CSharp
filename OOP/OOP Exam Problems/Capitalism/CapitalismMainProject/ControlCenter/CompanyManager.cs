using CapitalismMainProject.ControlCenter.Factories;
using CapitalismMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.ControlCenter
{
    public class CompanyManager : ICompanyManager
    {
        private IList<ICompany> companies;

        private ICommandManager commandManager;

        private IEmployeeFactory employeeFactory;

        private IDepartmentFactory departmentFactory;

        public CompanyManager()
        {
            this.CommandManager = new CommandManager(this);
            this.EmployeeFactory = new EmployeeFactory();
            this.DepartmentFactory = new DepartmentFactory();
            this.companies = new List<ICompany>();
        }

        public IEnumerable<ICompany> Companies
        {
            get
            {
                return this.companies;
            }
        }

        public ICommandManager CommandManager
        {
            get
            {
                return this.commandManager;
            }
            private set
            {
                this.commandManager = value;
            }
        }

        public IEmployeeFactory EmployeeFactory
        {
            get { return this.employeeFactory; }
            private set
            {
                this.employeeFactory = value;
            }
        }

        public IDepartmentFactory DepartmentFactory
        {
            get { return this.departmentFactory; }
            private set
            {
                this.departmentFactory = value;
            }
        }

        public virtual void Run()
        {
            while (true)
            {
                string currentLine = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(currentLine))
                {
                    break;
                }

                this.CommandManager.ExecuteCommand(currentLine);
                //this.ShowDepartments();
            }
        }

        public void AddCompany(ICompany companyToBeAdded)
        {
            this.companies.Add(companyToBeAdded);
        }

        public IDepartment GetDepartmentByName(ICompany company, string departmentName)
        {
            Queue<IDepartment> queue = new Queue<IDepartment>();
            foreach (IDepartment department in company.Departments)
            {
                queue.Enqueue(department);
            }

            while (queue.Count != 0)
            {
                IDepartment currentDepartment = queue.Dequeue();

                if (currentDepartment.Name == departmentName)
                {
                    return currentDepartment;
                }

                foreach (IDepartment subDepartment in currentDepartment.SubDepartments)
                {
                    queue.Enqueue(subDepartment);
                }
            }

            return null;
        }

        public IEmployee GetEmployeeByName(ICompany company, string firstName, string lastName)
        {
            Queue<IDepartment> queue = new Queue<IDepartment>();
            foreach (IDepartment department in company.Departments)
            {
                queue.Enqueue(department);
            }

            while (queue.Count != 0)
            {
                IDepartment currentDepartment = queue.Dequeue();

                foreach (IEmployee employee in currentDepartment.Employees)
                {
                    if (employee.FirstName == firstName && employee.LastName == lastName)
                    {
                        return employee;
                    }
                }

                foreach (IDepartment subDepartment in currentDepartment.SubDepartments)
                {
                    queue.Enqueue(subDepartment);
                }
            }

            return null;
        }

        public void ShowDepartments()
        {
            foreach (ICompany company in this.Companies)
            {
                foreach (IDepartment department in company.Departments)
                {
                    DFS(department, 0);
                }
            }
        }

        //A help method which displays the department tree
        private void DFS(IDepartment department, int index)
        {
            Console.WriteLine("{0}->{1}", new string(' ', index), department.Name);

            foreach (IDepartment subDepartment in department.SubDepartments)
            {
                DFS(subDepartment, index + 1);
            }
        }
    }
}
