using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareUniversityLearningSystem.Trainers
{
    public class JuniorTrainer : Trainer
    {
        public JuniorTrainer(string firstName, string lastName, int age) 
            : base(firstName, lastName, age)
        {

        }

        public JuniorTrainer() 
            : base()
        {

        }
    }
}
