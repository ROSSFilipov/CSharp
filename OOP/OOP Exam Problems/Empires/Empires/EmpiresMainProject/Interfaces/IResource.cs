using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiresMainProject.Models.Resources;

namespace EmpiresMainProject.Interfaces
{
    public interface IResource
    {
        ResourceType Type { get; }

        int Quantity { get; set; }
    }
}
