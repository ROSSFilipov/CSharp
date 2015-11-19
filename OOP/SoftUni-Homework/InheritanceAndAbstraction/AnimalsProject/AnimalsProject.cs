using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsProject.Cats;
using AnimalsProject.Dogs;
using AnimalsProject.OtherAnimals;

namespace AnimalsProject
{
    class AnimalsProject
    {
        static void Main(string[] args)
        {
            List<Animal> animalCollection = new List<Animal>();
            animalCollection.Add(new Frog("Tom", 21));
            animalCollection.Add(new Tomcat("Pesho", 10));
            animalCollection.Add(new Kitten("Fyfy", 15));
            animalCollection.Add(new Dog("Barnie", 22));
            animalCollection.Add(new Dog("Fred", 8));
            animalCollection.Add(new Frog("Tom 2", 21));
            animalCollection.Add(new Frog("Tom 22", 21));

            int catAverage = animalCollection.Where(x => x is Cat).Sum(y => y.Age) / animalCollection.Count(x => x is Cat);
            int otherAverage = animalCollection.Where(x => !(x is Cat)).Sum(y => y.Age) / animalCollection.Count(x => !(x is Cat));

            Console.WriteLine("Cats average age is: {0}", catAverage);
            Console.WriteLine("Other animals average age is: {0}", otherAverage);
        }
    }
}
