namespace Estates.Models
{
    using Estates.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SaleOffer : Offer, ISaleOffer
    {
        private decimal price;

        public SaleOffer(OfferType type)
            : base(OfferType.Sale)
        {

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
                    throw new ArgumentOutOfRangeException("Price cannot be negative!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: Estate = {1}, Location = {2}, Price = {3}",
                this.Type, this.Estate.Name, this.Estate.Location, this.Price);
        }
    }
}
