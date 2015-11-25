using TheSlum.Items;
namespace TheSlum
{
    using Interfaces;
    using TheSlum.Characters;

    public abstract class Bonus : Item, ITimeoutable
    {
        public int Timeout { get; set; }

        public int Countdown { get; set; }

        public bool HasTimedOut { get; set; }

        protected Bonus(string id, int healthEffect, int defenseEffect, int attackEffect, Character itemHolder)
            : base(id, healthEffect, defenseEffect, attackEffect, itemHolder)
        {

        }
    }
}
