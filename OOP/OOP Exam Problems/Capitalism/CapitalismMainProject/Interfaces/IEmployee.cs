using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.Interfaces
{
    public interface IEmployee : IPerson
    {
        IDepartment Department { get; set; }

        decimal Salary { get; set; }
    }
}
