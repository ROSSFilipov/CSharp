using System;
using System.Collections.Generic;
using System.Linq;

class ZigZagSequences
{
    private static int[] numbersArray;
    private static int[] sequenceArray;
    private static bool[] used;
    private static int solutionsCounter = 0;
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int arraySize = int.Parse(input[0]);
        int sequenceSize = int.Parse(input[1]);
        numbersArray = new int[arraySize];
        for (int i = 0; i < arraySize; i++)
        {
            numbersArray[i] = i;
        }

        sequenceArray = new int[sequenceSize];
        used = new bool[arraySize];

        for (int i = 0; i < arraySize; i++)
        {
            //sequenceArray[0] = numbersArray[i];
            used[i] = true;
            CountZigZagSequences(1, sequenceSize, 1, numbersArray[i], arraySize);
            used[i] = false;
        }

        Console.WriteLine(solutionsCounter);
    }

    private static void CountZigZagSequences(int index, int sequenceSize, int zigZagIndex, int prevNumber, int arraySize)
    {
        if (index >= sequenceSize)
        {
            solutionsCounter++;
            //Console.WriteLine(string.Join(", ", sequenceArray));
            return;
        }

        for (int i = 0; i < arraySize; i++)
        {
            if (zigZagIndex == 1 && numbersArray[i] < prevNumber && !used[i])
            {
                used[i] = true;
                //sequenceArray[index] = numbersArray[i];
                CountZigZagSequences(index + 1, sequenceSize, 0, numbersArray[i], arraySize);
                used[i] = false;
            }
            else if (zigZagIndex == 0 && numbersArray[i] > prevNumber && !used[i])
            {
                used[i] = true;
                //sequenceArray[index] = numbersArray[i];
                CountZigZagSequences(index + 1, sequenceSize, 1, numbersArray[i], arraySize);
                used[i] = false;
            }
            else
            {
                continue;
            }
        }
    }
}

