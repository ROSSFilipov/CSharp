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
    public class Cruiser : Starship
    {
        public Cruiser(string name, StarSystem location)
            : base(name, location)
        {
            this.Health = ShipValues.CruiserHealth;
            this.Shields = ShipValues.CruiserShields;
            this.Damage = ShipValues.CruiserDamage;
            this.Fuel = ShipValues.CruiserFuel;
        }

        public override IProjectile ProduceAttack()
        {
            IProjectile currentProjectile = new PenetrationShell();
            currentProjectile.Damage = this.Damage;
            return currentProjectile;
        }

        public override void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }
    }
}
