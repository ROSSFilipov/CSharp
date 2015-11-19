using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareUniversityLearningSystem.Students
{
    public class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string firstName, string lastName, int age, long studentNumber, decimal averageGrade, string courseName)
            : base(firstName, lastName, age, studentNumber, averageGrade, courseName)
        {

        }

        public OnlineStudent(string firstName, string lastName, int age, string courseName)
            : base(firstName, lastName, age, courseName)
        {

        }

        public OnlineStudent(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        {

        }

        public OnlineStudent()
            : base()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
