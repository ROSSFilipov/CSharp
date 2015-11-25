using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSlum.Interfaces;
using TheSlum.Items;

namespace TheSlum.Characters
{
    public class Healer : Character, IHeal
    {
        public const int BASE_HEALING_POINTS = 60;
        private const int BASE_HEALTH = 75;
        private const int BASE_DEFENCE = 50;
        private const int BASE_RANGE = 6;

        private int healingPoints;

        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, BASE_HEALTH, BASE_DEFENCE, team, BASE_RANGE)
        {
            this.HealingPoints = BASE_HEALING_POINTS;
        }

        public int HealingPoints
        {
            get
            {
                return this.healingPoints;
            }
            private set
            {
                this.healingPoints = value;
            }
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            Character target = targetsList.OrderBy(x => x.HealthPoints).First();
            return target;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.HealthPoints += item.HealthEffect;
            this.DefensePoints += item.DefenseEffect;
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.HealthPoints -= item.HealthEffect;
            if (this.HealthPoints < 0)
            {
                this.healingPoints = 1;
            }

            this.DefensePoints -= item.DefenseEffect;
        }

        public void ExecuteHeal(Character target)
        {
            if (this.Team != target.Team)
            {
                return;
            }
            else
            {
                if (target.IsAlive == false)
                {
                    return;
                }

                target.HealthPoints += this.HealingPoints;
            }
        }
    }
}
