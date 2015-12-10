using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.ControlCenter.Exceptions
{
    public class EmployeeAgeException : Exception
    {
        public EmployeeAgeException(string message)
            : base(message)
        {
        }
    }
}
