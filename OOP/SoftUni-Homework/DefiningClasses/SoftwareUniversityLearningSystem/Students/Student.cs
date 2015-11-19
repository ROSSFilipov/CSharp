using SoftwareUniversityLearningSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareUniversityLearningSystem.Students
{
    public abstract class Student : Person, IStudent
    {
        private long studentNumber;

        private decimal averageGrade;

        private const long BASE_NUMBER = 1L;

        private const decimal BASE_GRADE = 1m;

        protected Student() : base()
        {
            this.StudentNumber = BASE_NUMBER;
            this.AverageGrade = BASE_GRADE;
        }

        protected Student(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            this.StudentNumber = BASE_NUMBER;
            this.AverageGrade = BASE_GRADE;
        }

        protected Student(string firstName, string lastName, int age, long studentNumber, decimal averageGrade) 
            : base(firstName, lastName, age)
        {
            this.StudentNumber = studentNumber;
            this.AverageGrade = averageGrade;
        }

        protected Student(long studentNumber, decimal averageGrade) : base()
        {
            this.StudentNumber = studentNumber;
            this.AverageGrade = averageGrade;
        }

        public long StudentNumber
        {
            get
            {
                return this.studentNumber;
            }
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Invalid student number!");
                }
                this.studentNumber = value;
            }
        }

        public decimal AverageGrade
        {
            get
            {
                return this.averageGrade;
            }
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Average grade cannot be negative!");
                }
                this.averageGrade = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}:\n\tFirst name: {1}\n\tLast name: {2}\n\tAge: {3}\n\tStudent number: {4}\n\tAverage grade: {5}", 
                this.GetType().Name, this.FirstName, this.LastName, this.Age, this.StudentNumber, this.AverageGrade);
        }
    }
}
