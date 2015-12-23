using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.Interfaces
{
    /// <summary>
    /// The interface summarizes all specifications
    /// of a game command.
    /// </summary>
    public interface IGameCommand
    {
        /// <summary>
        /// Indicates which engine the command is 
        /// corresponding with. When a command is
        /// initialized an engine must be specified.
        /// </summary>
        IEmpireEngine EmpireEngine { get; }

        void Execute(string[] commandArguments);
    }
}
