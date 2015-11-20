using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OhMyGirl
{
    class OhMyGirl
    {
        //40/100
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                sb.AppendLine(input);
            }

            string text = sb.ToString();

            //Checks the hard elements in the key
            Regex keyHardPattern = new Regex("[^\\w\\d]*?");
            string keyHardString = keyHardPattern.Match(key).ToString();

            if (keyHardString == string.Empty)
            {
                keyHardString = null;
            }

            //Checks the rest of the key elements
            char keyFirstLetter = key[0];
            char keyLastLetter = key[key.Length - 1];
            string keyInnerSymbolsOne = CheckInnerStringOne(key);
            string keyInnerSymbolsTwo = CheckInnerStringTwo(key);

            Regex keyPattern = new Regex
                (
                keyFirstLetter + keyInnerSymbolsOne + keyHardString + keyInnerSymbolsTwo + keyLastLetter +
                "(.*?)" +
                keyFirstLetter + keyInnerSymbolsOne + keyHardString + keyInnerSymbolsTwo + keyLastLetter
                );

            MatchCollection keyCollection = keyPattern.Matches(text);

            StringBuilder sb1 = new StringBuilder();

            foreach (Match item in keyCollection)
            {
                sb1.Append(item.Groups[1]);
            }

            Console.WriteLine(sb1.ToString());
        }

        private static string CheckInnerStringOne(string key)
        {
            if (key.Length <= 3)
            {
                return null;
            }
            else
            {
                Regex numberPattern = new Regex("[0-9]");
                Regex letterPattern = new Regex("[\\w]");
                if (numberPattern.IsMatch(key[1].ToString()))
                {
                    return "[\\d]*?";
                }
                else if (letterPattern.IsMatch(key[1].ToString()))
                {
                    return "[\\w]*?";
                }
                else
                {
                    return null;
                }
            }
        }

        private static string CheckInnerStringTwo(string key)
        {
            if (key.Length <= 3)
            {
                return null;
            }
            else
            {
                Regex numberPattern = new Regex("[0-9]");
                Regex letterPattern = new Regex("[\\w]");
                if (numberPattern.IsMatch(key[key.Length - 2].ToString()))
                {
                    return "[\\d]*?";
                }
                else if (letterPattern.IsMatch(key[key.Length - 2].ToString()))
                {
                    return "[\\w]*?";
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
