namespace RestaurantManager.Engine.Factories
{
    using System;
    using RestaurantManager.Interfaces;
    using RestaurantManager.Interfaces.Engine;
    using RestaurantManager.Models.Recipes;
    using RestaurantManager.Models;

    public class RecipeFactory : IRecipeFactory
    {
        public IDrink CreateDrink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
        {
            return new Drink(name, price, calories, quantityPerServing, MetricUnit.Milliliters, timeToPrepare, isCarbonated);
        }

        public ISalad CreateSalad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
        {
            return new Salad(name, price, calories, quantityPerServing, MetricUnit.Grams, timeToPrepare, true, containsPasta);
        }
        
        public IMainCourse CreateMainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, string type)
        {
            MainCourseType currentType = this.GetUnitType(type.ToLower());
            return new MainCourse(name, price, calories, quantityPerServing, MetricUnit.Grams, timeToPrepare, isVegan, currentType);
        }

        public IDessert CreateDessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
        {
            return new Dessert(name, price, calories, quantityPerServing, MetricUnit.Grams, timeToPrepare, isVegan, true);
        }

        private MainCourseType GetUnitType(string type)
        {
            switch (type)
            {
                case "entree":
                    return MainCourseType.Entree;
                case "meat":
                    return MainCourseType.Meat;
                case "other":
                    return MainCourseType.Other;
                case "pasta":
                    return MainCourseType.Pasta;
                case "side":
                    return MainCourseType.Side;
                case "soup":
                    return MainCourseType.Soup;
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }
    }
}
