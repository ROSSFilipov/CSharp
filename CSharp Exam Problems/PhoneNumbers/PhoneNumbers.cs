using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneNumbers
{
    class PhoneNumbers
    {
        static void Main(string[] args)
        {
            string text = TakeInput() ;

            Regex combinedPattern = new Regex("([A-Z][A-Za-z]*?)[^+a-zA-Z]*?([+]?[0-9][0-9\\,\\-\\.\\/\\s\\)\\(]*[0-9])");

            MatchCollection userCollection = combinedPattern.Matches(text);

            if (userCollection.Count == 0)
            {
                Console.WriteLine("<p>No matches!</p>");
            }
            else
            {
                Console.Write("<ol>");
                foreach (Match item in userCollection)
                {
                    string[] phonesFormatted = item.Groups[2].Value.Split(new char[] { '-', ')', '(', '.', '/', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    Console.Write("<li><b>{0}:</b> {1}</li>", item.Groups[1].Value, string.Join("", phonesFormatted));
                }
                Console.WriteLine("</ol>"); 
            }
        }

        private static string TakeInput()
        {
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                string currentLine = Console.ReadLine();

                if (currentLine == "END")
                {
                    break;
                }

                sb.AppendLine(currentLine);
            }

            return sb.ToString();
        }
    }
}
