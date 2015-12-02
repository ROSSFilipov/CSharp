namespace WinterIsComing.Models.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WinterIsComing.Models.CombatHandlers;

    public class Mage : Unit
    {
        public Mage(string name, int x, int y)
            : base(
            UnitValues.MageAttackPoints, 
            UnitValues.MageHealthPoints, 
            UnitValues.MageDefencePoints,
            UnitValues.MageEnergyPoints,
            UnitValues.MageRange)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.CombatHandler = new MageCombatHandler(this);
        }
    }
}
