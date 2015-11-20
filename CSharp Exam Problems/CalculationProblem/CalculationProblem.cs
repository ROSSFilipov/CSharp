using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationProblem
{
    class CalculationProblem
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    sum += (input[i][j] - 97) * Math.Pow(23, input[i].Length - 1 - j);
                }
            }

            double sum2 = sum;
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                char num = (char)(sum2 % 23 + 97);
                sb.Append(num);
                if (sum2 <= 23)
                {
                    break;
                }
                
                sum2 = sum2 / 23;
            }

            Console.WriteLine("{0} = {1}", string.Join("", sb.ToString().ToCharArray().Reverse()), sum);
        }
    }
}
