using MassEffect.GameObjects.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.GameObjects.Projectiles
{
    public static class ProjectileValues
    {
        public const int PenetrationShellDamage = ShipValues.CruiserDamage;
        public const int ShieldReaverDamage = ShipValues.FrigateDamage;
        public const int LaserDamage = ShipValues.DreadnoughtDamage + ShipValues.DreadnoughtShields / 2;
    }
}
