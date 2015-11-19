using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciseTwo.Interfaces;

namespace ExerciseTwo.Characters
{
    public abstract class Character : IAttack
    {
        private int health;

        private int mana;

        private int damage;

        protected Character(int health, int mana, int damage)
        {
            this.Health = health;
            this.Mana = mana;
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
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Health value cannot be negative!");
                }

                this.health = value;
            }
        }

        public int Mana
        {
            get
            {
                return this.mana;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Mana value cannot be negative!");
                }

                this.mana = value;
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
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Damage value cannot be negative!");
                }

                this.damage = value;
            }
        }

        public abstract void Attack(Character target);
    }
}
