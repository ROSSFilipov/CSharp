using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTracker
{
    class ActivityTracker
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var collection = new SortedDictionary<int, SortedDictionary<string, decimal>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string[] datetime = input[0].Split(new char[]{'/'}, StringSplitOptions.RemoveEmptyEntries);
                int month = int.Parse(datetime[1]);
                if (collection.ContainsKey(month))
                {
                    if (collection[month].ContainsKey(input[1]))
                    {
                        collection[month][input[1]] += decimal.Parse(input[2]);
                    }
                    else
                    {
                        collection[month].Add(input[1], decimal.Parse(input[2]));
                    }
                }
                else
                {
                    collection.Add(month, new SortedDictionary<string, decimal>());
                    collection[month].Add(input[1], int.Parse(input[2]));
                }
            }

            //Lambda expression works much slower here
            //var sorted = collection.OrderBy(x => x.Key).ThenBy(x => x.Value.Keys);

            //foreach (KeyValuePair<int, SortedDictionary<string, decimal>> item in sorted)
            //{
            //    Console.Write("{0}: ", item.Key);
            //    List<string> temp = new List<string>();
            //    foreach (KeyValuePair<string, decimal> item2 in item.Value)
            //    {
            //        string currentMonthUsers = "" + item2.Key + "(" + item2.Value + ")";
            //        temp.Add(currentMonthUsers);
            //    }
            //    Console.WriteLine("{0}", String.Join(", ", temp));
            //}

            foreach (var item1 in collection)
            {
                Console.Write("{0}: ", item1.Key);
                List<string> temp = new List<string>();
                foreach (var item2 in item1.Value)
                {
                    string xx = "" + item2.Key + "(" + item2.Value + ")";
                    temp.Add(xx);
                }
                Console.WriteLine("{0}", String.Join(", ", temp));
            }
        }
    }
}
