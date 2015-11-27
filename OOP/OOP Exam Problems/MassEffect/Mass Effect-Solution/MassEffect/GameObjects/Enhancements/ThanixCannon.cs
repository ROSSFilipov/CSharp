using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.GameObjects.Enhancements
{
    public class ThanixCannon : Enhancement
    {
        private const int BaseShieldBonus = 0;
        private const int BaseDamageBonus = 50;
        private const int BaseFuelBonus = 0;

        public ThanixCannon(string name, int shieldBonus, int damageBonus, int fuelBonus)
            : base(name, shieldBonus, damageBonus, fuelBonus)
        {

        }
    }
}
