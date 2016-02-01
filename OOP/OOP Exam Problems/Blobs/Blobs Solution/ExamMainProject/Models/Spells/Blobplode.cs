namespace ExamMainProject.Models.Spells
{
    using System;
    using Interfaces;
    using Attributes;

    [SpellAttribute]
    public class Blobplode : Spell
    {
        public Blobplode()
            : base()
        {
        }

        public override int SpellAttack(IBlob attackingBlob)
        {
            attackingBlob.Health -= attackingBlob.Health / 2;
            if (attackingBlob.Health == 0)
            {
                attackingBlob.Health = 1;
            }

            int attackPower = attackingBlob.Damage * 2;
            return attackPower;
        }
    }
}
