using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.Interfaces
{
    public interface ICompany
    {
        string Name { get; set; }

        ICEO CEO { get; set; }

        decimal CeoSalary { get; }

        IEnumerable<IDepartment> Departments { get; }

        void AddDepartment(IDepartment departmentToBeAdded);
    }
}
