using System;
using System.Collections.Generic;
using System.Linq;

class Algograms
{
    static void Main(string[] args)
    {
        HashSet<string> anagrams = new HashSet<string>();
        while (true)
        {
            string currentLine = Console.ReadLine();

            if (currentLine == "-1")
            {
                break;
            }

            int[] numbers = new int[27];
            for (int i = 0; i < currentLine.Length; i++)
            {
                numbers[currentLine[i] - 96]++;
            }

            anagrams.Add(string.Join("", numbers));
        }

        Console.WriteLine(anagrams.Count);
    }
}
