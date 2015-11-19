using SoftwareUniversityLearningSystem.Interfaces;
using SoftwareUniversityLearningSystem.Students;
using SoftwareUniversityLearningSystem.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareUniversityLearningSystem
{
    public class SULSTest
    {
        public void Run()
        {
            var personData = new List<IPerson>();
            personData.Add(new JuniorTrainer("Ivan", "Ivanov", 40));
            personData.Add(new CurrentStudent("Bob", "Bobbed", 90));
            personData.Add(new DropoutStudent("Yu", "Chi Min", 86, "Too old for this game"));
            personData.Add(new OnlineStudent("Petko", "Voivoda", 1120, 8887675, 56.65m, "Haidutstvo"));
            personData.Add(new OnlineStudent("Pesho", "Peshev", 2, 00535, 44.5m, "Mathematics"));
            personData.Add(new OnlineStudent("Gosho", "Goshev", 3, 23244, 2.78m, "Sport"));

            var currentStudentData = personData
                .Where(x => x is CurrentStudent)
                .Select(x => x as CurrentStudent)
                .OrderBy(x => x.AverageGrade);


            foreach (CurrentStudent student in currentStudentData)
            {
                Console.WriteLine(student);
            }

            //personData
            //    .OfType<CurrentStudent>()
            //    .OrderBy(x => x.AverageGrade)
            //    .ToList()
            //    .ForEach(x => Console.WriteLine(x));
        }
    }
}
