using ExerciseTwo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTwo.Characters
{
    public class Priest : Character, IHeal
    {
        private const int BASE_HEALTH = 125;
        private const int BASE_MANA = 200;
        private const int BASE_DAMAGE = 100;

        public Priest() 
            : base(BASE_HEALTH, BASE_MANA, BASE_DAMAGE)
        {

        }

        public override void Attack(Character target)
        {
            this.Mana -= 100;
            target.Health -= this.Damage;
            this.Health += (this.Damage * 10 / 100);
        }

        public void Heal(Character target)
        {
            this.Mana -= 100;
            target.Health += 150;
        }
    }
}
