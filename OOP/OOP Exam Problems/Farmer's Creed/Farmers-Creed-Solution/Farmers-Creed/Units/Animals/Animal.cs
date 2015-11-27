namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;
    using FarmersCreed.Units.ConstantValues;

    public abstract class Animal : FarmUnit, IProductProduceable
    {
        public Animal(string id)
            : base(id)
        {

        }

        public abstract void Eat(IEdible food, int quantity);

        public virtual void Starve()
        {
            this.Health -= AnimalValues.AnimalStarvationIndex;
        }

        public abstract Product GetProduct();

        public abstract bool CanProduce();

        public override string ToString()
        {
            if (this.IsAlive)
            {
                return string.Format("--{0} {1}, Health: {2}",
                    this.GetType().Name, this.Id, this.Health);
            }
            else
            {
                return string.Format("--{0} {1}, DEAD",
                this.GetType().Name, this.Id);
            }
        }
    }
}
