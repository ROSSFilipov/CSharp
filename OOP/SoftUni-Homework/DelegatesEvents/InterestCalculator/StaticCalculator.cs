using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalculator
{
    public static class StaticCalculator
    {
        public static double Calculate(long sum, double interest, int years, InterestDelegate customDelegate)
        {
            return customDelegate(sum, interest, years);
        }
    }
}
