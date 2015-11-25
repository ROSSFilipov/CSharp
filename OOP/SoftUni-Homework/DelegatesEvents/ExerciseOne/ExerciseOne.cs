namespace ExerciseOne
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ExerciseOne
    {
        static void Main(string[] args)
        {
            List<int> collection = new List<int>() { 55, 76, 123, 4, 56, 67, 78 };

            Predicate<int> isBiggerThanOne = x => x > 1;
            Predicate<int> isOdd = x => x % 2 != 0;

            Console.WriteLine("First number which is bigger than 1 in the collection: {0}", 
                collection.FirstOrDefault(isBiggerThanOne));
            Console.WriteLine("All odd numbers in the collection: {0}", 
                collection.FirstOrDefault(isOdd));

            Func<int, bool> biggerThanTen = x => x > 10;
            Func<int, int, int> addFunc = (x, y) => x + y;
            Func<int, int> addTen = x => x + 10;

            Console.WriteLine(String.Join(", ", collection.TakeWhile(biggerThanTen)));
            Console.WriteLine(addFunc.Invoke(5, 6));

            Action<int> action = (x) => Console.WriteLine(x); ;
            collection.ForEach(action);

            var result = collection.Select(addTen);
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
