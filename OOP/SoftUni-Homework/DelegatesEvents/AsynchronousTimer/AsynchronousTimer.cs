using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousTimer
{
    class AsynchronousTimer
    {
        static void Main(string[] args)
        {
            int ticks = 10;
            int milliseconds = 12;

            Action<int> action = x => 
                {
                    Console.WriteLine("Milliseconds passed: {0}", x);
                };

            AsyncTimer.AsyncStart(action, ticks, milliseconds);
        }
    }
}
