using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.Models.Resources
{
    public class Steel : Resource
    {
        public Steel(int quantity)
            : base(ResourceType.Steel, quantity)
        {
        }
    }
}
