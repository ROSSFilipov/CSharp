using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCatalog
{
    public class Component
    {
        private string name;

        private decimal price;

        private string details;

        private const string BASE_NAME = "missing information";

        private const decimal BASE_PRICE = 0m;

        private const string BASE_DETAILS = "missing details";

        public Component(string name, decimal price, string details)
        {
            this.NameSet = name;
            this.PriceSet = price;
            this.DetailsSet = details;
        }

        public Component(string name, decimal price) : this(name, price, BASE_DETAILS)
        {

        }

        public Component() : this(BASE_NAME, BASE_PRICE, BASE_DETAILS)
        {

        }

        public string NameSet
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid component name information!");
                }
                this.name = value;
            }
        }

        public decimal PriceSet
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid component price information!");
                }
                this.price = value;
            }
        }

        public string DetailsSet
        {
            get
            {
                return this.details;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid details");
                }
                this.details = value;
            }
        }

        public override string ToString()
        {
            return String.Format("\t\tName: {1}\n\t\tPrice: {2} BGN\n\t\tDetails: {3}", 
                this.GetType().Name, this.NameSet, this.PriceSet, this.DetailsSet);
        }
    }
}
