using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Models
{
    public abstract class Offer : IOffer
    {
        private OfferType type;
        private IEstate estate;

        protected Offer(OfferType type)
        {
            this.Type = type;
        }

        public OfferType Type
        {
            get
            {
                return this.type; ;
            }
            set
            {
                this.type = value;
            }
        }

        public IEstate Estate
        {
            get
            {
                return this.estate;
            }
            set
            {
                this.estate = value;
            }
        }
    }
}
