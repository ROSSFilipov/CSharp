using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousTimer
{
    public static class AsyncTimer
    {
        public static void AsyncStart(Action<int> action, int ticks, int millisec)
        {
            int passed = 0;
            while (ticks > 0)
            {
                if (passed % millisec == 0 && passed != 0)
                {
                    action(passed);
                    ticks--;
                }

                passed++;
            }
        }
    }
}
