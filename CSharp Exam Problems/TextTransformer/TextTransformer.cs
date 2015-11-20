using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextTransformer
{
    class TextTransformer
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string input = Console.ReadLine();
            while (input != "burp")
            {
                sb.Append(input);
                input = Console.ReadLine();
            }
            string text = Regex.Replace(sb.ToString(), "\\s+", " ");
            Regex pattern1 = new Regex("\\$[^\\$\\s\\%\\&\\']+\\$");
            Regex pattern2 = new Regex("\\%[^\\$\\s\\%\\&\\']+\\%");
            Regex pattern3 = new Regex("\\&[^\\$\\s\\%\\&\\']+\\&");
            Regex pattern4 = new Regex("\\'[^\\$\\s\\%\\&\\']+\\'");
            List<string> final = new List<string>();
            MatchCollection dollarMatch = pattern1.Matches(text);
            MatchCollection percentMatch = pattern2.Matches(text);
            MatchCollection ampersandMatch = pattern3.Matches(text);
            MatchCollection quoteMatch = pattern4.Matches(text);
            SortedDictionary<int, string> collection = new SortedDictionary<int, string>();
            foreach (Match item in dollarMatch)
            {
                collection.Add(item.Index, item.ToString());
            }
            foreach (Match item in percentMatch)
            {
                collection.Add(item.Index, item.ToString());
            }
            foreach (Match item in ampersandMatch)
            {
                collection.Add(item.Index, item.ToString());
            }
            foreach (Match item in quoteMatch)
            {
                collection.Add(item.Index, item.ToString());
            }
            foreach (var item in collection)
            {
                string x = item.Value;
                ConvertString(x, final);
            }
            Console.WriteLine(String.Join(" ", final));
        }

        private static void ConvertString(string x, List<string> final)
        {
            int weight = 0;
            switch (x[0])
            {
                case '$': weight = 1;
                    break;
                case '%': weight = 2;
                    break;
                case '&': weight = 3;
                    break;
                case '\'': weight = 4;
                    break;
                default:
                    break;
            }
            StringBuilder temp = new StringBuilder();
            for (int i = 1; i < x.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    temp.Append((char)(x[i] - weight));
                }
                else
                {
                    temp.Append((char)(x[i] + weight));
                }
            }
            final.Add(temp.ToString());
        }
    }
}

