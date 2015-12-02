using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Spells
{
    public abstract class Spell : ISpell
    {
        private int damage;
        private int energyCost;

        protected Spell(int damage, int energyCost)
        {
            this.Damage = damage;
            this.EnergyCost = energyCost;
        }

        public int Damage
        {
            get { return this.damage; }
            private set
            {
                this.damage = value;
            }
        }

        public int EnergyCost
        {
            get { return this.energyCost; }
            private set
            {
                this.energyCost = value;
            }
        }
    }
}
