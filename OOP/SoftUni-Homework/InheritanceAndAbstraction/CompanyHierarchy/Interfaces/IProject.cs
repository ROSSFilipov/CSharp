using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy.Interfaces
{
    public interface IProject
    {
        string ProjectName { get; set; }

        DateTime ProjectStartDate { get; set; }

        string Details { get; set; }

        string State { get; set; }

        void CloseProject();
    }
}
