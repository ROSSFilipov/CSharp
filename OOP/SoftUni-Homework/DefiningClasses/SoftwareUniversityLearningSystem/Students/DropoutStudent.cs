using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareUniversityLearningSystem.Students
{
    public class DropoutStudent : Student
    {
        private string dropoutReason;

        private const string BASE_DROP_REASON = "General reason";

        public DropoutStudent(string firstName, string lastName, int age, string reason)
            : base(firstName, lastName, age)
        {
            this.dropoutReason = reason;
        }

        public DropoutStudent(string firstName, string lastName, int age, long studentNumber, decimal averageGrade) 
            : base(firstName, lastName, age, studentNumber, averageGrade)
        {
            this.dropoutReason = BASE_DROP_REASON;
        }

        public DropoutStudent() : base()
        {
            this.dropoutReason = BASE_DROP_REASON;
        }

        public string DropoutReason
        {
            get
            {
                return this.dropoutReason;
            }
            set
            {
                this.dropoutReason = value;
            }
        }

        public void Reapply()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine("\tDropout reason: {0}", this.DropoutReason);
        }
    }
}
