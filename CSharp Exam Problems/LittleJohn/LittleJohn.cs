using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class LittleJohn
{
    static void Main(string[] args)
    {
        //87/100
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 4; i++)
        {
            sb.AppendLine(Console.ReadLine());
        }
        string text = sb.ToString();
        int smallArrows = CalculateSmallArrows(text);
        int mediumArrows = CalculateMediumArrows(text);
        int bigArrows = CalculateBigArrows(text);

        string sum = smallArrows.ToString() + mediumArrows.ToString() + bigArrows.ToString();
        string reversed = String.Join("", Convert.ToString(int.Parse(sum), 2).ToCharArray().Reverse());
        int final = Convert.ToInt32(Convert.ToString(int.Parse(sum), 2) + reversed, 2);
        //Console.WriteLine(smallArrows);
        //Console.WriteLine(mediumArrows);
        //Console.WriteLine(bigArrows);
        Console.WriteLine(final);

    }

    private static int CalculateBigArrows(string text)
    {
        Regex pattern = new Regex(">>>----->>");
        MatchCollection matchColl = pattern.Matches(text);
        return matchColl.Count;
    }

    private static int CalculateMediumArrows(string text)
    {
        Regex pattern = new Regex(">>----->(?!\\>)");
        MatchCollection matchColl = pattern.Matches(text);
        return matchColl.Count;
    }

    private static int CalculateSmallArrows(string text)
    {
        Regex pattern = new Regex("(?<!\\>)>----->(?!\\>)");
        MatchCollection matchColl = pattern.Matches(text);
        return matchColl.Count;
    }
}

