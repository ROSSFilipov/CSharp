using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.Interfaces
{
    public interface ICompanyManager
    {
        IEnumerable<ICompany> Companies { get; }

        ICommandManager CommandManager { get; }

        IEmployeeFactory EmployeeFactory { get; }

        IDepartmentFactory DepartmentFactory { get; }

        void Run();

        void AddCompany(ICompany companyToBeAdded);

        IDepartment GetDepartmentByName(ICompany company, string departmentName);

        IEmployee GetEmployeeByName(ICompany company, string firstName, string lastName);
    }
}
