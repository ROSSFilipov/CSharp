using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsProject.OtherAnimals
{
    public class Frog : Animal
    {
        public Frog(string name, int age)
            : base(name, age)
        {

        }

        public Frog()
            : base()
        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("{0} says something froggish!", this.GetType().Name);
        }
    }
}
