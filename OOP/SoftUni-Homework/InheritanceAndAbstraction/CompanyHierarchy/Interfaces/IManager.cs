using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyHierarchy.Employees;

namespace CompanyHierarchy.Interfaces
{
    public interface IManager
    {
        HashSet<Employee> EmployeSet { get; set; }
    }
}
