using CapitalismMainProject.Interfaces;
using CapitalismMainProject.Models.CompanyDepartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.ControlCenter.Factories
{
    public class DepartmentFactory : IDepartmentFactory
    {
        public DepartmentFactory()
        {

        }

        public IDepartment CreateDepartment(ICompany company, string name)
        {
            return new Department(company, name);
        }
    }
}
