using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PlusRemove
{
    static void Main(string[] args)
    {
        List<string> sentence = new List<string>();
        string input = Console.ReadLine();

        int bestLength = 0;
        while (input != "END")
        {
            sentence.Add(input);
            if (input.Length > bestLength)
            {
                bestLength = input.Length;
            }
            input = Console.ReadLine();
        }

        bool[][] jaggedBool = new bool[sentence.Count][];
        string[][] jagged = new string[sentence.Count][];
        for (int i = 0; i < jagged.Length; i++)
        {
            string x = sentence[i].PadRight(bestLength, ' ');
            jagged[i] = new string[x.Length];
            jaggedBool[i] = new bool[x.Length];
            for (int j = 0; j < jagged[i].Length; j++)
            {
                jagged[i][j] = x[j].ToString();
                jaggedBool[i][j] = true;
            }
        }

        for (int i = 0; i < jagged.Length - 2; i++)
        {
            for (int j = 1; j < jagged[i].Length - 1; j++)
            {
                if (jagged[i][j].ToLower() == jagged[i + 1][j].ToLower()
                    && jagged[i + 1][j].ToLower() == jagged[i + 1][j - 1].ToLower()
                    && jagged[i + 1][j - 1].ToLower() == jagged[i + 1][j + 1].ToLower()
                    && jagged[i + 1][j + 1].ToLower() == jagged[i + 2][j].ToLower())
                {
                    jaggedBool[i][j] = false;
                    jaggedBool[i + 1][j] = false;
                    jaggedBool[i + 2][j] = false;
                    jaggedBool[i + 1][j + 1] = false;
                    jaggedBool[i + 1][j - 1] = false;
                }
            }
        }

        for (int i = 0; i < jaggedBool.Length; i++)
        {
            for (int j = 0; j < jaggedBool[i].Length; j++)
            {
                if (jaggedBool[i][j] == false)
                {
                    jagged[i][j] = "";
                }
            }
            Console.WriteLine(String.Join("", jagged[i]));
        }
    }
}

