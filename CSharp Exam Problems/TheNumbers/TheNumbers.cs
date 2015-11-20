using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TheNumbers
{
    class TheNumbers
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine().Trim();

            Regex replacePattern = new Regex("[^0-9]");

            string[] numbers = replacePattern.Replace(message, " ").Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = "0x" + string.Format("{0:X}", int.Parse(numbers[i])).PadLeft(4, '0').ToUpper();
            }

            Console.WriteLine(string.Join("-", numbers));
        }
    }
}
