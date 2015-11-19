using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy
{
    public abstract class Person : IPerson
    {
        private const string BASE_FIRST_NAME = "Unspecified first name";
        private const string BASE_LAST_NAME = "Unspecified last name";
        private const long BASE_ID = 0001;

        private long id;

        private string firstName;

        private string lastName;

        public Person(string firstName, string lastName, long id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ID = id;
        }

        public Person()
            : this(BASE_FIRST_NAME, BASE_LAST_NAME, BASE_ID)
        {

        }

        public long ID
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }

                this.id = value;
            }
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
                    throw new ArgumentNullException();
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
                    throw new ArgumentNullException();
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return String.Format("[{0} - {1}, {2}, {3}]", this.GetType().Name, this.FirstName, this.LastName, this.ID);
        }
    }
}
