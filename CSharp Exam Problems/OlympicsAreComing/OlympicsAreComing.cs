using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class OlympicsAreComing
{
    static void Main(string[] args)
    {
        string[] initial = Console.ReadLine().Split('|');
        Dictionary<string, Dictionary<string, int>> collection = new Dictionary<string, Dictionary<string, int>>();
        while (initial[0] != "report")
        {
            string name = initial[0].Trim();
            string country = initial[1].Trim();
            Regex pattern = new Regex(@"\s+");
            name = pattern.Replace(name, " ");
            country = pattern.Replace(country, " ");

            if (!collection.ContainsKey(country))
            {
                collection.Add(country, new Dictionary<string, int>());
                collection[country].Add(name, 1);
            }
            else
            {
                if (!collection[country].ContainsKey(name))
                {
                    collection[country].Add(name, 1);
                }
                else
                {
                    collection[country][name]++;
                }
            }
            initial = Console.ReadLine().Split('|');
        }
        var sorted = collection.Select(x => new { name = x.Key, sum = x.Value.Values.Sum(), count = x.Value.Keys.Count }).OrderByDescending(x => x.sum);
        foreach (var item in sorted)
        {
            Console.WriteLine("{0} ({1} participants): {2} wins", item.name, item.count, item.sum);
        }
    }
}

