using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListProject
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Enum)]
    public class VersionAttribute : System.Attribute
    {
        public Version Version { get; private set; }

        public VersionAttribute(int major, int minor)
        {
            this.Version = new Version(major, minor);
        }

        public override string ToString()
        {
            return String.Format("{0}.{1}", this.Version.Major, this.Version.Minor);
        }
    }
}
