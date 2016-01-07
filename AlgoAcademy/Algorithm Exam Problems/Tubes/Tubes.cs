using System;
using System.Collections.Generic;
using System.Linq;

class Tubes
{
    static void Main(string[] args)
    {
        int numberOfTubes = int.Parse(Console.ReadLine());
        long numberOfFriends = long.Parse(Console.ReadLine());
        long[] tubes = new long[numberOfTubes];
        long biggestTube = 0;
        for (int i = 0; i < numberOfTubes; i++)
        {
            tubes[i] = long.Parse(Console.ReadLine());
            if (tubes[i] > biggestTube)
            {
                biggestTube = tubes[i];
            }
        }

        BinarySearchSolution(tubes, numberOfFriends, numberOfTubes, biggestTube);
    }

    private static void BinarySearchSolution(long[] tubes, long numberOfFriends, int numberOfTubes, long biggestTube)
    {
        long totalQuantity = biggestTube;
        long minimumSize = 0;
        long maxSize = -1;

        while (minimumSize <= totalQuantity)
        {
            long currentSize = (minimumSize + totalQuantity) / 2;

            long currentNumberOfTubes = CalculateNumberOfTubes(tubes, currentSize, numberOfFriends, numberOfTubes);

            if (currentNumberOfTubes >= numberOfFriends)
            {
                minimumSize = currentSize + 1;
                maxSize = currentSize;
            }
            else if (currentNumberOfTubes > numberOfFriends)
            {
                minimumSize = currentSize + 1;
            }
            else
            {
                totalQuantity = currentSize - 1;
            }
        }

        Console.WriteLine(maxSize);
    }

    /// <summary>
    /// The method calculates how many tubes we are able to make with the current size.
    /// </summary>
    private static long CalculateNumberOfTubes(long[] tubes, long currentSize, long numberOfFriends, int numberOfTubes)
    {
        long counter = 0;
        for (int i = 0; i < numberOfTubes; i++)
        {
            if (tubes[i] >= currentSize)
            {
                counter += tubes[i] / currentSize;
            }
        }

        return counter;
    }
}

