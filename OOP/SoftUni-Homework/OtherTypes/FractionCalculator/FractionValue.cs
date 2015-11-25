using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculator
{
    public static class FractionValue
    {
        private static BigInteger minValue = -9223372036854775807;
        private static BigInteger maxValue = 9223372036854775807;

        public static BigInteger MinValue
        {
            get
            {
                return minValue;
            }
        }

        public static BigInteger MaxValue
        {
            get
            {
                return maxValue;
            }
        }
    }
}
