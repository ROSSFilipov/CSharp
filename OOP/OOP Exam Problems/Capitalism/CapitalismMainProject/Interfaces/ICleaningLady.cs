using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.Interfaces
{
    public interface ICleaningLady : IEmployee
    {
        void Clean(IDepartment departmentToBeCleaned);
    }
}
