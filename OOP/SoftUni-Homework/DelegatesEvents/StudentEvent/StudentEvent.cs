using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvent
{
    class StudentEvent
    {
        static void Main(string[] args)
        {
            Student.NameChangeEvent += NameChangeReport;
            Student.NameChangeEvent += AgeChangeReport;

            Student student = new Student("Ivan", 20);

            student.Name = "Petko";
            student.Age = 10;
        }

        private static void NameChangeReport(Student student, PropertyChangeArguments args)
        {
            Console.WriteLine("Name changed from {0} to {1}!",
                args.OldValue, args.NewValue);
        }

        private static void AgeChangeReport(Student student, PropertyChangeArguments args)
        {
            Console.WriteLine("Studen {0} age changed from {1} to {2}!",
                student.Name, args.OldValue, args.NewValue);
        }
    }
}
