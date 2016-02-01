namespace ExamMainProject.ControlCenter.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using System.Reflection;
    using Attributes;

    public class SpellFactory : ISpellFactory
    {
        private static ISpellFactory factory;
        private static readonly List<Type> spellTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(type => type.CustomAttributes.Any(a => a.AttributeType == typeof(SpellAttribute)))
            .ToList();

        private SpellFactory()
        {
        }

        public static ISpellFactory Factory
        {
            get
            {
                if (factory == null)
                {
                    factory = new SpellFactory();
                }

                return factory;
            }
        }

        public ISpell CreateSpell(string spellName)
        {
            Type currentType = spellTypes.FirstOrDefault(spell => spell.Name == spellName);

            ISpell currentSpell = Activator.CreateInstance(currentType) as ISpell;

            return currentSpell;
        }
    }
}
