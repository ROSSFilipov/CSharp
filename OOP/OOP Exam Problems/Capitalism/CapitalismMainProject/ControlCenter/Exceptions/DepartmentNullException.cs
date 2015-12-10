using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.ControlCenter.Exceptions
{
    public class DepartmentNullException : Exception
    {
        public DepartmentNullException(string message)
            : base(message)
        {

        }
    }
}
