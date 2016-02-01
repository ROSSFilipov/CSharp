using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMainProject.CustomExceptions
{
    public class BehaviorAlreadyTriggeredException : Exception
    {
        public BehaviorAlreadyTriggeredException(string message)
            : base(message)
        {
        }
    }
}
