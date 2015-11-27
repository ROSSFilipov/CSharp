using FarmersCreed.Interfaces;
using FarmersCreed.Units.ConstantValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersCreed.Units.Animals
{
    public class Cow : Animal
    {

        public Cow(string id)
            : base(id)
        {

        }

        public override Product GetProduct()
        {
            Product cowProduct = UnitFactory.ProduceProduct(this.Id, ProductType.Milk);
            this.Health -= AnimalValues.CowProductionHealthDecreaseIndex;
            return cowProduct;
        }

        public override bool CanProduce()
        {
            return this.IsAlive;
        }

        public override void Eat(IEdible food, int quantity)
        {
            switch (food.FoodType)
            {
                case FoodType.Organic:
                    this.Health += quantity * food.HealthEffect;
                    break;
                case FoodType.Meat:
                    this.Health -= quantity * food.HealthEffect;
                    break;
                default:
                    {
                        throw new NotImplementedException("Unknown food type " + food.FoodType);
                    }
            }
        }
    }
}
