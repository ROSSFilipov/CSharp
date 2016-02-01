namespace ExamMainProject.Models.Spells
{
    using System;
    using Interfaces;
    using Attributes;

    [SpellAttribute]
    public abstract class Spell : ISpell
    {
        protected Spell()
        {
        }

        public abstract int SpellAttack(IBlob attackingBlob);
    }
}
