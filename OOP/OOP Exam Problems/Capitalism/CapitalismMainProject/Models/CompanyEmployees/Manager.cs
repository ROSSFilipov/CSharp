using CapitalismMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.Models.CompanyEmployees
{
    public class Manager : Employee, IManager
    {
        public Manager(string firstName, string lastName, decimal salary)
            : base(firstName, lastName, salary)
        {
        }

        public Manager(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }
    }
}
