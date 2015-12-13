using EmpiresMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using EmpiresMainProject.Models.Buildings;

namespace EmpiresMainProject.ControlCenter.Factories
{
    public class BuildingFactory
    {
        private IEnumerable<Type> currentTypes = Assembly.GetExecutingAssembly().GetTypes();

        public static readonly BuildingFactory Instance = new BuildingFactory();

        public IBuilding ProduceBuilding(string buildingType)
        {
            Type currentBuilding = this.currentTypes.FirstOrDefault(x => x.Name.ToLower() == buildingType);

            if (currentBuilding == null)
            {
                throw new InvalidOperationException();
            }

            return Activator.CreateInstance(currentBuilding) as IBuilding;
        }
    }
}
