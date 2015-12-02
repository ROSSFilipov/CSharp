using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Models.Units;

namespace WinterIsComing.Models.Spells
{
    public static class SpellValues
    {
        public const int CleaveDamage = UnitValues.WarriorAttackPoints;
        public const int CleaveEnergy = 15;

        public const int FireBreathDamage = UnitValues.MageAttackPoints;
        public const int FireBreathEnergy = 30;

        public const int BlizzardDamage = UnitValues.MageAttackPoints * 2;
        public const int BlizzardEnergy = 40;

        public const int StompDamage = UnitValues.IceGiantAttackPoints;
        public const int StompEnergy = 10;
    }
}
