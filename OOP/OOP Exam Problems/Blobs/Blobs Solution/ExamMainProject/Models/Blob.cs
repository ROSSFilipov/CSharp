namespace ExamMainProject.Models
{
    using System;
    using Interfaces;
    using ControlCenter;
    using CustomExceptions;

    public class Blob : IBlob
    {
        private int health;
        private int damage;
        private string name;
        private IBehavior behavior;
        private ISpell blobSpell;
        public readonly int InitialHealth;
        public readonly int InitialDamage;

        public Blob(string name, int health, int damage, IBehavior behavior, ISpell spell)
        {
            this.Behavior = behavior;
            this.BlobSpell = spell;
            this.InitialHealthValidation(health);
            this.InitialDamageValidation(damage);
            this.InitialHealth = health;
            this.InitialDamage = damage;
            this.Name = name;
            this.Health = this.InitialHealth;
            this.Damage = this.InitialDamage;
            this.RoundDelay = ValidationControl.BlobRoundDelay;
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health = value;

                if (this.health < ValidationControl.BlobHealthMinValue)
                {
                    this.health = ValidationControl.BlobHealthMinValue;
                }

                if (this.health <= this.InitialHealth / 2)
                {
                    if (!this.Behavior.IsActive)
                    {
                        //throw new BehaviorAlreadyTriggeredException(CustomMessages.BehaviorAlreadyTriggeredMessage);
                    }
                    else
                    {
                        this.Behavior.Activate(this);
                    }
                }
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }
            set
            {
                this.damage = value;

                if (value < this.InitialDamage)
                {
                    this.damage = InitialDamage;
                }
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new BlobNameException(CustomMessages.BlobNameMessage);
                }

                this.name = value;
            }
        }

        public IBehavior Behavior
        {
            get
            {
                return this.behavior;
            }
            private set
            {
                this.behavior = value;
            }
        }

        public ISpell BlobSpell
        {
            get { return this.blobSpell; }
            private set
            {
                this.blobSpell = value;
            }
        }

        public int RoundDelay { get; set; }

        private void InitialHealthValidation(int health)
        {
            if (ValidationControl.GlobalHealthValidation)
            {
                if (health < ValidationControl.BlobHealthMinValue)
                {
                    throw new BlobHealthException(string.Format(CustomMessages.BlobHealthMessage,
                        ValidationControl.BlobHealthMinValue));
                }
            }
        }

        private void InitialDamageValidation(int damage)
        {
            if (ValidationControl.GlobalDamageValidation)
            {
                if (damage < ValidationControl.BlobDamageMinValue)
                {
                    throw new BlobDamageException(string.Format(CustomMessages.BlobDamageMessage,
                        ValidationControl.BlobDamageMinValue));
                }
            }
        }

        public void Attack(IBlob enemyBlob)
        {
            int attackDamage = this.BlobSpell.SpellAttack(this);
            enemyBlob.Health -= attackDamage;
        }

        public override string ToString()
        {
            if (this.Health > 0)
            {
                return string.Format(ValidationControl.AliveBlobStringFormat,
                    this.GetType().Name, this.Name, this.Health, this.Damage);
            }
            else
            {
                return string.Format(ValidationControl.DeadBlobStringFormat,
                    this.GetType().Name, this.Name);
            }
        }
    }
}
