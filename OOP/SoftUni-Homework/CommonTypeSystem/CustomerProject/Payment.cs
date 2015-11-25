using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProject
{
    public class Payment : ICloneable, IComparable<Payment>
    {
        private string productName;
        private decimal price;

        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid product name!");
                }

                this.productName = value;
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
                    throw new ArgumentOutOfRangeException("Product price cannot be negative!");
                }

                this.price = value;
            }
        }

        public override bool Equals(object obj)
        {
            return this.ProductName.Equals((obj as Payment).ProductName);
        }

        public override int GetHashCode()
        {
            return this.ProductName.GetHashCode() ^ this.Price.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Payment: {0}, {1}",
                this.ProductName, this.Price);
        }

        public static bool operator ==(Payment firstPayment, Payment secondPayment)
        {
            return firstPayment.Equals(secondPayment);
        }

        public static bool operator !=(Payment firstPayment, Payment secondPayment)
        {
            return !firstPayment.Equals(secondPayment);
        }

        public object Clone()
        {
            return new Payment(this.ProductName, this.Price);
        }

        public int CompareTo(Payment other)
        {
            return this.ProductName.CompareTo(other.ProductName);
        }
    }
}
