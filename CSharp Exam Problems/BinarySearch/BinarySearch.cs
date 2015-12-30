using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class BinarySearch
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        long number = long.Parse(Console.ReadLine());

        long[] numbersArray = new long[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            numbersArray[i] = long.Parse(input[i]);
        }

        //Timer on Binary Search
        Stopwatch timer = new Stopwatch();
        timer.Start();
        int numberIndex = CheckIndexUsingBinarySearch(numbersArray, number);
        timer.Stop();

        if (numberIndex != -1)
        {
            Console.WriteLine("Number {0} found at index {1}. Elapsed time: {2}.", number, numberIndex, timer.Elapsed);
        }
        else
        {
            Console.WriteLine("Number {0} not found.", number);
        }

        //Timer on Linear Search
        timer.Restart();
        int numberIndex2 = CheckIndexUsingLinearSearch(numbersArray, number);
        timer.Stop();

        if (numberIndex2 != -1)
        {
            Console.WriteLine("Number {0} found at index {1}. Elapsed time: {2}.", number, numberIndex2, timer.Elapsed);
        }
        else
        {
            Console.WriteLine("Number {0} not found.", number);
        }
    }

    private static int CheckIndexUsingBinarySearch(long[] numbersArray, long number)
    {
        int startIndex = 0;
        int endIndex = numbersArray.Length - 1;

        while (startIndex <= endIndex)
        {
            int currentIndex = (startIndex + endIndex) / 2;

            if (numbersArray[currentIndex] == number)
            {
                return currentIndex;
            }
            else if (number < numbersArray[currentIndex])
            {
                endIndex = currentIndex - 1;
            }
            else
            {
                startIndex = currentIndex + 1;
            }
        }

        return -1;
    }

    private static int CheckIndexUsingLinearSearch(long[] numbersArray, long number)
    {
        int index = -1;

        for (int i = 0; i < numbersArray.Length; i++)
        {
            if (numbersArray[i] == number)
            {
                index = i;
                break;
            }
        }

        return index;
    }
}

