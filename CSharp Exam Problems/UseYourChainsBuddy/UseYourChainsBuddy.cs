using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class UseYourChainsBuddy
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine().Trim();

        Regex one = new Regex(@"(?<=<p>)([^><]+)(?=<\/p>)");

        MatchCollection firstColl = one.Matches(input);
        StringBuilder sb = new StringBuilder();
        foreach (var item in firstColl)
        {
            sb.Append(item.ToString());
        }
        string input2 = sb.ToString();
        string final = Regex.Replace(input2, @"[^a-z0-9]+", " ").Replace(@"\s+", " ");

        char[] decrypt = final.ToCharArray();
        for (int i = 0; i < decrypt.Length; i++)
        {
            if (decrypt[i] >= 'a' && decrypt[i] < 'n')
            {
                decrypt[i] = (char)(decrypt[i] + 13);
            }
            else if (decrypt[i] >= 'n' && decrypt[i] <= 'z')
            {
                decrypt[i] = (char)(decrypt[i] - 13);
            }
            else
            {
                continue;
            }
        }
        foreach (var item in decrypt)
        {
            Console.Write(item);
        }
    }
}

