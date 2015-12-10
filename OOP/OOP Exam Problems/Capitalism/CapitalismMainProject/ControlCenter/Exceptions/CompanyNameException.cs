using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.ControlCenter.Exceptions
{
    public class CompanyNameException : Exception
    {
        public CompanyNameException(string message)
            : base(message)
        {
        }
    }
}
