using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models.Spells
{
    public class Blizzard : Spell
    {
        public Blizzard()
            : base(SpellValues.BlizzardDamage, SpellValues.BlizzardEnergy)
        {
        }

        public Blizzard(int damage, int energyCost)
            : base(damage, energyCost)
        {
        }
    }
}
