namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;

    public class Product : GameObject, IProduct
    {
        private int quantity;
        private ProductType productType;

        public Product(string id)
            : base(id)
        {
        }

        public int Quantity
        {
            get 
            { 
                return this.quantity; 
            }
            set
            {
                this.quantity = value;
            }
        }

        public ProductType ProductType
        {
            get 
            { 
                return this.productType; 
            }
            set 
            { 
                this.productType = value; 
            }
        }
    }
}
