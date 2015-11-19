using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HumanStudentWorker
{
    public class Student : Human
    {
        private const string BASE_NUMBER = "000000001";

        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) 
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public Student()
            : base()
        {
            this.facultyNumber = BASE_NUMBER;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            set
            {
                Regex pattern = new Regex(@"([\w\d]+){5,10}");
                if (!pattern.IsMatch(value))
                {
                    throw new FormatException("The faculty number should consist of letters and/or digits and should be between 5 and 10 characters long.");
                }

                this.facultyNumber = value;
            }
        }
    }
}
