using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.GameObjects.Ships
{
    public class Dreadnought : Starship
    {
        public Dreadnought(string name, StarSystem location)
            : base(name, location)
        {
            this.Health = ShipValues.DreadnoughtHealth;
            this.Shields = ShipValues.DreadnoughtShields;
            this.Damage = ShipValues.DreadnoughtDamage;
            this.Fuel = ShipValues.DreadnoughtFuel;
        }

        public override IProjectile ProduceAttack()
        {
            IProjectile currentProjectile = new Laser();
            currentProjectile.Damage = this.Damage + this.Shields / 2;
            return currentProjectile;
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;
            attack.Hit(this);
            this.Shields -= 50;
        }
    }
}
