using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Contracts;
using WinterIsComing.Core.Exceptions;
using WinterIsComing.Models.Spells;
using WinterIsComing.Models.Units;

namespace WinterIsComing.Models.CombatHandlers
{
    public class MageCombatHandler : ICombatHandler
    {
        private IUnit unit;
        private int spellIndex = 0;

        public MageCombatHandler(Mage mageUnit)
        {
            this.Unit = mageUnit;
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
                .OrderByDescending(x => x.HealthPoints)
                .ThenBy(x => x.Name)
                .Take(UnitValues.MageTargetsNumber);

            return targets;
        }

        public ISpell GenerateAttack()
        {
            if (this.spellIndex == 0)
            {
                ISpell currentAttack = new FireBreath();

                if (this.Unit.EnergyPoints < currentAttack.EnergyCost)
                {
                    throw new NotEnoughEnergyException(string.Format("{0} does not have enough energy to cast {1}",
                        this.Unit.Name, currentAttack.GetType().Name));
                }

                this.spellIndex = 1;
                this.Unit.EnergyPoints -= currentAttack.EnergyCost;
                return currentAttack;
            }
            else
            {
                ISpell currentAttack = new Blizzard();

                if (this.Unit.EnergyPoints < currentAttack.EnergyCost)
                {
                    throw new NotEnoughEnergyException(string.Format("{0} does not have enough energy to cast {1}",
                        this.Unit.Name, currentAttack.GetType().Name));
                }

                this.spellIndex = 0;
                this.Unit.EnergyPoints -= currentAttack.EnergyCost;
                return currentAttack;
            }
        }
    }
}
