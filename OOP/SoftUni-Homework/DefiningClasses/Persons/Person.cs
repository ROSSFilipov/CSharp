using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Persons
{
    public class Person
    {
        private string name;

        private int age;

        private string email;

        private const string BASE_EMAIL = "missing information";

        public Person(string name, int age, string email)
        {
            this.NameSet = name;
            this.AgeSet = age;
            this.EmailSet = email;
        }

        public Person(string name, int age)
            : this(name, age, BASE_EMAIL)
        {

        }

        public string NameSet
        {
            get
            {
                return this.name;
            }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid name!");
                }
                this.name = value;
            }
        }

        public int AgeSet
        {
            get
            {
                return this.age;
            }
            set 
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Invalid age!");
                }
                this.age = value;
            }
        }

        public string EmailSet
        {
            get
            {
                return this.email;
            }
            set
            {
                //Regex pattern = new Regex("([^@!\'\"]+)@([^@!\'\"]+)");
                //if (string.IsNullOrEmpty(value) || !pattern.IsMatch(value))
                //{
                //    throw new ArgumentOutOfRangeException("Invalid e-mail address!");
                //}
                this.email = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, age: {1}, e-mail address: {2}.", this.NameSet, this.AgeSet, this.EmailSet);
        }
    }
}
