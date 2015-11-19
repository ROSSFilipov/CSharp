using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOne
{
    public class GoldenEditionBook : Book
    {
        private const decimal BASE_ORIGINAL = 1m;

        private const decimal Rate = 1.3m;

        //The class is modified with an option to display the original price
        private decimal originalPrice;

        public GoldenEditionBook(string title, string author, decimal price) 
            : base(title, author, price)
        {
            this.OriginalPrice = price;
        }

        public GoldenEditionBook()
            : base()
        {
            this.originalPrice = BASE_ORIGINAL;
        }

        public override decimal Price
        {
            get
            {
                return base.Price * Rate;
            }
        }

        public decimal OriginalPrice
        {
            get
            {
                return this.originalPrice;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Book's price cannot be negative!");
                }

                this.originalPrice = value;
            }
        }

        public override string ToString()
        {
            return String.Format("-Type: {4}{0}-Title: {1}{0}-Author: {2}{0}-Price: {3}", Environment.NewLine, this.Title, this.Author, this.Price, this.GetType().Name);
        }
    }
}
