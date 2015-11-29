using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models.Recipes
{
    public class MainCourse : Meal, IMainCourse
    {
        private MainCourseType type;

        public MainCourse(string name, decimal price, int calories, int quantityPerServing, MetricUnit unit, int timeToPrepare, bool isVegan, MainCourseType type)
            : base(name, price, calories, quantityPerServing, unit, timeToPrepare, isVegan)
        {
            this.Type = type;
        }

        public MainCourseType Type
        {
            get { return this.type; }
            private set
            {
                this.type = value;
            }
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
            sb.Append(string.Format("Type: {0}", this.Type));
            return sb.ToString();
        }
    }
}
