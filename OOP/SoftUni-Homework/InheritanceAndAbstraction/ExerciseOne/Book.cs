using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOne
{
    public class Book
    {
        private const string BASE_TITLE = "Unknown title";
        private const string BASE_AUTHOR = "Unknown author";
        private const decimal BASE_PRICE = 0m;

        private string title;

        private string author;

        private decimal price;

        public Book(string title, string author, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public Book()
            : this(BASE_TITLE, BASE_AUTHOR, BASE_PRICE)
        {

        }

        public string Title
        {
            get
            {
                return this.title;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Book title cannot be empty.");
                }

                this.title = value;
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Author's name cannot be empty.");
                }

                this.author = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Book's price cannot be negative!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return String.Format("-Type: {0}:\n-Title: {1}\n-Author: {2}\n-Price: {3:F2}\n",
                this.GetType().Name, this.Title, this.Author, this.Price);
        }
    }
}
