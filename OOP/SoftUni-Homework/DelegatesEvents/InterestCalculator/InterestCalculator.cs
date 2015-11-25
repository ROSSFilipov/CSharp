using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalculator
{
    public delegate double InterestDelegate(long sum, double interest, int years);

    class InterestCalculator
    {
        private const int n = 12;

        static void Main(string[] args)
        {
            long sum = long.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());
            int years = int.Parse(Console.ReadLine());

            InterestDelegate simpleDelegate = 
                new InterestDelegate(GetSimpleInterest);

            InterestDelegate compoundDelegate =
                new InterestDelegate(GetCompoundInterest);

            double simple = StaticCalculator.Calculate(sum, interest, years, simpleDelegate);
            double compound = StaticCalculator.Calculate(sum, interest, years, compoundDelegate);

            Console.WriteLine("The simple interest is: {0:F4}", simple);
            Console.WriteLine("The compound interest is: {0:F4}", compound);
        }

        private static double GetSimpleInterest(long sum, double interest, int years)
        {
            double result = sum * (1 + (interest * years) / 100);
            return result;
        }

        private static double GetCompoundInterest(long sum, double interest, int years)
        {
            double result = sum * Math.Pow(1 + (interest / n) / 100, years * n);
            return result;
        }
    }
}
