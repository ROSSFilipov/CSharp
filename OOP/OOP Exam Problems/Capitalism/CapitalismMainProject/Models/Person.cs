using CapitalismMainProject.ControlCenter;
using CapitalismMainProject.ControlCenter.Exceptions;
using CapitalismMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.Models
{
    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;

        protected Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (ControlPanel.GlobalNameValidation)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new EmployeeNameException(CustomMessages.InvalidNameMessage);
                    }
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (ControlPanel.GlobalNameValidation)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new EmployeeNameException(CustomMessages.InvalidNameMessage);
                    }
                }

                this.lastName = value;
            }
        }
    }
}
