using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;

namespace WinterIsComing.Models.Units
{
    public static class UnitValues
    {
        public const int WarriorAttackPoints = 120;
        public const int WarriorHealthPoints = 180;
        public const int WarriorDefencePoints = 70;
        public const int WarriorEnergyPoints = 60;
        public const int WarriorRange = 1;
        public const int WarriorAttackEnrage = 80;
        public const int WarriorEnergyEnrage = 50;
        public const int WarriorTargetsNumber = 1;

        public const int MageAttackPoints = 80;
        public const int MageHealthPoints = 80;
        public const int MageDefencePoints = 40;
        public const int MageEnergyPoints = 120;
        public const int MageRange = 2;
        public const int MageTargetsNumber = 3;

        public const int IceGiantAttackPoints = 150;
        public const int IceGiantHealthPoints = 300;
        public const int IceGiantDefencePoints = 60;
        public const int IceGiantEnergyPoints = 50;
        public const int IceGiantRange = 1;
        public const int IceGiantDecreasedTargetsNumber = 1;
        public const int IceGiantAttackPointIncreaseRate = 5;
        public const int IceGiantHealthEnrage = 150;

        public static bool isInRange(IUnit caster, IUnit target)
        {
            bool inRange = caster.Range * caster.Range >= target.X * target.X + target.Y * target.Y;
            return inRange;
        }
    }
}
