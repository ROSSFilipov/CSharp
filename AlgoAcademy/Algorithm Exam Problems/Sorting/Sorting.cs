using System;
using System.Collections.Generic;
using System.Linq;

class Sorting
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int numberOfNumbers = int.Parse(input[0]);
        long divisor = long.Parse(input[1]);

        List<long> numbers = Console.ReadLine()
            .Split()
            .Select(long.Parse)
            .ToList();

        numbers.Sort((x, y) =>
            {
                long resultX = x % divisor;
                long resultY = y % divisor;
                if (resultX == resultY)
                {
                    return x.CompareTo(y);
                }
                else
                {
                    return resultX.CompareTo(resultY);
                }

            });

        Console.WriteLine(string.Join(" ", numbers));
    }
}

