namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;

    public abstract class Plant : FarmUnit, IProductProduceable
    {
        private int growTime;
        private bool hasGrown;

        public Plant(string id)
            : base(id)
        {

        }

        public bool HasGrown
        {
            get 
            {
                return this.hasGrown;
            }
        }

        public int GrowTime
        {
            get 
            {
                return this.growTime;
            }
            set 
            {
                this.growTime = value;
                if (this.growTime <= 0)
                {
                    this.hasGrown = true;
                }
            }
        }

        public virtual void Water()
        {
            this.Health += PlantValues.PlantWaterValue;
        }

        public virtual void Wither()
        {
            this.Health -= PlantValues.PlantWitherSpeed;
        }

        public virtual void Grow()
        {
            this.GrowTime -= PlantValues.PlantGrowSpeed;
        }

        public abstract bool CanProduce();

        public abstract Product GetProduct();

        public override string ToString()
        {
            if (this.IsAlive)
            {
                return string.Format("--{0} {1}, Health: {2}, Grown: {3}",
                this.GetType().Name, this.Id, this.Health, this.HasGrown ? "Yes" : "No");
            }
            else
            {
                return string.Format("--{0} {1}, DEAD",
                    this.GetType().Name, this.Id);
            }
        }
    }
}
