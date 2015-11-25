using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExtensionMethods
{
    public class Student
    {
        public string Name { get; set; }

        public int Grade { get; set; }

        public Student(string name, int grade)
        {
            this.Name = name;
            this.Grade = grade;
        }
    }
}
