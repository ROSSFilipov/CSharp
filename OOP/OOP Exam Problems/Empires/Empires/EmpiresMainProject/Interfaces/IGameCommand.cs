using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.Interfaces
{
    public interface IGameCommand
    {
        IEmpireEngine EmpireEngine { get; }

        void Execute(string[] commandArguments);
    }
}
