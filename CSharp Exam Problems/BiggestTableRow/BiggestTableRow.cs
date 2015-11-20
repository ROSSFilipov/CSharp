using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BiggestTableRow
{
    class BiggestTableRow
    {
        static void Main(string[] args)
        {
            string input = TakeInpuut();

            Regex removePattern = new Regex("(<table>)|(</table>)|(<tr>)|(</tr>)|(<th>)|(</th>)|(<td>)|(</td>)");

            string table = removePattern.Replace(input, " ");

            string[] rows = table.Split(new char[]{'\n'}, StringSplitOptions.RemoveEmptyEntries);

            bool dataFound = false;
            double bestSum = 0;
            var bestString = new List<string>();
            for (int i = 0; i < rows.Length; i++)
            {
                double currentSum = 0;
                List<string> currentString = new List<string>();
                string[] rowElements = rows[i].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < rowElements.Length; j++)
                {
                    double currentValue;
                    if (!double.TryParse(rowElements[j], out currentValue))
                    {
                        continue;
                    }

                    currentValue = double.Parse(rowElements[j]);

                    currentString.Add(rowElements[j]);
                    currentSum += currentValue;
                    dataFound = true;
                }

                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                    bestString = currentString;
                }
                else
                {
                    continue;
                }
            }

            if (dataFound)
            {
                Console.WriteLine("{0} = {1}", bestSum, string.Join(" + ", bestString));
            }
            else
            {
                Console.WriteLine("no data");
            }
        }

        private static string TakeInpuut()
        {
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                string line = Console.ReadLine().Trim();

                if (line == "</table>")
                {
                    sb.Append(line);
                    break;
                }

                sb.AppendLine(line);
            }

            return sb.ToString();
        }
    }
}
