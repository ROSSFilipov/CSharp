using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsProject.Interfaces;

namespace AnimalsProject.Cats
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string furColour) 
            : base(name, age, furColour)
        {

        }

        public Kitten(string name, int age)
            : base(name, age)
        {

        }

        public Kitten()
            : base()
        {

        }
    }
}
