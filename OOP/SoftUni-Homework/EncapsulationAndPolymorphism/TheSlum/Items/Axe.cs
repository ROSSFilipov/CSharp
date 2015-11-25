using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Characters;
using TheSlum.Items;

namespace TheSlum.Items
{
    public class Axe : Item
    {
        private const int BASE_HEALTH_EFFECT = 0;
        private const int BASE_DEFENCE_EFFECT = 0;
        private const int BASE_ATTACK_EFFECT = 75;

        public Axe(string id, Character itemHolder)
            : base(id, BASE_HEALTH_EFFECT, BASE_DEFENCE_EFFECT, BASE_ATTACK_EFFECT, itemHolder)
        {

        }
    }
}
