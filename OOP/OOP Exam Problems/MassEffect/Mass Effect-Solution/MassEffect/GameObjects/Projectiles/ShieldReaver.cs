using MassEffect.Exceptions;
using MassEffect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.GameObjects.Projectiles
{
    public class ShieldReaver : Projectile
    {
        public ShieldReaver()
        {

        }

        public override void Hit(IStarship ship)
        {
            if (ship.Health <= 0)
            {
                throw new ShipException("Ship is destroyed");
            }

            ship.Health -= this.Damage;
            ship.Shields -= 2 * this.Damage;
        }
    }
}
