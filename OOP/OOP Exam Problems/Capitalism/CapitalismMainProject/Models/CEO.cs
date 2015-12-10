using CapitalismMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapitalismMainProject.ControlCenter;
using CapitalismMainProject.ControlCenter.Exceptions;
using CapitalismMainProject.ControlCenter.ConstantValues;

namespace CapitalismMainProject.Models
{
    public class CEO : Employee, ICEO
    {
        private ICompany company;

        public CEO(string firstName, string lastName)
            : base(firstName, lastName)
        {
            this.Company = company;
        }

        public ICompany Company
        {
            get
            {
                return this.company;
            }
            private set
            {
                this.company = value;
            }
        }
    }
}
