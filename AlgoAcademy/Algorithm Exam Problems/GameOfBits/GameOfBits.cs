using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GameOfBits
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        SortedSet<long> numberCollection = new SortedSet<long>();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            long currentNumber = long.Parse(Console.ReadLine());
            if (!numberCollection.Contains(currentNumber))
            {
                numberCollection.Add(currentNumber);
            }
            else
            {
                numberCollection.Remove(currentNumber);
            }

            if (numberCollection.Count == 0)
            {
                sb.AppendLine("There are no numbers");
            }
            else if (numberCollection.Count == 1)
            {
                sb.AppendLine("There is only one number");
            }
            else
            {
                long minDifference = CalculateMinDifference(numberCollection);
                sb.AppendLine(minDifference.ToString());
            }
        }

        Console.Write(sb.ToString());
    }

    private static long CalculateMinDifference(SortedSet<long> numberCollection)
    {
        long difference = long.MaxValue;
        long previousNumber = numberCollection.ElementAt(0);
        foreach (long nextNumber in numberCollection)
        {
            if (nextNumber - previousNumber < difference && nextNumber != previousNumber)
            {
                difference = nextNumber - previousNumber;
            }

            previousNumber = nextNumber;
        }

        return difference;
    }
}

