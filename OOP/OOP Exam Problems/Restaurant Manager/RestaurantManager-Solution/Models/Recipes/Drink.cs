using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models.Recipes
{
    public class Drink : Recipe, IDrink
    {
        private bool isCarbonated;

        public Drink(string name, decimal price, int calories, int quantityPerServing, MetricUnit unit, int timeToPrepare, bool isCarbonated)
            : base(name, price, calories, quantityPerServing, unit, timeToPrepare)
        {
            this.IsCarbonated = isCarbonated;
            this.Unit = MetricUnit.Milliliters;
        }

        public bool IsCarbonated
        {
            get { return this.isCarbonated; }
            private set
            {
                this.isCarbonated = value;
            }
        }

        public override int Calories
        {
            get
            {
                return base.Calories;
            }
            protected set
            {
                if (value < RecipeValues.DrinkCaloriesMinValue 
                    || value > RecipeValues.DrinkCaloriesMaxValue)
                {
                    throw new ArgumentException();
                }

                base.Calories = value;
            }
        }

        public override int TimeToPrepare
        {
            get
            {
                return base.TimeToPrepare;
            }
            protected set
            {
                if (value < RecipeValues.DrinkPreparationTimeMinValue 
                    || value > RecipeValues.DrinkPreparationTimeMaxValue)
                {
                    throw new ArgumentException();
                }

                base.TimeToPrepare = value;
            }
        }

        //public override MetricUnit Unit
        //{
        //    get
        //    {
        //        return base.Unit;
        //    }
        //    protected set
        //    {
        //        if (value != MetricUnit.Milliliters)
        //        {
        //            throw new ArgumentException();
        //        }

        //        base.Unit = MetricUnit.Milliliters;
        //    }
        //}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("==  {0} == ${1:F2}", this.Name, this.Price));
            sb.AppendLine(string.Format("Per serving: {0} ml, {1} kcal", 
                this.QuantityPerServing, this.Calories));
            sb.AppendLine(string.Format("Ready in {0} minutes", this.TimeToPrepare));
            sb.AppendLine(string.Format("Carbonated: {0}", this.IsCarbonated ? "yes" : "no"));
            return sb.ToString();
        }
    }
}
