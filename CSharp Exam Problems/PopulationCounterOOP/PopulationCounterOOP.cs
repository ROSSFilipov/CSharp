using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationCounterOOP
{
    public class City
    {
        public string Name { get; set; }

        public long Population { get; set; }

        public City(string name, long population)
        {
            this.Name = name;
            this.Population = population;
        }
    }

    public class Country
    {
        public string Name { get; set; }

        public List<City> Cities { get; set; }

        public Country(string name)
        {
            this.Name = name;
            this.Cities = new List<City>();
        }

        public long TotalPopulation()
        {
            long population = this.Cities.Sum(x => x.Population);

            return population;
        }
    }

    public static class Extensions
    {
        public static bool ContainsCountry(this List<Country> countryList, Country currentCountry)
        {
            foreach (Country item in countryList)
            {
                if (item.Name == currentCountry.Name)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ContainsCity(this List<City> cityList, City currentCity)
        {
            foreach (City item in cityList)
            {
                if (item.Name == currentCity.Name)
                {
                    return true;
                }
            }

            return false;
        }

        public static Country Country(this List<Country> countryList, Country currentCountry)
        {
            int index = 0;

            for (int i = 0; i < countryList.Count; i++)
            {
                if (countryList[i].Name == currentCountry.Name)
                {
                    index = i;
                    break;
                }
            }

            return countryList.ElementAt(index);
        }

        public static City City(this List<City> cityList, City currentCity)
        {
            int index = 0;

            for (int i = 0; i < cityList.Count; i++)
            {
                if (cityList[i].Name == currentCity.Name)
                {
                    index = i;
                    break;
                }
            }

            return cityList.ElementAt(index);
        }
    }

    class PopulationCounterOOP
    {
        static void Main(string[] args)
        {
            List<Country> countryCollection = new List<Country>();

            while (true)
            {
                string[] currentLine = Console.ReadLine().Split('|');

                if (currentLine[0] == "report")
                {
                    break;
                }

                string countryName = currentLine[1];
                string cityName = currentLine[0];
                long population = long.Parse(currentLine[2]);

                City currentCity = new City(cityName, population);
                Country currentCountry = new Country(countryName);

                if (!countryCollection.ContainsCountry(currentCountry))
                {
                    currentCountry.Cities.Add(currentCity);
                    countryCollection.Add(currentCountry);
                }
                else
                {
                    if (!countryCollection.Country(currentCountry).Cities.ContainsCity(currentCity))
                    {
                        countryCollection.Country(currentCountry).Cities.Add(currentCity);
                    }
                    else
                    {
                        countryCollection.Country(currentCountry).Cities.City(currentCity).Population += population;
                    }
                }
            }

            var sortedCountries = countryCollection.OrderByDescending(x => x.TotalPopulation());

            foreach (Country currentCountry in sortedCountries)
            {
                Console.WriteLine("{0} (total population: {1})", currentCountry.Name, currentCountry.TotalPopulation());

                var sortedCities = currentCountry.Cities.OrderByDescending(x => x.Population).ThenBy(x => x.Name);

                foreach (City currentCity in sortedCities)
                {
                    Console.WriteLine("=>{0}: {1}", currentCity.Name, currentCity.Population);
                }
            }
        }
    }
}
