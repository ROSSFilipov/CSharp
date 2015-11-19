using SoftwareUniversityLearningSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoftwareUniversityLearningSystem
{
    public abstract class Person : IPerson
    {
        private string firstName;

        private string lastName;

        private int age;

        private static Regex namePattern = new Regex("[A-Z][a-z]+");

        private const string BASE_FIRST_NAME = "Missing first name information";

        private const string BASE_LAST_NAME = "Missing last name information";

        private const int BASE_AGE = 1;

        protected Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        protected Person() : this(BASE_FIRST_NAME, BASE_LAST_NAME, BASE_AGE)
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
                if (string.IsNullOrEmpty(value) || !namePattern.IsMatch(value))
                {
                    throw new ArgumentException("Invalid first name!");
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
                if (string.IsNullOrEmpty(value) || !namePattern.IsMatch(value))
                {
                    throw new ArgumentException("Invalid last name!");
                }
                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Invalid age!");
                }
                this.age = value;
            }
        }
    }
}
