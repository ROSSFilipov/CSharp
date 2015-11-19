using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsProject.Interfaces;

namespace AnimalsProject.Cats
{
    public class Cat : Animal
    {
        private const string BASE_FUR_COLOUR = "Unknown colour";
        private string furColour;

        public Cat(string name, int age, string furColour) 
            : base(name, age)
        {
            this.FurColour = furColour;
        }

        public Cat(string name, int age)
            : base(name, age)
        {
            this.FurColour = BASE_FUR_COLOUR;
        }

        public Cat()
            : base()
        {
            this.FurColour = BASE_FUR_COLOUR;
        }

        public string FurColour
        {
            get
            {
                return this.furColour;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.furColour = value;
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} says Meow!", this.GetType().Name);
        }
    }
}
