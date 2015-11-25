using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciseOne;

namespace CustomExtensionMethods
{
    public class CustomExtensionMethods
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9};
            Func<int, bool> notEven = x => x % 2 == 0;
            Console.WriteLine("Numbers not divideable by 2 with zero reminder : {0}", 
                string.Join(", ", numbers.WhereNot(notEven)));

            List<Student> students = new List<Student>();
            students.Add(new Student("Ivan", 10));
            students.Add(new Student("Petko", 22));
            students.Add(new Student("Petar", 30));

            Func<Student, int> customStudentFunc = x => x.Grade;
            int max = students.FindMax(customStudentFunc);
            Console.WriteLine("Highest grade : {0}", max);
        }
    }
}
