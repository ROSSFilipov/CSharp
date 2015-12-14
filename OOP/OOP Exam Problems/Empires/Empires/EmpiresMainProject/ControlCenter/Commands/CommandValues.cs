using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmpiresMainProject.ControlCenter.Commands
{
    public static class CommandValues
    {
        public const string EndCommandString = "armistice";
        public const string BuildCommandString = "build";
        public const string StatusCommandString = "empire-status";
        public const string SkipCommandString = "skip";
        public static readonly Regex commandMatchPattern = new Regex("(.+)Command");
    }
}
