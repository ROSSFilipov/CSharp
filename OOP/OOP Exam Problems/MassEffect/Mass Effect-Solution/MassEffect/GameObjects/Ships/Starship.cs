using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.GameObjects.Ships
{
    public abstract class Starship : IStarship
    {
        private string name;
        private int health;
        private int shields;
        private int damage;
        private double fuel;
        private StarSystem location;
        private List<Enhancement> enhancements;

        public Starship(string name, StarSystem location)
        {
            this.Name = name;
            this.Location = location;
            this.enhancements = new List<Enhancement>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;
                if (this.health < 0)
                {
                    this.health = 0;
                }
            }
        }

        public int Shields
        {
            get
            {
                return this.shields;
            }
            set
            {
                this.shields = value;
                if (this.shields < 0)
                {
                    this.shields = 0;
                }
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }
            set
            {
                this.damage = value;
            }
        }

        public double Fuel
        {
            get
            {
                return this.fuel;
            }
            set
            {
                this.fuel = value;
            }
        }

        public StarSystem Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }

        public abstract IProjectile ProduceAttack();

        public abstract void RespondToAttack(IProjectile attack);

        public IEnumerable<Enhancement> Enhancements
        {
            get { return this.enhancements; }
        }

        public void AddEnhancement(Enhancement enhancement)
        {
            this.enhancements.Add(enhancement);

            this.Shields += enhancement.ShieldBonus;
            this.Damage += enhancement.DamageBonus;
            this.Fuel += enhancement.FuelBonus;
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
                return string.Format("--{0} - {1}\n-Location: {2}\n-Health: {3}\n-Shields: {4}\n-Damage: {5}\n-Fuel: {6:F1}\n-Enhancements: {7}",
                    this.Name,
                    this.GetType().Name,
                    this.Location.Name,
                    this.Health,
                    this.Shields,
                    this.Damage,
                    this.Fuel,
                    this.Enhancements.Count() != 0 ? string.Join(", ", this.Enhancements.Select(x => x.Name)) : "N/A");
            }
        }
    }
}
