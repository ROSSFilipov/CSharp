using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiresMainProject.Interfaces;
using EmpiresMainProject.ControlCenter;

namespace EmpiresMainProject
{
    class EmpireMain
    {
        static void Main(string[] args)
        {
            IEmpireEngine engine = new EmpireEngine();
            engine.Run();
        }
    }
}
