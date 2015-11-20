using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLDispatcher
{
    class HTMLDispatcher
    {
        static void Main(string[] args)
        {
            ElementBuilder one = new ElementBuilder("div");
            one.AddAttribute("id", "page");
            Console.WriteLine(one);
            one.AddAttribute("class", "big");
            Console.WriteLine(one);
            one.AddContent("something");
            Console.WriteLine(one);
            Console.WriteLine(one * 2);
        }
    }
}
