using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class TerroristsWin
{
    static void Main(string[] args)
    {
        char[] input = Console.ReadLine().ToCharArray();

        int impact1 = 0;
        int impact2 = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i].ToString() == "|")
            {
                impact1 = i;
                i++;
                StringBuilder sb = new StringBuilder();
                while (input[i].ToString() != "|")
                {
                    sb.Append(input[i]);
                    i++;
                }
                impact2 = i;
                Explosion(input, sb, impact1, impact2);
            }
        }

        Console.WriteLine(String.Join("", input));
    }

    private static void Explosion(char[] input, StringBuilder sb, int impact1, int impact2)
    {
        string bomb = sb.ToString();
        int sum = 0;

        for (int j = 0; j < bomb.Length; j++)
        {
            sum += (char)bomb[j];
        }

        int radius = sum % 10;

        for (
            int h = (impact1 - radius < 0 ? 0 : impact1 - radius);
            h <= (impact2 + radius > input.Length - 1 ? input.Length - 1 : impact2 + radius);
            h++
            )
        {
            input[h] = '.';
        }
    }
}

