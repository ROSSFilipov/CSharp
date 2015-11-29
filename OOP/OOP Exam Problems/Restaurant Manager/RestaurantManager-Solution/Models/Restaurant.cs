using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class Restaurant : IRestaurant
    {
        private string name;
        private string location;
        private List<IRecipe> recipes;

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.recipes = new List<IRecipe>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                this.name = value;
            }
        }

        public string Location
        {
            get { return this.location; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                this.location = value;
            }
        }

        public IList<IRecipe> Recipes
        {
            get { return this.recipes; }
        }

        public void AddRecipe(IRecipe recipe)
        {
            bool isDuplicate = this.Recipes.Any(x => x.Name == recipe.Name);

            if (isDuplicate)
            {
                throw new InvalidOperationException();
            }

            this.Recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            IRecipe recipeToBeRemoved = this.Recipes.FirstOrDefault(x => x.Name == recipe.Name);

            if (recipeToBeRemoved == null)
            {
                throw new InvalidOperationException("Recipe does not exist!");
            }

            this.Recipes.Remove(recipeToBeRemoved);
        }

        public string PrintMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("***** {0} - {1} *****", this.Name, this.Location));
            if (this.Recipes.Count() == 0)
            {
                sb.AppendLine("No recipes... yet");
            }
            else
            {
                var drinkRecipes = this.Recipes.Where(x => x is IDrink).OrderBy(x => x.Name);
                var saladRecipes = this.Recipes.Where(x => x is ISalad).OrderBy(x => x.Name);
                var mainCourses = this.Recipes.Where(x => x is IMainCourse).OrderBy(x => x.Name);
                var dessertRecipes = this.Recipes.Where(x => x is IDessert).OrderBy(x => x.Name);

                if (drinkRecipes.Count() != 0)
                {
                    sb.AppendLine("~~~~~ DRINKS ~~~~~");
                    foreach (IDrink drinkRecipe in drinkRecipes)
                    {
                        sb.AppendLine(drinkRecipe.ToString());
                    } 
                }

                if (saladRecipes.Count() != 0)
                {
                    sb.AppendLine("~~~~~ SALADS ~~~~~");
                    foreach (ISalad saladRecipe in saladRecipes)
                    {
                        sb.AppendLine(saladRecipe.ToString());
                    } 
                }

                if (mainCourses.Count() != 0)
                {
                    sb.AppendLine("~~~~~ MAIN COURSES ~~~~~");
                    foreach (IMainCourse mainCourse in mainCourses)
                    {
                        sb.AppendLine(mainCourse.ToString());
                    }
                }

                if (dessertRecipes.Count() != 0)
                {
                    sb.AppendLine("~~~~~ DESSERTS ~~~~~");
                    foreach (IDessert dessertRecipe in dessertRecipes)
                    {
                        sb.AppendLine(dessertRecipe.ToString());
                    }
                }
            }

            return sb.ToString();
        }
    }
}
