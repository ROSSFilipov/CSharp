using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvent
{
    public delegate void OnNameChange(Student subject, PropertyChangeArguments args);

    public class Student
    {
        private string name;
        private int age;

        public static event OnNameChange NameChangeEvent;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != null && this.name != value)
                {
                    NameChangeEvent(this, new PropertyChangeArguments(this.name, value));
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }
    }
}
