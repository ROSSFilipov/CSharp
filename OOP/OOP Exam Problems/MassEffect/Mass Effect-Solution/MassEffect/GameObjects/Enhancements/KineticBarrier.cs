using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.GameObjects.Enhancements
{
    public class KineticBarrier : Enhancement
    {
        private const int BaseShieldBonus = 100;
        private const int BaseDamageBonus = 0;
        private const int BaseFuelBonus = 0;

        public KineticBarrier(string name, int shieldBonus, int damageBonus, int fuelBonus)
            : base(name, shieldBonus, damageBonus, fuelBonus)
        {

        }
    }
}
