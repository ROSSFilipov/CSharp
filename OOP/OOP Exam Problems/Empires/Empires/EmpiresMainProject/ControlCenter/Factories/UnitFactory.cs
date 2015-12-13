using EmpiresMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.ControlCenter.Factories
{
    public class UnitFactory
    {
        private IEnumerable<Type> currentTypes = Assembly.GetExecutingAssembly().GetTypes();

        public static readonly UnitFactory Instance = new UnitFactory();

        public IUnit ProduceUnit(string unitType)
        {
            Type currentUnit = this.currentTypes.FirstOrDefault(x => x.Name.ToLower() == unitType.ToLower());

            if (currentUnit == null)
            {
                throw new InvalidOperationException();
            }

            return Activator.CreateInstance(currentUnit) as IUnit;
        }
    }
}
