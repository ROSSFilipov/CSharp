using FarmersCreed.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarmersCreed.Units.ConstantValues;

namespace FarmersCreed.Units
{
    public class TobaccoPlant : Plant
    {
        public TobaccoPlant(string id)
            : base(id)
        {

        }

        public override Product GetProduct()
        {
            Product tobaccoProduct = UnitFactory.ProduceProduct(this.Id, ProductType.Tobacco);
            return tobaccoProduct;
        }

        public override void Grow()
        {
            this.GrowTime -= PlantValues.TobaccoPlantWaterValue;
        }

        public override bool CanProduce()
        {
            return this.IsAlive && this.HasGrown;
        }
    }
}
