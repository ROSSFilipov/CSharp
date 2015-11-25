using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Characters;

namespace TheSlum.Items
{
    public class Injection : Bonus
    {
        private const int BASE_HEALTH_EFFECT = 200;
        private const int BASE_DEFENCE_EFFECT = 0;
        private const int BASE_ATTACK_EFFECT = 0;
        private const int BASE_COUNTDOWN = 3;

        public Injection(string id, Character itemHolder)
            : base(id, BASE_HEALTH_EFFECT, BASE_DEFENCE_EFFECT, BASE_ATTACK_EFFECT, itemHolder)
        {
            this.HasTimedOut = false;
            this.Countdown = BASE_COUNTDOWN;
        }
    }
}
