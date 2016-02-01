namespace ExamMainProject.Models.Spells
{
    using System;
    using Interfaces;
    using Attributes;

    [SpellAttribute]
    public class PutridFart : Spell
    {
        public PutridFart()
            : base()
        {
        }

        public override int SpellAttack(IBlob attackingBlob)
        {
            int attackPower = attackingBlob.Damage;
            return attackPower;
        }
    }
}
