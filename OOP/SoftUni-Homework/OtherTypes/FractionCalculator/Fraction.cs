using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FractionCalculator
{
    public struct Fraction
    {
        private BigInteger numerator;

        private BigInteger denominator;

        public Fraction(BigInteger numerator, BigInteger denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public BigInteger Numerator
        {
            get
            {
                return this.numerator;
            }
            set
            {
                if (value < FractionValue.MinValue || value > FractionValue.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("Numerator should be in the range: [-9223372036854775808...9223372036854775808]");
                }

                this.numerator = value;
            }
        }

        public BigInteger Denominator
        {
            get
            {
                return this.denominator;
            }
            set
            {
                if (value < FractionValue.MinValue || value > FractionValue.MaxValue || value == 0)
                {
                    throw new ArgumentOutOfRangeException("Denominator should be in the range: [-9223372036854775808...9223372036854775808]");
                }

                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            BigInteger num = fraction1.Numerator * fraction2.Denominator + fraction1.Denominator * fraction2.Numerator;
            BigInteger denom = fraction1.Denominator * fraction2.Denominator;
            return new Fraction(num, denom);
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            BigInteger num = fraction1.Numerator * fraction2.Denominator + fraction1.Denominator * fraction2.Numerator;
            BigInteger denom = fraction1.Denominator * fraction2.Denominator;
            return new Fraction(num, denom);
        }

        public override string ToString()
        {
            decimal result = (decimal)this.Numerator / (decimal)this.Denominator;
            return String.Format("{0}", result);
        }
    }
}
