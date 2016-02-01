namespace ExamMainProject.Interfaces
{
    using System;

    public interface ISpellFactory
    {
        ISpell CreateSpell(string spellName);
    }
}
