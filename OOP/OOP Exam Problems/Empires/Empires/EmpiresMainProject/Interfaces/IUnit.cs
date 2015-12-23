using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.Interfaces
{
    /// <summary>
    /// An interface which indicates all
    /// major unit specifications.
    /// </summary>
    public interface IUnit
    {
        int Health { get; set; }

        int Damage { get; }
    }
}
