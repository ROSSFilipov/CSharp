namespace WinterIsComing.Models.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WinterIsComing.Models.CombatHandlers;

    public class Warrior : Unit
    {
        public Warrior(string name, int x, int y)
            : base(
            UnitValues.WarriorAttackPoints, 
            UnitValues.WarriorHealthPoints, 
            UnitValues.WarriorDefencePoints,
            UnitValues.WarriorEnergyPoints,
            UnitValues.WarriorRange)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.CombatHandler = new WarriorCombatHandler(this);
        }
    }
}
