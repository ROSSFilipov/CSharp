using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject.Interfaces
{
    public interface IEmployeeFactory
    {
        ICEO CreateCeo(string firstName, string lastName);

        IEmployee CreateEmployee(string employeeType, string firstName, string lastName);
    }
}
