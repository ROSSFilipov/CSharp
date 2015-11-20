using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidUsernames
{
    class ValidUsernames
    {
        static void Main(string[] args)
        {
            //90/100
            string input = Console.ReadLine();

            Regex pattern = new Regex(@"(^|(?<=[(|)|\/|\\|\s]))[a-zA-Z]([a-zA-Z0-9_]+){2,25}((?=[(|)|\/|\\|\s])|$)");
            MatchCollection all = pattern.Matches(input);

            int maxSum = int.MinValue;
            string bestOne = String.Empty;
            string bestTwo = String.Empty;
            for (int i = 0; i < all.Count - 1; i++)
            {
                int sum = all[i].Length + all[i + 1].Length;
                if (sum > maxSum)
                {
                    maxSum = sum;
                    bestOne = all[i].ToString();
                    bestTwo = all[i + 1].ToString();
                }
            }
            Console.WriteLine(bestOne);
            Console.WriteLine(bestTwo);
        }
    }
}
