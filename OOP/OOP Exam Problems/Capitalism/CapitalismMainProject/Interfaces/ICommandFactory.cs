using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.Interfaces
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}
