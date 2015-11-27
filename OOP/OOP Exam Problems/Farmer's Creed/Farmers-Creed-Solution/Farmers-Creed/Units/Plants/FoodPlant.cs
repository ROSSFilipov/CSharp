using FarmersCreed.Units.ConstantValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersCreed.Units.Plants
{
    public abstract class FoodPlant : Plant
    {
        public FoodPlant(string id)
            : base(id)
        {
        }

        public override void Water()
        {
            this.Health += FoodPlantValues.FoodPlantWaterValue;
        }

        public override void Wither()
        {
            this.Health -= FoodPlantValues.FoodPlantWitherSpeed;
        }

        public override bool CanProduce()
        {
            throw new NotImplementedException();
        }

        public override Product GetProduct()
        {
            throw new NotImplementedException();
        }
    }
}
