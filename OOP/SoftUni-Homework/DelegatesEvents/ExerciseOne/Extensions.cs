namespace ExerciseOne
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Extensions
    {
        public static T FirstOrDefault<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            foreach (var item in collection)
            {
                if (condition(item) == true)
                {
                    return item;
                }
            }

            return default(T);
        }

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> collection, Func<T, bool> condition)
        {
            List<T> newCollection = new List<T>();

            foreach (var item in collection)
            {
                if (condition(item) == true)
                {
                    newCollection.Add(item);
                }
                else
                {
                    break;
                }
            }

            return newCollection;
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }

        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> originalCollection, Func<T, bool> customFunction)
        {
            List<T> newCollection = new List<T>();

            foreach (T item in originalCollection)
            {
                if (!customFunction(item))
                {
                    newCollection.Add(item);
                }
            }

            return newCollection;
        }

        public static K FindMax<T, K>(this IEnumerable<T> originalCollection, Func<T, K> customFunction)
            where K : IComparable<K>
        {
            //K maxValue = customFunction(originalCollection.First());

            //foreach (T item in originalCollection)
            //{
            //    if (maxValue.CompareTo(customFunction(item)) < 0)
            //    {
            //        maxValue = customFunction(item);
            //    }
            //}

            //return maxValue;

            K max = originalCollection.Max(x => customFunction(x));
            return max;
        }
    }
}
