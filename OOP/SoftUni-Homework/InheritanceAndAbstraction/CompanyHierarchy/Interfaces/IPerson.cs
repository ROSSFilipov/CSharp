using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy.Interfaces
{
    public interface IPerson
    {
        long ID { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }
    }
}
