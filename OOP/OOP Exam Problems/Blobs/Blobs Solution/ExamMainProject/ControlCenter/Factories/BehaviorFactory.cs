namespace ExamMainProject.ControlCenter.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using System.Reflection;
    using Attributes;

    public class BehaviorFactory : IBehaviorFactory
    {
        private static IBehaviorFactory factory;
        private static readonly List<Type> behaviorTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(type => type.CustomAttributes.Any(a => a.AttributeType == typeof(BehaviorAttribute)))
            .ToList();

        private BehaviorFactory()
        {
        }

        public static IBehaviorFactory Factory
        {
            get
            {
                if (factory == null)
                {
                    factory = new BehaviorFactory();
                }

                return factory;
            }
        }

        public IBehavior CreateBehavior(string behaviorName)
        {
            string fixedName = behaviorName + ValidationControl.BehaviorStringPostFix;

            Type currentType = behaviorTypes.FirstOrDefault(b => b.Name == fixedName);

            IBehavior currentBehavior = Activator.CreateInstance(currentType) as IBehavior;

            return currentBehavior;
        }
    }
}
