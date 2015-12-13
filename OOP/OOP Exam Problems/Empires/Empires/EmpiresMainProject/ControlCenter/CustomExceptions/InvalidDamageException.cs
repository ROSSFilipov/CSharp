using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiresMainProject.ControlCenter.CustomExceptions
{
    public class InvalidDamageException : Exception
    {
        public InvalidDamageException(string message)
            : base(message)
        {

        }
    }
}
