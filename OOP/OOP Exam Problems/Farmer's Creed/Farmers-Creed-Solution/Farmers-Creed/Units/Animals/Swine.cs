using FarmersCreed.Units.ConstantValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersCreed.Units.Animals
{
    public class Swine : Animal
    {
        public Swine(string id)
            : base(id)
        {

        }

        public override void Eat(Interfaces.IEdible food, int quantity)
        {
            this.Health += quantity * (AnimalValues.SwineEatIncreaseIndex * food.HealthEffect);
        }

        public override Product GetProduct()
        {
            Product swineProduct = UnitFactory.ProduceProduct(this.Id, ProductType.PorkMeat);
            this.Health = 0;
            return swineProduct;
        }

        public override bool CanProduce()
        {
            return this.IsAlive;
        }

        public override void Starve()
        {
            this.Health -= AnimalValues.SwineStarvationIndex;
        }
    }
}
