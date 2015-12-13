using EmpiresMainProject.ControlCenter.CustomExceptions;
using EmpiresMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.Models.Units
{
    public abstract class Unit : IUnit
    {
        private int health;
        private int damage;

        protected Unit(int health, int damage)
        {
            this.Health = health;
            this.Damage = damage;
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

        public int Damage
        {
            get { return this.damage; }
            private set
            {
                if (value < UnitValues.UnitDamageMinValue)
                {
                    throw new InvalidDamageException(CustomMessages.InvalidDamageMessage);
                }

                this.damage = value;
            }
        }
    }
}
