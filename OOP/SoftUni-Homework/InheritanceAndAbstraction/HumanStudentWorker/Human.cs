using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentWorker
{
    public abstract class Human
    {
        private const string BASE_FIRST_NAME = "Unknown first name";
        private const string BASE_LAST_NAME = "Unknown last name";

        private string firstName;

        private string lastName;

        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        protected Human() 
            : this(BASE_FIRST_NAME, BASE_LAST_NAME)
        {

        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Person's first name cannot be empty.");
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Person's last name cannot be empty.");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Person:\n\t{0}\n\t{1}", this.FirstName, this.LastName);
        }
    }
}
