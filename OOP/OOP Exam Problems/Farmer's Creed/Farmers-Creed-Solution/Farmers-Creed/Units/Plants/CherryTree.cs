using FarmersCreed.Units.ConstantValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersCreed.Units.Plants
{
    public class CherryTree : FoodPlant
    {
        public CherryTree(string id)
            : base(id)
        {

        }

        public override Product GetProduct()
        {
            Product cherryProduct = UnitFactory.ProduceProduct(this.Id, ProductType.Cherry);
            return cherryProduct;
        }

        public override bool CanProduce()
        {
            return this.IsAlive;
        }
    }
}
