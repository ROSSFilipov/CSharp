using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Characters;
using TheSlum.Items;

namespace TheSlum.Items
{
    public class Shield : Item
    {
        private const int BASE_HEALTH_EFFECT = 0;
        private const int BASE_DEFENCE_EFFECT = 50;
        private const int BASE_ATTACK_EFFECT = 0;

        public Shield(string id, Character itemHolder)
            : base(id, BASE_HEALTH_EFFECT, BASE_DEFENCE_EFFECT, BASE_ATTACK_EFFECT, itemHolder)
        {

        }
    }
}
