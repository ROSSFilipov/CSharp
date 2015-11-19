using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    class Persons
    {
        static void Main(string[] args)
        {
            Person d = new Person("P", 20);
            Console.WriteLine(d);
            Person x = new Person("X", 100, "none@abv.bg");
            Console.WriteLine(x);
        }
    }
}
