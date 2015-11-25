using TheSlum.Characters;
namespace TheSlum.Items
{
    public abstract class Item : GameObject
    {
        public int HealthEffect { get; set; }

        public int DefenseEffect { get; set; }

        public int AttackEffect { get; set; }

        public Character ItemHolder { get; set; }

        protected Item(string id, int healthEffect, int defenseEffect, int attackEffect, Character itemHolder)
            : base(id)
        {
            this.HealthEffect = healthEffect;
            this.DefenseEffect = defenseEffect;
            this.AttackEffect = attackEffect;
            this.ItemHolder = itemHolder;
            this.ItemHolder.AddToInventory(this);
        }
    }
}
