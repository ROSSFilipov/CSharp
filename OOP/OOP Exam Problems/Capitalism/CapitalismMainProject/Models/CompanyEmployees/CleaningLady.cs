using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapitalismMainProject.Interfaces;

namespace CapitalismMainProject.Models.CompanyEmployees
{
    public class CleaningLady : Employee, ICleaningLady
    {
        public CleaningLady(string firstName, string lastName, decimal salary)
            : base(firstName, lastName, salary)
        {
        }

        public CleaningLady(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public void Clean(IDepartment departmentToBeCleaned)
        {
            throw new NotImplementedException();
        }
    }
}
