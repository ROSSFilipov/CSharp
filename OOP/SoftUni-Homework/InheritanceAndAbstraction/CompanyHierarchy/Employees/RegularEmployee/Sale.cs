using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyHierarchy.Interfaces;

namespace CompanyHierarchy.Employees.RegularEmployee
{
    public class Sale : ISale
    {
        private const string BASE_PRODUCT_NAME = "Unspecified product";
        private const decimal BASE_PRICE = 100m;

        private string productName;

        private DateTime date;

        private decimal price;

        public Sale(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }

        public Sale()
            : this(BASE_PRODUCT_NAME, DateTime.Now, BASE_PRICE)
        {

        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.productName = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                if (value < new DateTime(1990, 1, 1))
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.date = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Sale - Project name: [{0}], Date: [{1}], Price: [{2:F4}].", 
                this.ProductName, this.Date, this.Price);
        }
    }
}
