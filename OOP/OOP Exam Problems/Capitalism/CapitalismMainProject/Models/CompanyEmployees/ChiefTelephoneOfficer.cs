using CapitalismMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.Models.CompanyEmployees
{
    public class ChiefTelephoneOfficer : Employee, IChiefTelephoneOfficer
    {
        public ChiefTelephoneOfficer(string firstName, string lastName, decimal salary)
            : base(firstName, lastName, salary)
        {
        }

        public ChiefTelephoneOfficer(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public void PickUpThePhone()
        {
            throw new NotImplementedException();
        }
    }
}
