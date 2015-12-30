using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class RageQuit
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Regex pattern = new Regex("([^\\d]+)([\\d]+)");
        MatchCollection collection = pattern.Matches(input);
        StringBuilder sb = new StringBuilder();

        foreach (Match item in collection)
        {
            string sentence = item.Groups[1].Value.ToString();
            int number = int.Parse(item.Groups[2].Value.ToString());
            for (int i = 0; i < number; i++)
            {
                sb.Append(sentence.ToUpper());
            }
        }

        Console.WriteLine("Unique symbols used: {0}", sb.ToString().Distinct().Count());
        Console.WriteLine(sb.ToString());
    }
}

