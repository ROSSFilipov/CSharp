using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models.Recipes
{
    public abstract class Meal : Recipe, IMeal
    {
        private bool isVegan;

        protected Meal(string name, decimal price, int calories, int quantityPerServing, MetricUnit unit, int timeToPrepare, bool isVegan)
             : base(name, price, calories, quantityPerServing, unit, timeToPrepare)
        {
            this.IsVegan = isVegan;
        }

        public virtual bool IsVegan
        {
            get { return this.isVegan; }
            protected set
            {
                this.isVegan = value;
            }
        }

        public virtual void ToggleVegan()
        {
            if (this.IsVegan)
            {
                this.IsVegan = false;
            }
            else
            {
                this.IsVegan = true;
            }
        }

        public override MetricUnit Unit
        {
            get
            {
                return base.Unit;
            }
            protected set
            {
                if (value != MetricUnit.Grams)
                {
                    throw new ArgumentException();
                }

                base.Unit = value;
            }
        }
    }
}
