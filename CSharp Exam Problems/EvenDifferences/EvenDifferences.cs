using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class EvenDifferences
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine()
            .Split(new char[0], StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        long evenSum = 0;

        for (int i = 1; i < numbers.Length; i++)
        {
            int difference = numbers[i] >= numbers[i - 1] ? numbers[i] - numbers[i - 1] : numbers[i - 1] - numbers[i];
            if (difference % 2 == 0)
            {
                evenSum += difference;
                i++;
            }
            else
            {
                continue;
            }
        }

        Console.WriteLine(evenSum);
    }
}

