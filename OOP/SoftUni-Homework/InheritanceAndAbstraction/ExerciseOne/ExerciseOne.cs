using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOne
{
    class ExerciseOne
    {
        static void Main(string[] args)
        {
            Book one = new Book("The Sea Wolf", "Jack London", 11.12m);
            GoldenEditionBook two = new GoldenEditionBook("Martin Eden", "Jack London", 88m);
            Console.WriteLine(one);
            Console.WriteLine(two);
            Console.WriteLine("Book {0} original price:", two.Title);
            Console.WriteLine(two.OriginalPrice);
        }
    }
}
