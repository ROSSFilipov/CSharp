using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    using System;

    public abstract class FarmUnit : GameObject 
    {
        private int health;
        private bool isAlive;
        private int productionQuantity;

        public FarmUnit(string id)
            : base(id)
        {
            this.isAlive = true;
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
                if (this.health <= 0)
                {
                    this.health = 0;
                    this.isAlive = false;
                }
            }
        }

        public bool IsAlive
        {
            get
            {
                return this.isAlive;
            }
        }

        public int ProductionQuantity
        {
            get
            {
                return this.productionQuantity;
            }
            set
            {
                this.productionQuantity = value;
            }
        }
    }
}
