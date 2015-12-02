namespace WinterIsComing.Core
{
    using System.Collections.Generic;
    using Contracts;

    public sealed class EmptyUnitEffector : IUnitEffector
    {
        public void ApplyEffect(IEnumerable<IUnit> units)
        {
            foreach (IUnit currentUnit in units)
            {
                currentUnit.HealthPoints += 50;
            }
        }
    }
}
