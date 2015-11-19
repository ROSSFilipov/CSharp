using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareUniversityLearningSystem.Students
{
    public class OnsiteStudent : CurrentStudent
    {
        private int numberOfVisits;

        private const int BASE_VISITS = 1;

        public OnsiteStudent(string firstName, string lastName, int age, long studentNumber, decimal averageGrade, string courseName, int visits)
            : base(firstName, lastName, age, studentNumber, averageGrade, courseName)
        {
            this.numberOfVisits = visits;
        }

        public OnsiteStudent(string firstName, string lastName, int age, long studentNumber, decimal averageGrade, string courseName)
            : base(firstName, lastName, age, studentNumber, averageGrade, courseName)
        {
            this.numberOfVisits = BASE_VISITS;
        }

        public OnsiteStudent()
            : base()
        {
            this.numberOfVisits = BASE_VISITS;
        }

        public int NumberOfVisits
        {
            get
            {
                return this.numberOfVisits;
            }
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Number of visits cannot be negative!");
                }
                this.numberOfVisits = value;
            }
        }
    }
}
