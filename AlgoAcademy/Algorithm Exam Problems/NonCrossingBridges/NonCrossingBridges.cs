using System;
using System.Collections.Generic;
using System.Linq;

class NonCrossingBridges
{
    static void Main(string[] args)
    {
        int[] sequence = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        FindNumberOfBridges(sequence);
    }

    private static void FindNumberOfBridges(int[] sequence)
    {
        int size = sequence.Length;
        int[] bridgesCount = new int[size];
        int[] indexes = new int[size];
        char[] charArray = new char[size];

        for (int i = 0; i < size; i++)
        {
            for (int j = i; j >= 0; j--)
            {
                if (indexes[j] != 0 && sequence[j] != sequence[i] && i != j)
                {
                    bridgesCount[i] = bridgesCount[j];
                    break;
                }
                if (sequence[i] == sequence[j] && i != j)
                {
                    bridgesCount[i] = bridgesCount[j] + 1;
                    indexes[i] = 1;
                    indexes[j] = 1;
                    break;
                }
            }
        }

        if (bridgesCount[size - 1] == 0)
        {
            Console.WriteLine("No bridges found");
        }
        else if (bridgesCount[size - 1] == 1)
        {
            Console.WriteLine("1 bridge found");
        }
        else
        {
            Console.WriteLine("{0} bridges found", bridgesCount[size - 1]);
        }

        for (int i = 0; i < size; i++)
        {
            if (indexes[i] == 0)
            {
                Console.Write("X");
            }
            else
            {
                Console.Write(sequence[i]);
            }
            if (i != size - 1)
            {
                Console.Write(" ");
            }
        }
    }
}

