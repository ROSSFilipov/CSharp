using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models.Recipes
{
    public class Salad : Meal, ISalad
    {
        private bool containsPasta;

        public Salad(string name, decimal price, int calories, int quantityPerServing, MetricUnit unit, int timeToPrepare, bool isVegan, bool containsPasta)
            : base(name, price, calories, quantityPerServing, unit, timeToPrepare, isVegan)
        {
            this.ContainsPasta = containsPasta;
        }

        public bool ContainsPasta
        {
            get { return this.containsPasta; }
            private set
            {
                this.containsPasta = value;
            }
        }

        public override bool IsVegan
        {
            get
            {
                return base.IsVegan;
            }
            protected set
            {
                if (!value)
                {
                    throw new ArgumentException();
                }

                base.IsVegan = value;
            }
        }

        public override void ToggleVegan()
        {
            throw new InvalidOperationException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.IsVegan)
            {
                sb.Append("[VEGAN] ");
            }
            sb.AppendLine(string.Format("==  {0} == ${1:F2}", this.Name, this.Price));
            sb.AppendLine(string.Format("Per serving: {0} g, {1} kcal",
                this.QuantityPerServing, this.Calories));
            sb.AppendLine(string.Format("Ready in {0} minutes", this.TimeToPrepare));
            sb.Append(string.Format("Contains pasta: {0}", this.ContainsPasta ? "yes" : "no"));
            return sb.ToString();
        }
    }
}
