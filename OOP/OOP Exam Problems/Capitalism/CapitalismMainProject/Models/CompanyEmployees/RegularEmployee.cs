using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapitalismMainProject.Interfaces;

namespace CapitalismMainProject.Models.CompanyEmployees
{
    public class RegularEmployee : Employee, IRegularEmployee
    {
        public RegularEmployee(string firstName, string lastName, decimal salary)
            : base(firstName, lastName, salary)
        {
        }

        public RegularEmployee(string firstName, string lastName)
            : base(firstName, lastName)
        {

        }
    }
}
