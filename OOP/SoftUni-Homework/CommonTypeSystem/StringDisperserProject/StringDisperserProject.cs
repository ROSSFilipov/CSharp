using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDisperserProject
{
    class StringDisperserProject
    {
        static void Main(string[] args)
        {
            StringDisperser stringDisperser = new StringDisperser("gosho", "pesho", "tanio");

            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");
            }
        }
    }
}
