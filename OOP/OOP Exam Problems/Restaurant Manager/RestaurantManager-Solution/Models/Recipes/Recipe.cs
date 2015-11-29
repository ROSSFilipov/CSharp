using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models.Recipes
{
    public abstract class Recipe : IRecipe
    {
        private string name;
        private decimal price;
        private int calories;
        private int quantityPerServing;
        private MetricUnit unit;
        private int timeToPrepare;

        protected Recipe(string name, decimal price, int calories, int quantityPerServing, MetricUnit unit, int timeToPrepare)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantityPerServing;
            this.Unit = unit;
            this.TimeToPrepare = timeToPrepare;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(Message.MissingParameter, "name"));
                }

                this.name = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value < RecipeValues.GeneralRecipePriceMinValue)
                {
                    throw new ArgumentException(string.Format(Message.OutOfRangeInput, "price"));
                }

                this.price = value;
            }
        }

        public virtual int Calories
        {
            get { return this.calories; }
            protected set
            {
                if (value < RecipeValues.GeneralRecipeCaloriesMinValue)
                {
                    throw new ArgumentException(string.Format(Message.OutOfRangeInput, "calories"));
                }

                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get { return this.quantityPerServing; }
            private set
            {
                if (value < RecipeValues.GeneralRecipeQuantityMinValue)
                {
                    throw new ArgumentException(string.Format(Message.OutOfRangeInput, "quantity per serving"));
                }

                this.quantityPerServing = value;
            }
        }

        public virtual MetricUnit Unit
        {
            get { return this.unit; }
            protected set
            {
                this.unit = value;
            }
        }

        public virtual int TimeToPrepare
        {
            get { return this.timeToPrepare; }
            protected set
            {
                if (value < RecipeValues.GeneralRecipePreparationTimeMinValue)
                {
                    throw new ArgumentException(string.Format(Message.OutOfRangeInput, "time to prepare"));
                }

                this.timeToPrepare = value;
            }
        }
    }
}
