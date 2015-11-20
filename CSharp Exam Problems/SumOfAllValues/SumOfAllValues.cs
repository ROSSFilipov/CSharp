using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SumOfAllValues
{
    class SumOfAllValues
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string text = Console.ReadLine();

            //string key = "startKEY12a";
            //string text = "asdjykulgfjddfsffdstartKEY12endKEYqwfrhtyu67543rewghy3tefdgdstartKEY123.45endKEYwret34yrestartKEY2.6endKEY213434ytuhrgerweasfdstartKEYendKEYstartKEYasfdgeendKEY";

            Regex keyStartPattern = new Regex("^[a-zA-Z_]+(?=[0-9])");
            Regex keyEndPattern = new Regex("(?<=[0-9])[a-zA-Z_]+$");

            string keyStart = keyStartPattern.Match(key).Value;
            string keyEnd = keyEndPattern.Match(key).Value;

            if (string.IsNullOrEmpty(keyStart) || string.IsNullOrEmpty(keyEnd))
            {
                Console.WriteLine("<p>A key is missing</p>");
            }
            else
            {
                Regex valuesPattern = new Regex((keyStart) + "([0-9\\.]+)" + (keyEnd));

                MatchCollection valuesCollection = valuesPattern.Matches(text);

                double sum = 0;
                foreach (Match item in valuesCollection)
                {
                    double currentMatch = 0;
                    if (double.TryParse(item.Groups[1].Value, out currentMatch))
                    {
                        sum += double.Parse(item.Groups[1].Value);
                    }
                    else
                    {
                        continue;
                    }
                }

                Console.WriteLine("<p>The total value is: <em>{0}</em></p>", sum != 0 ? sum.ToString() : "nothing");
            }
        }
    }
}
