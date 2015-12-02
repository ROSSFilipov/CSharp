using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models.Spells
{
    public class FireBreath : Spell
    {
        public FireBreath()
            : base(SpellValues.FireBreathDamage, SpellValues.FireBreathEnergy)
        {
        }

        public FireBreath(int damage, int energyCost)
            : base(damage, energyCost)
        {
        }
    }
}
