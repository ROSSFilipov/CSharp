using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Models
{
    public class RentOffer : Offer, IRentOffer
    {
        private decimal pricePerMonth;

        public RentOffer(OfferType type)
            : base(OfferType.Rent)
        {

        }

        public decimal PricePerMonth
        {
            get
            {
                return this.pricePerMonth;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative!");
                }

                this.pricePerMonth = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: Estate = {1}, Location = {2}, Price = {3}",
                this.Type, this.Estate.Name, this.Estate.Location, this.PricePerMonth);
        }
    }
}
