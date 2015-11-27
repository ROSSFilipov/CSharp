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
    public class Frigate : Starship
    {
        private int projectilesFired;

        public Frigate(string name, StarSystem location)
            : base(name, location)
        {
            this.Health = ShipValues.FrigateHealth;
            this.Shields = ShipValues.FrigateShields;
            this.Damage = ShipValues.FrigateDamage;
            this.Fuel = ShipValues.FrigateFuel;
            this.ProjectilesFired = 0;
        }

        public int ProjectilesFired
        {
            get
            {
                return this.projectilesFired;
            }
            set
            {
                this.projectilesFired = value;
            }
        }

        public override IProjectile ProduceAttack()
        {
            this.ProjectilesFired++;
            IProjectile currentProjectile = new ShieldReaver();
            currentProjectile.Damage = this.Damage;
            return currentProjectile;
        }

        public override void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }

        public override string ToString()
        {
            if (this.Health <= 0)
            {
                return string.Format("--{0} - {1}\n(Destroyed)",
                    this.Name, this.GetType().Name);
            }
            else
            {
                return string.Format("--{0} - {1}\n-Location: {2}\n-Health: {3}\n-Shields: {4}\n-Damage: {5}\n-Fuel: {6:F1}\n-Enhancements: {7}\n-Projectiles fired: {8}",
                    this.Name,
                    this.GetType().Name,
                    this.Location.Name,
                    this.Health,
                    this.Shields,
                    this.Damage,
                    this.Fuel,
                    this.Enhancements.Count() != 0 ? string.Join(", ", this.Enhancements.Select(x => x.Name)) : "N/A",
                    this.ProjectilesFired);

            }
        }
    }
}
