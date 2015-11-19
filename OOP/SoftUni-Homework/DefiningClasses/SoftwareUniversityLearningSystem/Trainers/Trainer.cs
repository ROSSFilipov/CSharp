using SoftwareUniversityLearningSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareUniversityLearningSystem.Trainers
{
    public abstract class Trainer : Person, ITrainer
    {
        protected Trainer(string firstName, string lastName, int age) 
            : base(firstName, lastName, age)
        {

        }

        protected Trainer() : base()
        {

        }

        public virtual void CreateCourse(string courseName)
        {
            Console.WriteLine("The course {0} has been created!", courseName);
        }
    }
}
