using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTwo.Characters
{
    public class Mage : Character
    {
        private const int BASE_HEALTH = 100;
        private const int BASE_MANA = 300;
        private const int BASE_DAMAGE = 75;

        public Mage() 
            : base(BASE_HEALTH, BASE_MANA, BASE_DAMAGE)
        {

        }

        public override void Attack(Character target)
        {
            this.Mana -= 100;
            target.Health -= 2 * this.Damage;
        }
    }
}
