using CapitalismMainProject.ControlCenter;
using CapitalismMainProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalismMainProject
{
    class CapitalismMainProject
    {
        public static void Main(string[] args)
        {
            ICompanyManager manager = new CompanyManager();
            manager.Run();
        }
    }
}
