namespace WinterIsComing.Models.CombatHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WinterIsComing.Contracts;
    using WinterIsComing.Models.Spells;
    using WinterIsComing.Models.Units;
    using WinterIsComing.Core.Exceptions;

    public class IceGiantCombatHandler : ICombatHandler
    {
        private IUnit unit;

        public IceGiantCombatHandler(IceGiant giantUnit)
        {
            this.Unit = giantUnit;
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
            if (this.Unit.HealthPoints <= UnitValues.IceGiantHealthEnrage)
            {
                var targets = candidateTargets
                .Take(UnitValues.IceGiantDecreasedTargetsNumber);

                return targets;
            }
            else
            {
                return candidateTargets;
            }
        }

        public ISpell GenerateAttack()
        {
            int currentAttackDamage = this.Unit.AttackPoints;

            ISpell currentAttack = new Stomp(currentAttackDamage, SpellValues.StompEnergy);

            if (this.Unit.EnergyPoints < currentAttack.EnergyCost)
            {
                throw new NotEnoughEnergyException(string.Format("{0} does not have enough energy to cast {1}",
                    this.Unit.Name, currentAttack.GetType().Name));
            }

            this.Unit.AttackPoints += UnitValues.IceGiantAttackPointIncreaseRate;
            this.Unit.EnergyPoints -= currentAttack.EnergyCost;
            return currentAttack;
        }
    }
}
