using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public class Country : IComparable<Country>, ICloneable
    {
        private string name;

        private int population;

        private HashSet<string> cities;

        private double area;

        public Country(string name, int population, double area, params string[] cities)
        {
            this.Name = name;
            this.Population = population;
            this.Area = area;
            this.cities = new HashSet<string>();
            foreach (string city in cities)
            {
                this.Cities.Add(city);
            }
        }

        public Country()
        {

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid country name!");
                }

                this.name = value;
            }
        }

        public int Population
        {
            get
            {
                return this.population;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Population cannot be negative!");
                }

                this.population = value;
            }
        }

        public double Area
        {
            get
            {
                return this.area;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Country's area cannot be negative!");
                }

                this.area = value;
            }
        }

        public HashSet<string> Cities
        {
            get
            {
                return this.cities;
            }
            set
            {
                this.cities = value;
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public int CompareTo(Country otherCountry)
        {
            if (this.Area == otherCountry.Area)
            {
                if (this.Population == otherCountry.Population)
                {
                    return this.Name.CompareTo(otherCountry.Name);
                }
                else
                {
                    return otherCountry.Population.CompareTo(this.Population);
                }
            }
            else
            {
               return otherCountry.Area.CompareTo(this.Area);
            }
        }

        public object Clone()
        {
            return new Country()
            {
                Name = this.Name,
                Area = this.Area,
                Population = this.Population,
                Cities = new HashSet<string>(this.Cities)
                //Cities = this.Cities.toList()
            };
        }

        public override bool Equals(object otherCountry)
        {
            return this.Name.Equals((otherCountry as Country).Name);
        }

        public static bool operator ==(Country firstCountry, Country secondCountry)
        {
            return firstCountry.Equals(secondCountry);
        }

        public static bool operator !=(Country firstCountry, Country secondCountry)
        {
            return !firstCountry.Equals(secondCountry);
        }
    }
}
