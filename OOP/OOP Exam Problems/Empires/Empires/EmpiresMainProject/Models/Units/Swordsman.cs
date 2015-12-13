using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.Models.Units
{
    public class Swordsman : Unit
    {
        public Swordsman()
            : base(UnitValues.SwordsmanDefaultHealth, UnitValues.SwordsmanDefaultDamage)
        { 
        }
    }
}
