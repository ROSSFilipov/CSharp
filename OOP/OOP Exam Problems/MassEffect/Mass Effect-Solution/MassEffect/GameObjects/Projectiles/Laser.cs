using MassEffect.Exceptions;
using MassEffect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.GameObjects.Projectiles
{
    public class Laser : Projectile
    {
        public Laser()
        {

        }

        public override void Hit(IStarship ship)
        {
            if (ship.Health <= 0)
            {
                throw new ShipException("Ship is destroyed");
            }

            if (this.Damage <= ship.Shields)
            {
                ship.Shields -= this.Damage;
            }
            else
            {
                int difference = this.Damage - ship.Shields;
                ship.Shields = 0;
                ship.Health -= difference;
            }
        }
    }
}
