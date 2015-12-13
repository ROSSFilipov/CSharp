using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.ControlCenter.CustomExceptions
{
    public class CustomMessages
    {
        public const string BuildingProductionException = 
            "{0} turns have passes. {1} cannot produce {2} yet. {3} turns must pass";

        public const string InvalidDamageMessage = "Unit's damage cannot be negative.";
    }
}
