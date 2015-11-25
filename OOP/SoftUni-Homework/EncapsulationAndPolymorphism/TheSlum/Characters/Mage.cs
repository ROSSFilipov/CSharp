using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;
using TheSlum.Items;

namespace TheSlum.Characters
{
    public class Mage : Character, IAttack
    {
        public const int BASE_ATTACK_POINTS = 300;
        private const int BASE_HEALTH = 150;
        private const int BASE_DEFENCE = 50;
        private const int BASE_RANGE = 5;

        private int attackPoints;

        public Mage(string id, int x, int y, Team team)
            : base(id, x, y, BASE_HEALTH, BASE_DEFENCE, team, BASE_RANGE)
        {
            this.AttackPoints = BASE_ATTACK_POINTS;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            private set
            {
                this.attackPoints = value;
            }
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character target = targetsList.Last();
            return target;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.HealthPoints += item.HealthEffect;
            this.DefensePoints += item.DefenseEffect;
            this.AttackPoints += item.AttackEffect;
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.HealthPoints -= item.HealthEffect;
            if (this.HealthPoints < 0)
            {
                this.HealthPoints = 1;
            }
            this.DefensePoints -= item.DefenseEffect;
            this.AttackPoints -= item.AttackEffect;
        }

        public void ExecuteAttack(Character target)
        {
            if (this.AttackPoints > target.DefensePoints)
            {
                target.HealthPoints -= (this.AttackPoints - target.DefensePoints);
                target.DefensePoints = 0;
                if (target.HealthPoints < 0)
                {
                    target.IsAlive = false;
                }
            }
            else if (this.AttackPoints < target.DefensePoints)
            {
                target.DefensePoints -= this.AttackPoints;
            }
            else
            {
                target.DefensePoints = 0;
            }
        }
    }
}
