namespace WinterIsComing.Models.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WinterIsComing.Models.CombatHandlers;

    public class IceGiant : Unit
    {
        public IceGiant(string name, int x, int y)
            : base(
            UnitValues.IceGiantAttackPoints, 
            UnitValues.IceGiantHealthPoints, 
            UnitValues.IceGiantDefencePoints,
            UnitValues.IceGiantEnergyPoints,
            UnitValues.IceGiantRange)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.CombatHandler = new IceGiantCombatHandler(this);
        }
    }
}
