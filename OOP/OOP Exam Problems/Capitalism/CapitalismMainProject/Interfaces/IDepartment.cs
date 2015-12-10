using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.Interfaces
{
    public interface IDepartment
    {
        string Name { get; set; }

        ICompany Company { get; set; }

        IManager Manager { get; set; }

        IEnumerable<IEmployee> Employees { get; }

        IEnumerable<IDepartment> SubDepartments { get; }

        bool IsCleaned { get; set; } //!

        void AddEmployee(IEmployee employeeToBeAdded);

        void AddSubDepartment(IDepartment departmentToBeAdded);

        void RemoveEmployee(IEmployee employeeToBeRemoved);
    }
}
