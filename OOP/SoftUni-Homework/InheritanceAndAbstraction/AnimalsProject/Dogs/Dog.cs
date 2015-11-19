using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsProject.Interfaces;

namespace AnimalsProject.Dogs
{
    public class Dog : Animal
    {
        public Dog(string name, int age)
            : base(name, age)
        {

        }

        public Dog()
            : base()
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} says Bau!", this.GetType().Name, this.Name);
        }
    }
}
