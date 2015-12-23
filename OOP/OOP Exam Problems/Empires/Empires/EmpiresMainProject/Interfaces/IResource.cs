using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiresMainProject.Models.Resources;

namespace EmpiresMainProject.Interfaces
{
    /// <summary>
    /// An interface holding all major properties
    /// of a game resource.
    /// </summary>
    public interface IResource
    {
        ResourceType Type { get; }

        int Quantity { get; set; }
    }
}
