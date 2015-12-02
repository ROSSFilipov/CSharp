namespace WinterIsComing.Models.CombatHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WinterIsComing.Contracts;
    using WinterIsComing.Core.Exceptions;
    using WinterIsComing.Models.Spells;
    using WinterIsComing.Models.Units;

    public class WarriorCombatHandler : ICombatHandler
    {
        private IUnit unit;

        public WarriorCombatHandler(Warrior warriorUnit)
        {
            this.Unit = warriorUnit;
        }

        public IUnit Unit
        {
            get
            {
                return this.unit;
            }
            set
            {
                this.unit = value;
            }
        }

        public IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var targets = candidateTargets
                .OrderBy(x => x.HealthPoints)
                .ThenBy(x => x.Name)
                .Take(UnitValues.WarriorTargetsNumber);

            return targets;
        }

        public ISpell GenerateAttack()
        {
            int currentAttackDamage = this.Unit.AttackPoints;
            int currentAttackEnergy = SpellValues.CleaveEnergy;

            if (this.Unit.HealthPoints <= UnitValues.WarriorEnergyEnrage)
            {
                currentAttackEnergy = 0;
            }

            if (this.Unit.HealthPoints <= UnitValues.WarriorAttackEnrage)
            {
                currentAttackDamage += this.Unit.HealthPoints * 2;
            }

            if (this.Unit.EnergyPoints < currentAttackEnergy)
            {
                throw new NotEnoughEnergyException(string.Format("{0} does not have enough energy to cast {1}",
                    this.Unit.Name, "Cleave"));
            }

            this.Unit.EnergyPoints -= currentAttackEnergy;
            return new Cleave(currentAttackDamage, currentAttackEnergy);
        }
    }
}
