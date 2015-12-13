using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.ControlCenter.CustomExceptions
{
    public class BuildingProductionException : Exception
    {
        public BuildingProductionException(string message)
            : base(CustomMessages.BuildingProductionException)
        {
        }
    }
}
