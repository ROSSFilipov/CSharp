using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMainProject.CustomExceptions
{
    public class FriendlyFireException : Exception
    {
        public FriendlyFireException(string message)
            : base(message)
        {
        }
    }
}
