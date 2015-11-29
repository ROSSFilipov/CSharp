using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models.Recipes
{
    public class Dessert : Meal, IDessert
    {
        private bool withSugar;

        public Dessert(string name, decimal price, int calories, int quantityPerServing, MetricUnit unit, int timeToPrepare, bool isVegan, bool withSugar)
            : base(name, price, calories, quantityPerServing, unit, timeToPrepare, isVegan)
        {
            this.WithSugar = withSugar;
        }

        public bool WithSugar
        {
            get { return this.withSugar; }
            private set
            {
                this.withSugar = value;
            }
        }

        public void ToggleSugar()
        {
            if (this.WithSugar)
            {
                this.WithSugar = false;
            }
            else
            {
                this.WithSugar = true;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (!this.WithSugar)
            {
                sb.Append("[NO SUGAR] ");
            }

            if (this.IsVegan)
            {
                sb.Append("[VEGAN] ");
            }
            sb.AppendLine(string.Format("==  {0} == ${1:F2}", this.Name, this.Price));
            sb.AppendLine(string.Format("Per serving: {0} g, {1} kcal",
                this.QuantityPerServing, this.Calories));
            sb.AppendLine(string.Format("Ready in {0} minutes", this.TimeToPrepare));
            return sb.ToString();
        }
    }
}
