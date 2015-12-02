using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models.Spells
{
    public class Stomp : Spell
    {
        public Stomp()
            : base(SpellValues.StompDamage, SpellValues.StompEnergy)
        {
        }

        public Stomp(int damage, int energyCost)
            : base(damage, energyCost)
        {
        }
    }
}
