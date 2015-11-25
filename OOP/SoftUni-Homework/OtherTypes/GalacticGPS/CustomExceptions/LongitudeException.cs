using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticGPS.CustomExceptions
{
    public class LongitudeException : Exception
    {
        public LongitudeException(string message)
            : base(message)
        {

        }

        public LongitudeException()
            : base()
        {

        }
    }
}
