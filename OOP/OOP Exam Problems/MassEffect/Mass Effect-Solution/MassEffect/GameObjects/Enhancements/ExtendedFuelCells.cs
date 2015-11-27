using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.GameObjects.Enhancements
{
    public class ExtendedFuelCells : Enhancement
    {
        private const int BaseShieldBonus = 0;
        private const int BaseDamageBonus = 0;
        private const int BaseFuelBonus = 200;

        public ExtendedFuelCells(string name, int shieldBonus, int damageBonus, int fuelBonus)
            : base(name, shieldBonus, damageBonus, fuelBonus)
        {

        }
    }
}
