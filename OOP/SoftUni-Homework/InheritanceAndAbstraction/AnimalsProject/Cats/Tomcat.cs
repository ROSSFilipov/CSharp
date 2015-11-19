using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalsProject.Interfaces;

namespace AnimalsProject.Cats
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string furColour) 
            : base(name, age, furColour)
        {

        }

        public Tomcat(string name, int age)
            : base(name, age)
        {
            
        }

        public Tomcat()
            : base()
        {

        }
    }
}
