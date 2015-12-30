using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

class UppercaseWords
{
    static void Main(string[] args)
    {
        StringBuilder input = new StringBuilder(Console.ReadLine());
        Regex wordPattern = new Regex(@"(?<![a-zA-Z])[A-Z]+(?![a-zA-Z])");
        while (input.ToString() != "END")
        {
            MatchCollection matches = wordPattern.Matches(input.ToString());
            int offset = 0;
            foreach (Match item in matches)
            {
                string word = item.Value;
                string reversed = String.Join("", item.Value.ToCharArray().Reverse());
                if (word == reversed)
                {
                    reversed = DoubleEachLetter(reversed);
                }
                input.Remove(item.Index + offset, word.Length);
                input.Insert(item.Index + offset, reversed);
                offset += (reversed.Length - word.Length);
            }
            Console.WriteLine(SecurityElement.Escape(input.ToString()));
            input = new StringBuilder(Console.ReadLine());
        }
    }

    private static string DoubleEachLetter(string reversed)
    {
        StringBuilder doubled = new StringBuilder();
        for (int i = 0; i < reversed.Length; i++)
        {
            doubled.Append(new string(reversed[i], 2));
        }
        return doubled.ToString();
    }
}

