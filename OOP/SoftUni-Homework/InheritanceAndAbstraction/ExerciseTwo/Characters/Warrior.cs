using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTwo.Characters
{
    public class Warrior : Character
    {
        private const int BASE_HEALTH = 300;
        private const int BASE_MANA = 0;
        private const int BASE_DAMAGE = 120;

        public Warrior() 
            : base(BASE_HEALTH, BASE_MANA, BASE_DAMAGE)
        {

        }

        public override void Attack(Character target)
        {
            target.Health -= this.Damage;
        }
    }
}
