using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.ControlCenter.Exceptions
{
    public class EmployeeNameException : Exception
    {
        public EmployeeNameException(string message)
            : base(message)
        {
        }
    }
}
