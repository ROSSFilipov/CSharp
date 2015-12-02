namespace WinterIsComing.Models.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WinterIsComing.Contracts;

    public abstract class Unit : IUnit
    {
        private int x;
        private int y;
        private string name;
        private int range;
        private int attackPoints;
        private int healthPoints;
        private int defencePoints;
        private int energyPoints;
        private ICombatHandler combatHandler;

        protected Unit(int attackPoints, int healthPoints, int defencePoints, int energyPoints, int range)
        {
            this.AttackPoints = attackPoints;
            this.HealthPoints = healthPoints;
            this.DefensePoints = defencePoints;
            this.EnergyPoints = energyPoints;
            this.Range = range;
        }

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            protected set
            {
                this.name = value;
            }
        }

        public int Range
        {
            get { return this.range; }
            protected set
            {
                this.range = value;
            }
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            set
            {
                this.attackPoints = value;
            }
        }

        public int HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                this.healthPoints = value;
            }
        }

        public int DefensePoints
        {
            get
            {
                return this.defencePoints;
            }
            set
            {
                this.defencePoints = value;
            }
        }

        public int EnergyPoints
        {
            get
            {
                return this.energyPoints;
            }
            set
            {
                this.energyPoints = value;
            }
        }

        public ICombatHandler CombatHandler
        {
            get { return this.combatHandler; }
            protected set
            {
                this.combatHandler = value;
            }
        }

        public override string ToString()
        {
            if (this.HealthPoints == 0)
            {
                return string.Format(">{0} - {1} at ({2},{3})\n(Dead)",
                    this.Name, this.GetType().Name, this.X, this.Y);
            }
            else
            {
                return string.Format(">{0} - {1} at ({2},{3})\n-Health points = {4}\n-Attack points = {5}\n-Defense points = {6}\n-Energy points = {7}\n-Range = {8}",
                    this.Name,
                    this.GetType().Name,
                    this.X,
                    this.Y,
                    this.HealthPoints,
                    this.AttackPoints,
                    this.DefensePoints,
                    this.EnergyPoints,
                    this.Range);
            }
        }
    }
}
