using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareUniversityLearningSystem.Students
{
    public class CurrentStudent : Student
    {
        private string currentCourse;

        private const string BASE_COURSE = "Basic course";

        public CurrentStudent(string firstName, string lastName, int age, long studentNumber, decimal averageGrade, string courseName) 
            : base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.currentCourse = courseName;
        }

        public CurrentStudent(string firstName, string lastName, int age, long studentNumber, decimal averageGrade) 
            : base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.currentCourse = BASE_COURSE;
        }

        public CurrentStudent(string firstName, string lastName, int age, string courseName)
            : base(firstName, lastName, age)
        {
            this.CurrentCourse = courseName;
        }

        public CurrentStudent(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        {
            this.CurrentCourse = BASE_COURSE;
        }

        public CurrentStudent() 
            : base()
        {

        }

        public string CurrentCourse
        {
            get
            {
                return this.currentCourse;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Curse name cannot be empty!");
                }
                this.currentCourse = value;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
