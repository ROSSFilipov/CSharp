using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationCounter
{
    class PopulationCounter
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> collection = new Dictionary<string, Dictionary<string, long>>();

            string[] input = Console.ReadLine().Split('|');

            while (true)
            {
                if (input[0] == "report")
                {
                    break;
                }
                string country = input[1];
                string city = input[0];
                long population = long.Parse(input[2]);

                if (!collection.ContainsKey(country))
                {
                    collection.Add(country, new Dictionary<string,long>());
                    collection[country].Add(city, population);
                }
                else
                {
                    if (!collection[country].ContainsKey(city))
                    {
                        collection[country].Add(city, population);
                    }
                    else
                    {
                        collection[country][city] += population;
                    }
                }
                input = Console.ReadLine().Split('|');
            }
            //var sorted = collection
            //    .Select(x => new { Country = x.Key, CityPop = x.Value.ToDictionary(z => z.Key, z => z.Value), TotalPopulation = x.Value.Values.Sum() })
            //    .OrderByDescending(x => x.TotalPopulation);

            //foreach (var item in sorted)
            //{
            //    Console.WriteLine("{0} (total population: {1})", item.Country, item.TotalPopulation);
            //    var sorted2 = item.CityPop.OrderByDescending(x => x.Value);
            //    foreach (var item2 in sorted2)
            //    {
            //        Console.WriteLine("=>{0}: {1}", item2.Key, item2.Value);
            //    }
            //}
            var temp = collection.OrderByDescending(x => x.Value.Values.Sum());
            foreach (var item in temp)
            {
                Console.WriteLine("{0} (total population: {1})", item.Key, item.Value.Values.Sum());
                var sorted = item.Value.Select(x => new { City = x.Key, Population = x.Value }).OrderByDescending(x => x.Population);
                foreach (var item2 in sorted)
                {
                    Console.WriteLine("=>{0}: {1}", item2.City, item2.Population);
                }
            }
        }
    }
}
