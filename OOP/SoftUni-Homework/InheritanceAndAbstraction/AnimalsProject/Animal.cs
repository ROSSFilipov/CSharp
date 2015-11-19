using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsProject.Interfaces;

namespace AnimalsProject
{
    public abstract class Animal : ISoundProducible
    {
        private const string BASE_NAME = "Unknown name";
        private const int BASE_AGE = 1;

        private string name;

        private int age;

        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Animal()
            : this(BASE_NAME, BASE_AGE)
        {

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid name!");
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
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Invalid age!");
                }

                this.age = value;
            }
        }

        public abstract void ProduceSound();

        public override string ToString()
        {
            return String.Format("{0}:\nName: {1}\nAge: {2}", 
                this.GetType().Name, this.Name, this.Age);
        }
    }
}
