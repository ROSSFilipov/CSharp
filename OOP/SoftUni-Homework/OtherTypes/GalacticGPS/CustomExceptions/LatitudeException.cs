using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticGPS.CustomExceptions
{
    public class LatitudeException : Exception
    {
        public LatitudeException(string message)
            : base(message)
        {

        }

        public LatitudeException()
            : base()
        {

        }
    }
}
