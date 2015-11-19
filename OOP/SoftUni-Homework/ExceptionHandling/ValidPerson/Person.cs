using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidPerson
{
    public class Person
    {
        private string firstName;

        private string lastName;

        private int age;

        public Person(string nameOne, string nameTwo, int age)
        {
            this.FirstName = nameOne;
            this.LastName = nameTwo;
            this.Age = age;
        }

        public Person()
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
                Regex namePattern = new Regex("[A-Z][a-z]+");
                if (!namePattern.IsMatch(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Please enter a valid name!");
                }

                this.firstName = value.Trim();
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
                Regex namePattern = new Regex("[A-Z][a-z]+");
                if (!namePattern.IsMatch(value))
                {
                    throw new ArgumentNullException("value", "Please enter a valid name!");
                }

                this.lastName = value.Trim();
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
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("value", "Person's age must be in the range [0...120]!");
                }

                this.age = value;
            }
        }
    }
}
